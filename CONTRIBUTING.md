# Contributing

## Project Standards

All projects derived from this template must follow the same base approach:

1. Solution structure must contain:
   - `MVCTemplate` (API/backend)
   - `MVCTemplate.Contracts` (shared DTO/contracts)
   - `MVCTemplatePortal` (UI project generated from template)
2. Target framework must remain `.NET 8` unless explicitly upgraded across all projects.
3. Portal project must be created from the `mvcportal` template and use one UI option:
   - `v1` (classic)
   - `v2` (modern)
4. New project creation should use the documented Git workflow (branch/repository-first), not ad-hoc file copy.
5. Generated project must build successfully before first commit.

## Recommended New Project Workflow (5 Steps)

1. Create a new GitHub repository for the new app.
2. Clone your base repositories locally.
3. Install portal template and generate portal UI (`v1` or `v2`).
4. Create a solution and add all three projects.
5. Configure `appsettings`, then restore/build and validate startup before first commit.

## Clean way to create each new project (no `.ps1`)

### 1) Create a new GitHub repo for the new project
Name it, for example: `MyNewApp`.

### 2) Clone your base repos locally
```cmd
cd C:\Users\SRG1\Documents\GitRepo
mkdir MyNewApp
cd MyNewApp

git clone https://github.com/ab-aljizzani/MVCTemplate.git
git clone https://github.com/ab-aljizzani/MVCTemplatePortal.git
```

### 3) Install the portal template and generate UI (`v1` or `v2`)
```cmd
cd MVCTemplatePortal
dotnet new install .

cd ..
dotnet new mvcportal --name MVCTemplatePortal --ui v1 --output MVCTemplatePortal.Generated
```

> Use `--ui v2` for modern UI.

### 4) Create solution and add all 3 projects
```cmd
dotnet new sln --name MyNewApp

dotnet sln MyNewApp.sln add MVCTemplate\MVCTemplate.csproj
dotnet sln MyNewApp.sln add MVCTemplate\MVCTemplate.Contracts\MVCTemplate.Contracts.csproj
dotnet sln MyNewApp.sln add MVCTemplatePortal.Generated\MVCTemplatePortal.csproj
```

### 5) Configure appsettings, restore, build, validate startup
```cmd
dotnet restore MyNewApp.sln
dotnet build MyNewApp.sln
```

Then open the solution in Visual Studio and verify API + Portal startup.

## Pull Request Expectations

- Keep architecture consistency with this template.
- Keep project references valid between API, Contracts, and Portal.
- Include setup notes when introducing workflow changes.
- Ensure no secrets are committed in configuration files.