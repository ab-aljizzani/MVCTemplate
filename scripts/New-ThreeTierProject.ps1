param(
    [Parameter(Mandatory = $true)]
    [string]$ProjectName,

    [ValidateSet("v1", "v2")]
    [string]$Ui = "v1",

    [string]$DestinationRoot = (Get-Location).Path,

    [string]$ApiTemplatePath = (Get-Location).Path,

    [string]$PortalTemplatePath = (Join-Path (Split-Path -Parent (Get-Location).Path) "MVCTemplatePortal"),

    [switch]$SkipBuild
)

$ErrorActionPreference = "Stop"

function Write-Step([string]$Message) {
    Write-Host "`n=== $Message ===" -ForegroundColor Cyan
}

$targetRoot = Join-Path $DestinationRoot $ProjectName
$portalTarget = Join-Path $targetRoot "MVCTemplatePortal"
$solutionPath = Join-Path $targetRoot "$ProjectName.sln"
$portalCsproj = Join-Path $portalTarget "MVCTemplatePortal.csproj"
$apiCsproj = Join-Path $targetRoot "MVCTemplate.csproj"
$contractsCsproj = Join-Path $targetRoot "MVCTemplate.Contracts\MVCTemplate.Contracts.csproj"

Write-Step "Validating input paths"
if (-not (Test-Path $ApiTemplatePath)) { throw "Api template path not found: $ApiTemplatePath" }
if (-not (Test-Path (Join-Path $ApiTemplatePath "MVCTemplate.csproj"))) { throw "MVCTemplate.csproj not found in: $ApiTemplatePath" }
if (-not (Test-Path $PortalTemplatePath)) { throw "Portal template path not found: $PortalTemplatePath" }
if (-not (Test-Path (Join-Path $PortalTemplatePath ".template.config\template.json"))) {
    throw "Portal template is missing .template.config/template.json in: $PortalTemplatePath"
}
if (Test-Path $targetRoot) { throw "Target folder already exists: $targetRoot" }

Write-Step "Creating target project root"
New-Item -ItemType Directory -Path $targetRoot | Out-Null

Write-Step "Copying base API + Contracts template"
$excludeDirs = @(".git", ".vs", "bin", "obj")
$excludeFiles = @("*.user", "*.suo")
Get-ChildItem -Path $ApiTemplatePath -Force |
    Where-Object { $excludeDirs -notcontains $_.Name } |
    ForEach-Object {
        Copy-Item -Path $_.FullName -Destination $targetRoot -Recurse -Force
    }

$existingSln = Get-ChildItem -Path $targetRoot -Filter "*.sln" -File -ErrorAction SilentlyContinue
if ($existingSln) {
    $existingSln | Remove-Item -Force
}

Write-Step "Installing portal template locally"
dotnet new install "$PortalTemplatePath" | Out-Host

Write-Step "Generating portal project with selected UI template: $Ui"
dotnet new mvcportal --name MVCTemplatePortal --ui $Ui --output "$portalTarget" | Out-Host

Write-Step "Fixing project reference path in portal project"
$portalXml = Get-Content -Path $portalCsproj -Raw
$portalXml = $portalXml.Replace("..\MVCTemplate\MVCTemplate.csproj", "..\MVCTemplate.csproj")
$portalXml = $portalXml.Replace("../MVCTemplate/MVCTemplate.csproj", "../MVCTemplate.csproj")
Set-Content -Path $portalCsproj -Value $portalXml -Encoding UTF8

Write-Step "Creating solution and adding all three projects"
dotnet new sln --name $ProjectName --output "$targetRoot" | Out-Host
dotnet sln "$solutionPath" add "$apiCsproj" | Out-Host
dotnet sln "$solutionPath" add "$contractsCsproj" | Out-Host
dotnet sln "$solutionPath" add "$portalCsproj" | Out-Host

if (-not $SkipBuild) {
    Write-Step "Restoring and building solution"
    dotnet restore "$solutionPath" | Out-Host
    dotnet build "$solutionPath" | Out-Host
}

Write-Step "Done"
Write-Host "Project created at: $targetRoot" -ForegroundColor Green
Write-Host "Selected UI template: $Ui" -ForegroundColor Green
Write-Host "Open in Visual Studio: $solutionPath" -ForegroundColor Green
