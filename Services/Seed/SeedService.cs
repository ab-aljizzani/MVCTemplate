using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using MVCTemplate.Data;
using MVCTemplate.Dtos.CountriesDto.Get;
using MVCTemplate.Dtos.PortalUserModelDto.Insert;
using MVCTemplate.Dtos.RoleDto;
using MVCTemplate.Models.AuditsModel;
using MVCTemplate.Models.PortalUser;
using MVCTemplate.Models.Reponse;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Stardust.Particles;

namespace MVCTemplate.Services.Seed;

public class SeedService : ISeedService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IAuthRepositery _auth;
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;

    public SeedService(IMapper mapper, DataContext context, IAuthRepositery auth, IWebHostEnvironment env, IConfiguration config)
    {
        _auth = auth;
        _mapper = mapper;
        _context = context;
        _env = env;
        _config = config;
    }
    public async Task<ServiceResponse<string>> DeleteAll()
    {
        if (!_config.GetValue<bool>("Seed:Enabled"))
            return new ServiceResponse<string> { Success = false, Message = "Seeding is disabled (Seed:Enabled=false)." };

        await BackupDatabaseOnly();
        var serviceResponse = new ServiceResponse<string>();

        var PortalUser = FormattableStringFactory.Create("ALTER TABLE PortalUser NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(PortalUser);
        var PortalUser_reseed = from c in _context.PortalUser select c;
        _context.PortalUser.RemoveRange(PortalUser_reseed);
        var PortalUser_ = FormattableStringFactory.Create("DBCC CHECKIDENT('PortalUser', RESEED, 0)");
        _context.Database.ExecuteSql(PortalUser_);
        var PortalUser_check = FormattableStringFactory.Create("ALTER TABLE PortalUser CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(PortalUser_check);



        var Role = FormattableStringFactory.Create("ALTER TABLE Role NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Role);
        var Role_reseed = from c in _context.Role select c;
        _context.Role.RemoveRange(Role_reseed);
        var Role_ = FormattableStringFactory.Create("DBCC CHECKIDENT('Role', RESEED, 0)");
        _context.Database.ExecuteSql(Role_);
        var Role_check = FormattableStringFactory.Create("ALTER TABLE Role CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Role_check);





        await _context.SaveChangesAsync();
        serviceResponse.Data = "Delete Seed Exicutes Successfuly";
        return serviceResponse;
    }
    public async Task<ServiceResponse<string>> SeedAll()
    {
        if (!_config.GetValue<bool>("Seed:Enabled"))
            return new ServiceResponse<string> { Success = false, Message = "Seeding is disabled (Seed:Enabled=false)." };

        // Check if Entity table has data (SeedEntityDept should run first)
        try
        {
            // This will create the database if it doesn't exist and apply all migrations
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string>
            {
                Success = false,
                Message = $"Failed to create/migrate database: {ex.Message}",
                Data = "Make sure the SQL Server user has 'dbcreator' role or the database already exists."
            };
        }

        var serviceResponse = new ServiceResponse<string>();



        List<RoleDto> newRole = new List<RoleDto>();
        newRole.Add(new RoleDto { RoleName = "SuperAdmin", RoleArabName = "مدير كامل النظام", Roletype = "Both" });
        newRole.Add(new RoleDto { RoleName = "Admin", RoleArabName = "مدير النظام", Roletype = "Both" });





        List<InsertPortalUserNoPersonalImgDto> newPortalUser = new List<InsertPortalUserNoPersonalImgDto>();
        newPortalUser.Add(new InsertPortalUserNoPersonalImgDto
        {
            Username = "1083622900",
            NationalId = "1083622900",
            Password = "Zero8021#",
            ConfirmPassword = "Zero8021#",
            UserFullName = "عبدالرحمن علي أبكر الجيزاني",
            Email = "b@b.com",
            Code = "0000",
            PhoneNumber = "0563438021",
            DateOfBirth = "24/05/1993",
            UserType = "رئيسي",
            LoginAttemp = 0,
            LastLogin = DateTime.Now.ToString(),
            CreatedDate = DateTime.Now.ToString(),
            PasswordExpires = false,
            Status = "Active",
            RoleId = 1,
            EmpIamImgUrl = "",
            IsFirstLogin = false,
            IsFromShamel = false
        });
        newPortalUser.Add(new InsertPortalUserNoPersonalImgDto
        {
            Username = "1234567890",
            NationalId = "1234567890",
            Password = "Aa@123456#",
            ConfirmPassword = "Aa@123456#",
            UserFullName = "Test Test Test",
            Email = "bb@b.com",
            Code = "0000",
            PhoneNumber = "0555555555",
            DateOfBirth = "01/02/1990",
            UserType = "رئيسي",
            LoginAttemp = 0,
            LastLogin = DateTime.Now.ToString(),
            CreatedDate = DateTime.Now.ToString(),
            PasswordExpires = false,
            Status = "Active",
            RoleId = 1,
            EmpIamImgUrl = "",
            IsFirstLogin = false,
            IsFromShamel = false
        });
        foreach (var item in newRole)
        {
            var role = _mapper.Map<Models.Role.Role>(item);
            _context.Role.Add(role);
        }
        await _context.SaveChangesAsync();

        foreach (var item in newPortalUser)
        {
            CreatePasswordHash(item.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<PortalUser>(item);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _context.PortalUser.Add(user);
        }



        await _context.SaveChangesAsync();
        serviceResponse.Data = "Seed Exicutes Successfuly";
        return serviceResponse;
    }

  

    public async Task<ServiceResponse<string>> SeedCuntriesFromExcel()
    {
        // Excel file path (adjust name as needed)
        var excelPath = Path.Combine(_env.ContentRootPath, "Cuntries.xlsx");
        if (!File.Exists(excelPath))
        {
            excelPath = Path.Combine(_env.WebRootPath, "Cuntries.xlsx");
            if (!File.Exists(excelPath))
            {
                throw new FileNotFoundException($"Countries Excel file not found at: {excelPath}");
            }
        }

        var newCountry = new List<GetCountrieDto>();

        using (var workbook = new XLWorkbook(excelPath))
        {
            var ws = workbook.Worksheets.First();

            var headerRow = ws.FirstRowUsed();
            if (headerRow is null)
                return new ServiceResponse<string> { Data = "Excel sheet is empty." };

            var usedRange = ws.RangeUsed();
            if (usedRange is null)
                return new ServiceResponse<string> { Data = "Excel sheet is empty." };

            // Find a column named "Country" (case-insensitive). If not found, use first column.
            var headerCells = headerRow.CellsUsed().ToList();
            var countryColIndex =
                headerCells.FirstOrDefault(c => string.Equals(c.GetString().Trim(), "Country", StringComparison.OrdinalIgnoreCase))
                    ?.Address.ColumnNumber
                ?? headerCells.First().Address.ColumnNumber;

            foreach (var row in usedRange.RowsUsed().Skip(1)) // skip header
            {
                var countryName = row.Cell(countryColIndex).GetString().Trim();
                if (string.IsNullOrWhiteSpace(countryName))
                    continue;

                newCountry.Add(new GetCountrieDto { Country = countryName });
            }
        }

        // Optional: avoid duplicates (DB side)
        var existing = await _context.Countries
            .Select(c => c.Country)
            .ToListAsync();

        var existingSet = existing
            .Select(c => c.Trim())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var dto in newCountry.Where(c => !existingSet.Contains(c.Country.Trim())))
        {
            var entity = _mapper.Map<Models.CountriesModel.Countries>(dto);
            _context.Countries.Add(entity);
        }

        await _context.SaveChangesAsync();

        return new ServiceResponse<string> { Data = $"Seeded {newCountry.Count} countries from Excel." };
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public async Task<ServiceResponse<string>> BackupAndDeleteDatabase(string backupFileName = null)
    {
        var serviceResponse = new ServiceResponse<string>();

        try
        {
            // Get database name from connection string
            var connectionString = _context.Database.GetConnectionString();
            var databaseName = GetDatabaseNameFromConnectionString(connectionString);

            if (string.IsNullOrEmpty(databaseName))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Could not extract database name from connection string";
                return serviceResponse;
            }

            // Generate backup file name with timestamp if not provided
            if (string.IsNullOrEmpty(backupFileName))
            {
                backupFileName = $"{databaseName}_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            }

            // Get backup path from configuration
            var backupDirectory = _config.GetValue<string>("Backup:Path") ?? @"D:\MSSQL13.MSSQLSERVER\MSSQL\Backup";
            var backupPath = Path.Combine(backupDirectory, backupFileName);

            // Create backup
            var backupQuery = $"BACKUP DATABASE [{databaseName}] TO DISK = '{backupPath}' WITH FORMAT, INIT, NAME = '{databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
            await _context.Database.ExecuteSqlRawAsync(backupQuery);

            serviceResponse.Message = $"Database backup created successfully at: {backupPath}";

            // Close the current connection from this context
            await _context.Database.CloseConnectionAsync();

            // Build a new connection string to the master database
            var masterConnectionString = ChangeDatabaseInConnectionString(connectionString, "master");

            // Use a separate connection to master database to set single user mode and drop the database
            using (var sqlConnection = new Microsoft.Data.SqlClient.SqlConnection(masterConnectionString))
            {
                await sqlConnection.OpenAsync();

                // Set database to single user mode to close all connections
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    await command.ExecuteNonQueryAsync();
                }

                // Drop the database
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = $"DROP DATABASE [{databaseName}]";
                    await command.ExecuteNonQueryAsync();
                }
            }

            serviceResponse.Data = $"Database '{databaseName}' has been backed up and deleted successfully";
            serviceResponse.Message += $"\nDatabase '{databaseName}' deleted successfully";
            serviceResponse.Success = true;
        }
        catch (Exception ex)
        {
            try
            {
                // Try to reset database to multi-user mode in case of error
                var connectionString = _context.Database.GetConnectionString();
                var databaseName = GetDatabaseNameFromConnectionString(connectionString);
                var masterConnectionString = ChangeDatabaseInConnectionString(connectionString, "master");

                using (var sqlConnection = new Microsoft.Data.SqlClient.SqlConnection(masterConnectionString))
                {
                    await sqlConnection.OpenAsync();
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = $"ALTER DATABASE [{databaseName}] SET MULTI_USER";
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch
            {
                // Ignore errors during cleanup
            }

            serviceResponse.Success = false;
            serviceResponse.Message = $"Error during backup and delete operation: {ex.Message}";
            serviceResponse.Data = ex.StackTrace;
        }

        return serviceResponse;
    }

    private string ChangeDatabaseInConnectionString(string connectionString, string newDatabase)
    {
        var builder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
        builder.InitialCatalog = newDatabase;
        return builder.ConnectionString;
    }

    public async Task<ServiceResponse<string>> BackupDatabaseOnly(string backupFileName = null)
    {
        var serviceResponse = new ServiceResponse<string>();

        try
        {
            // Get database name from connection string
            var connectionString = _context.Database.GetConnectionString();
            var databaseName = GetDatabaseNameFromConnectionString(connectionString);

            if (string.IsNullOrEmpty(databaseName))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Could not extract database name from connection string";
                return serviceResponse;
            }

            // Generate backup file name with timestamp if not provided
            if (string.IsNullOrEmpty(backupFileName))
            {
                backupFileName = $"{databaseName}_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            }

            // Get backup path from configuration
            var backupDirectory = _config.GetValue<string>("Backup:Path") ?? @"D:\MSSQL13.MSSQLSERVER\MSSQL\Backup";
            var backupPath = Path.Combine(backupDirectory, backupFileName);

            // Create backup
            var backupQuery = FormattableStringFactory.Create($"BACKUP DATABASE [{databaseName}] TO DISK = '{backupPath}' WITH FORMAT, INIT, NAME = '{databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10");
            await _context.Database.ExecuteSqlAsync(backupQuery);

            serviceResponse.Success = true;
            serviceResponse.Data = backupPath;
            serviceResponse.Message = $"Database backup created successfully at: {backupPath}";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error during backup operation: {ex.Message}";
            serviceResponse.Data = ex.StackTrace;
        }

        return serviceResponse;
    }

    private string GetDatabaseNameFromConnectionString(string connectionString)
    {
        try
        {
            var parts = connectionString.Split(';');
            var dbPart = parts.FirstOrDefault(p => p.Trim().StartsWith("Database=", StringComparison.OrdinalIgnoreCase)
                                            || p.Trim().StartsWith("Initial Catalog=", StringComparison.OrdinalIgnoreCase));

            if (dbPart != null)
            {
                return dbPart.Split('=')[1].Trim();
            }
        }
        catch { }

        return null;
    }

  

}
