using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using ClinicApi.Dtos.DashboardUserDto;
using ClinicApi.Dtos.DashboardUserDto.Insert;
using ClinicApi.Dtos.DashboardUserDto.Update;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.PortalUserModelDto.Insert;
using ClinicApi.Dtos.PortalUserModelDto.Update;
using ClinicApi.Models.DashboarUserModel;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClinicApi.Data;

public class AuthRepositery : IAuthRepositery
{
    private readonly MagicString _magicString;
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthRepositery(MagicString magicString, IMapper mapper, DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _magicString = magicString;
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<string>> Login(string nationalId, string password)
    {
        var _random = new Random();
        var response = new ServiceResponse<string>();
        var user = await _context.PortalUser.Include(u => u.PersonalImage).Include(u => u.Entity).Include(u => u.Role).Include(u => u.Department).FirstOrDefaultAsync(u => u.NationalId.ToLower().Equals(nationalId.ToLower()));
        if (user is null)
        {
            response.Success = false;
            response.Message = "User Not Found... ";
        }

        else if (user.Status == "DisActive")
        {
            response.Success = false;
            response.Message = "User DisActive... ";
        }
        // else if(user.LastLogin)
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong Password...";
            user.LoginAttemp = user.LoginAttemp + 1;
            await _context.SaveChangesAsync();
            if (user.LoginAttemp >= 4)
            {
                response.Success = false;
                response.Message = _magicString.LoginAttimptMessage;
                user.Status = "DisActive";
                await _context.SaveChangesAsync();
            }
        }
        else
        {
            user.Code = _random.Next(0, 9999).ToString("D4");
            response.Data = CreateToken(user);
            user.LastLogin = DateTime.Now.ToString();
            user.LoginAttemp = 0;
            await _context.SaveChangesAsync();
        }
        return response;
    }


    public async Task<ServiceResponse<int>> Register(InsertPortalUserDto userDto, string password)
    {
        var response = new ServiceResponse<int>();
        if (await UserExists(userDto.Username))
        {
            response.Success = false;
            response.Message = "User Already Exists...";
        }
        else
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<PortalUser>(userDto);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _context.PortalUser.Add(user);
            await _context.SaveChangesAsync();
            response.Data = userDto.Id;
        }
        return response;
    }

    public async Task<bool> UserExists(string username)
    {
        if (await _context.PortalUser.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
        {
            return true;
        }
        return false;
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    private bool VerifyPasswordHash(string password, byte[] passrwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passrwordHash);
        }
    }
    private string CreateToken(PortalUser user)
    {
        var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim("PortalUserId",user.Id.ToString()),
                new Claim("Username",user.Username),
                new Claim("UserFullName",user.UserFullName.ToString()),
                new Claim("NationalId",user.NationalId),
                new Claim("PhoneNumber",user.PhoneNumber),
                new Claim("Code",user.Code),
                new Claim("UserType",user.UserType.ToString()),
                new Claim("EntityID",user.EntityId.ToString()),
                new Claim("Entity",user.Entity.EntityName),
                new Claim("RoleId",user.RoleId.ToString()),
                new Claim("Role",user.Role.RoleName.ToString()),
                new Claim("RoleType",user.Role.Roletype.ToString()),
                new Claim("DepartmentId" , user.DepartmentId.ToString()),
                new Claim("Department" , user.Department.DepartmentName.ToString()),
                new Claim("LastLogin",user.LastLogin.ToString()),
                new Claim("PasswordExpire",user.PasswordExpires.ToString()),
                new Claim("IsFirstLogin",user.IsFirstLogin.ToString()),
                new Claim("Status",user.Status),
            };
        var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
        if (appSettingsToken is null)
        {
            throw new Exception("AppSettings Token is Null...");
        }
        Console.WriteLine(appSettingsToken);
        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }
    private string CreateDasboiardToken(DashboardUser user)
    {
        var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                   new Claim("PortalUserId",user.Id.ToString()),
                new Claim("Username",user.Username),
                new Claim("UserFullName",user.UserFullName.ToString()),
                new Claim("UserType",user.UserType.ToString()),
                new Claim("EntityID",user.EntityId.ToString()),
                new Claim("Entity",user.Entity.EntityName),
                new Claim("RoleId",user.RoleId.ToString()),
                new Claim("Role",user.Role.RoleName.ToString()),
                new Claim("DepartmentId" , user.DepartmentId.ToString()),
                new Claim("Department" , user.Department.DepartmentName.ToString()),
                new Claim("LastLogin",user.LastLogin.ToString()),
                new Claim("PasswordExpire",user.PasswordExpires.ToString()),
                new Claim("IsFirstLogin",user.IsFirstLogin.ToString()),
                new Claim("Status",user.Status),
            };
        var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
        if (appSettingsToken is null)
        {
            throw new Exception("AppSettings Token is Null...");
        }
        Console.WriteLine(appSettingsToken);
        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }
    public async Task<ServiceResponse<List<PortalUserDto>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<PortalUserDto>>();
        var dbContext = await _context.PortalUser.Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PortalUserDto>(p)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<PortalUserDto>>> GetAllByEntityId(int id)
    {
        var serviceResponse = new ServiceResponse<List<PortalUserDto>>();
        var dbContext = await _context.PortalUser.Where(u => u.EntityId == id).Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).ToListAsync();

        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PortalUserDto>(p)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<PortalUserDto>>> GetAllByUserType(string type)
    {
        var serviceResponse = new ServiceResponse<List<PortalUserDto>>();
        var dbContext = await _context.PortalUser.Where(u => u.UserType == type).Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).ToListAsync();

        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PortalUserDto>(p)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<PortalUserDto>> GetUserByID(int id)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        var dbContext = await _context.PortalUser.Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).FirstOrDefaultAsync(u => u.Id == id && u.EntityId == u.Department.EntityId);

        serviceResponse.Data = _mapper.Map<PortalUserDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<PortalUserDto>> UpdatePortalUser(UpdatePortalUserDto updatePortalUser)
    {

        var serviceResponse = new ServiceResponse<PortalUserDto>();
        try
        {
            var portalUser = await _context.PortalUser.FirstOrDefaultAsync(z => z.Id == updatePortalUser.Id);
            if (portalUser is null)
            {
                throw new Exception($"The Id '{updatePortalUser.Id}'Is Not Founde...");
            }
            CreatePasswordHash(updatePortalUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            updatePortalUser.PasswordSalt = passwordSalt;
            updatePortalUser.PasswordHash = passwordHash;
            _mapper.Map(updatePortalUser, portalUser);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PortalUserDto>(portalUser);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<PortalUserDto>> PasswordExpireUpdate(PasswordExpireUpdateDto passwordExpiredDto)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        try
        {
            var portalUser = await _context.PortalUser.FirstOrDefaultAsync(z => z.Id == passwordExpiredDto.Id);
            if (portalUser is null)
            {
                throw new Exception($"The Id '{passwordExpiredDto.Id}'Is Not Founde...");
            }
            if (VerifyPasswordHash(passwordExpiredDto.Password, portalUser.PasswordHash, portalUser.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "New Password Must Be Different From Old Password...";
            }
            else
            {

                CreatePasswordHash(passwordExpiredDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                passwordExpiredDto.PasswordSalt = passwordSalt;
                passwordExpiredDto.PasswordHash = passwordHash;
                passwordExpiredDto.PasswordExpires = false;
                _mapper.Map(passwordExpiredDto, portalUser);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<PortalUserDto>(portalUser);
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<PortalUserDto>> PasswordInitialUpdate(PasswordInitialDto passwordInitialDto)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        try
        {
            var portalUser = await _context.PortalUser.FirstOrDefaultAsync(z => z.Id == passwordInitialDto.Id);
            if (portalUser is null)
            {
                throw new Exception($"The Id '{passwordInitialDto.Id}'Is Not Founde...");
            }
            if (!VerifyPasswordHash(passwordInitialDto.CurrentPassword, portalUser.PasswordHash, portalUser.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Current Password Is Not Currect...";
            }
            else
            {

                CreatePasswordHash(passwordInitialDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                passwordInitialDto.PasswordSalt = passwordSalt;
                passwordInitialDto.PasswordHash = passwordHash;
                passwordInitialDto.IsFirstLogin = false;
                _mapper.Map(passwordInitialDto, portalUser);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<PortalUserDto>(portalUser);
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<PortalUserDto>> UpdateUserPhone(UpdatePortalUserPhoneDto updatePortalUser)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        try
        {
            var portalUser = await _context.PortalUser.FirstOrDefaultAsync(z => z.Id == updatePortalUser.Id);
            if (portalUser is null)
            {
                throw new Exception($"The Id '{updatePortalUser.Id}'Is Not Founde...");
            }
            _mapper.Map(updatePortalUser, portalUser);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PortalUserDto>(portalUser);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<DashboardUserDto>>> DashboardGetAll()
    {
        var serviceResponse = new ServiceResponse<List<DashboardUserDto>>();
        var dbContext = await _context.DashboardUser.Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<DashboardUserDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<DashboardUserDto>>> DashboardGetAllByEntityId(int id)
    {
        var serviceResponse = new ServiceResponse<List<DashboardUserDto>>();
        var dbContext = await _context.DashboardUser.Where(u => u.EntityId == id).Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).ToListAsync();

        serviceResponse.Data = dbContext.Select(p => _mapper.Map<DashboardUserDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<DashboardUserDto>>> DashboardGetAllByUserType(string type)
    {
        var serviceResponse = new ServiceResponse<List<DashboardUserDto>>();
        var dbContext = await _context.DashboardUser.Where(u => u.UserType == type).Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).ToListAsync();

        serviceResponse.Data = dbContext.Select(p => _mapper.Map<DashboardUserDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<DashboardUserDto>> DashboardGetUserByID(int id)
    {
        var serviceResponse = new ServiceResponse<DashboardUserDto>();
        var dbContext = await _context.DashboardUser.Include(u => u.PersonalImage).Include(e => e.Entity).Include(r => r.Role).Include(d => d.Department).FirstOrDefaultAsync(u => u.Id == id && u.EntityId == u.Department.EntityId);

        serviceResponse.Data = _mapper.Map<DashboardUserDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<int>> DashboardRegister(InsertDashboardUserDto userDto, string password)
    {
        var response = new ServiceResponse<int>();
        if (await UserExists(userDto.Username))
        {
            response.Success = false;
            response.Message = "User Already Exists...";
        }
        else
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<DashboardUser>(userDto);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _context.DashboardUser.Add(user);
            await _context.SaveChangesAsync();
            response.Data = userDto.Id;
        }
        return response;
    }

    public async Task<ServiceResponse<string>> DashboardLogin(string nationalId, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await _context.DashboardUser.Include(u => u.PersonalImage).Include(u => u.Entity).Include(u => u.Role).Include(u => u.Department).FirstOrDefaultAsync(u => u.NationalId.ToLower().Equals(nationalId.ToLower()));
        if (user is null)
        {
            response.Success = false;
            response.Message = "User Not Found... ";
        }

        else if (user.Status == "DisActive")
        {
            response.Success = false;
            response.Message = "User DisActive... ";
        }
        // else if(user.LastLogin)
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong Password...";
            user.LoginAttemp = user.LoginAttemp + 1;
            await _context.SaveChangesAsync();
            if (user.LoginAttemp >= 4)
            {
                response.Success = false;
                response.Message = _magicString.LoginAttimptMessage;
                user.Status = "DisActive";
                await _context.SaveChangesAsync();
            }
        }
        else
        {
            response.Data = CreateDasboiardToken(user);
            user.LastLogin = DateTime.Now.ToString();
            user.LoginAttemp = 0;
            await _context.SaveChangesAsync();
        }
        return response;
    }

    public async Task<ServiceResponse<DashboardUserDto>> DashboardUpdateUser(UpdateDashboardUserDto updateDashboardUser)
    {
        var serviceResponse = new ServiceResponse<DashboardUserDto>();
        try
        {
            var portalUser = await _context.DashboardUser.FirstOrDefaultAsync(z => z.Id == updateDashboardUser.Id);
            if (portalUser is null)
            {
                throw new Exception($"The Id '{updateDashboardUser.Id}'Is Not Founde...");
            }
            CreatePasswordHash(updateDashboardUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            updateDashboardUser.PasswordSalt = passwordSalt;
            updateDashboardUser.PasswordHash = passwordHash;
            _mapper.Map(updateDashboardUser, portalUser);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<DashboardUserDto>(portalUser);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<DashboardUserDto>> DashboardPasswordExpireUpdate(DashboardPasswordExpireUpdateDto updateDashboardUser)
    {
        var serviceResponse = new ServiceResponse<DashboardUserDto>();
        try
        {
            var DashboardUser = await _context.DashboardUser.FirstOrDefaultAsync(z => z.Id == updateDashboardUser.Id);
            if (DashboardUser is null)
            {
                throw new Exception($"The Id '{updateDashboardUser.Id}'Is Not Founde...");
            }
            if (VerifyPasswordHash(updateDashboardUser.Password, DashboardUser.PasswordHash, DashboardUser.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "New Password Must Be Different From Old Password...";
            }
            else
            {

                CreatePasswordHash(updateDashboardUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
                updateDashboardUser.PasswordSalt = passwordSalt;
                updateDashboardUser.PasswordHash = passwordHash;
                updateDashboardUser.PasswordExpires = false;
                _mapper.Map(updateDashboardUser, DashboardUser);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<DashboardUserDto>(DashboardUser);
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<DashboardUserDto>> DashboardPasswordInitialUpdate(DashboardPasswordInitialDto updateDashboardUser)
    {
        var serviceResponse = new ServiceResponse<DashboardUserDto>();
        try
        {
            var DashboardUser = await _context.DashboardUser.FirstOrDefaultAsync(z => z.Id == updateDashboardUser.Id);
            if (DashboardUser is null)
            {
                throw new Exception($"The Id '{updateDashboardUser.Id}'Is Not Founde...");
            }
            if (!VerifyPasswordHash(updateDashboardUser.CurrentPassword, DashboardUser.PasswordHash, DashboardUser.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Current Password Is Not Currect...";
            }
            else
            {

                CreatePasswordHash(updateDashboardUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
                updateDashboardUser.PasswordSalt = passwordSalt;
                updateDashboardUser.PasswordHash = passwordHash;
                updateDashboardUser.IsFirstLogin = false;
                _mapper.Map(updateDashboardUser, DashboardUser);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<DashboardUserDto>(DashboardUser);
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<DashboardUserDto>> DashboardUpdateUserPhone(UpdateDashboardUserPhoneDto updateDashboardUser)
    {
        var serviceResponse = new ServiceResponse<DashboardUserDto>();
        try
        {
            var dashboardUser = await _context.DashboardUser.FirstOrDefaultAsync(z => z.Id == updateDashboardUser.Id);
            if (dashboardUser is null)
            {
                throw new Exception($"The Id '{updateDashboardUser.Id}'Is Not Founde...");
            }
            _mapper.Map(updateDashboardUser, dashboardUser);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<DashboardUserDto>(dashboardUser);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<bool> DashboardUserExists(string username)
    {
        if (await _context.DashboardUser.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
        {
            return true;
        }
        return false;
    }

    public async Task<ServiceResponse<PortalUserDto>> UpdateUserRole(UpdatePortalUserRoleDto updatePortalUser)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        try
        {
            var portalUser = await _context.PortalUser.FirstOrDefaultAsync(z => z.Id == updatePortalUser.Id);
            if (portalUser is null)
            {
                throw new Exception($"The Id '{updatePortalUser.Id}'Is Not Founde...");
            }
            _mapper.Map(updatePortalUser, portalUser);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PortalUserDto>(portalUser);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
