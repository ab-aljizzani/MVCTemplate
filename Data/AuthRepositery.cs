using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MVCTemplate.Dtos.PortalUserDto;
using MVCTemplate.Dtos.PortalUserModelDto.Insert;
using MVCTemplate.Dtos.PortalUserModelDto.Update;
using MVCTemplate.Models.PortalUser;
using MVCTemplate.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace MVCTemplate.Data;

public class AuthRepositery : IAuthRepositery
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthRepositery(IMapper mapper, DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<string>> Login(string nationalId, string password)
    {
        var _random = new Random();
        var response = new ServiceResponse<string>();
        var user = await _context.PortalUser.Include(u => u.Role).FirstOrDefaultAsync(u => u.NationalId.ToLower().Equals(nationalId.ToLower()));
        if (user is null)
        {
            response.Success = false;
            response.Message = "User Not Found... ";
        }

        // else if (user.Status == "DisActive")
        // {
        //     response.Success = false;
        //     response.Message = "User DisActive... ";
        // }
        // else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        // {
        //     response.Success = false;
        //     response.Message = "Wrong Password...";
        //     user.LoginAttemp = user.LoginAttemp + 1;
        //     await _context.SaveChangesAsync();
        //     if (user.LoginAttemp >= 4)
        //     {
        //         response.Success = false;
        //         response.Message = _magicString.LoginAttimptMessage;
        //         user.Status = "DisActive";
        //         await _context.SaveChangesAsync();
        //     }
        // }
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
    public async Task<ServiceResponse<string>> IamLogin(string nationalId)
    {
        var _random = new Random();
        var response = new ServiceResponse<string>();
        var user = await _context.PortalUser.Include(u => u.Role).FirstOrDefaultAsync(u => u.NationalId.ToLower().Equals(nationalId.ToLower()));
        if (user is null)
        {
            response.Success = false;
            response.Message = "User Not Found... ";
        }
        else
        {
            response.Data = CreateToken(user);
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
            if (userDto.PersonalImgId == 0 || userDto.PersonalImgId == null)
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                var portalDto = _mapper.Map<InsertPortalUserNoPersonalImgDto>(userDto);
                var user = _mapper.Map<PortalUser>(portalDto);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                _context.PortalUser.Add(user);
                await _context.SaveChangesAsync();
                response.Data = userDto.Id;
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
        }
        return response;
    }

    public async Task<ServiceResponse<string>> IamRegister(InsertPortalUserDto userDto)
    {
        var response = new ServiceResponse<string>();
        if (await UserExists(userDto.Username))
        {
            response.Success = false;
            response.Message = "User Already Exists...";
        }
        else
        {
            if (userDto.PersonalImgId == 0 || userDto.PersonalImgId == null)
            {
                CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var portalDto = _mapper.Map<InsertPortalUserNoPersonalImgDto>(userDto);
                var user = _mapper.Map<PortalUser>(portalDto);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                _context.PortalUser.Add(user);
                await _context.SaveChangesAsync();
                var getUser = await _context.PortalUser.Include(u => u.Role).FirstOrDefaultAsync(u => u.NationalId.ToLower().Equals(user.NationalId.ToLower()));
                response.Data = CreateToken(getUser);
            }
            else
            {
                CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = _mapper.Map<PortalUser>(userDto);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                _context.PortalUser.Add(user);
                await _context.SaveChangesAsync();
                var getUser = await _context.PortalUser.Include(u => u.Role).FirstOrDefaultAsync(u => u.NationalId.ToLower().Equals(user.NationalId.ToLower()));
                response.Data = CreateToken(getUser);
            }
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
                // new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim("PortalUserId",user.Id.ToString()),
                new Claim("Username",user.Username),
                new Claim("UserFullName",user.UserFullName.ToString()),
                new Claim("NationalId",user.NationalId),
                new Claim("PhoneNumber",user.PhoneNumber),
                new Claim("Code",user.Code),
                new Claim("UserType",user.UserType.ToString()),
                new Claim("RoleId",user.RoleId.ToString()),
                new Claim("Role",user.Role.RoleName.ToString()),
                new Claim("RoleType",user.Role.Roletype.ToString()),
                new Claim("LastLogin",user.LastLogin.ToString()),
                new Claim("PasswordExpire",user.PasswordExpires.ToString()),
                new Claim("IsFirstLogin",user.IsFirstLogin.ToString()),
                new Claim("Status",user.Status),
                new Claim("image",user.EmpIamImgUrl)
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
        var dbContext = await _context.PortalUser.Include(u => u.Role).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PortalUserDto>(p)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<PortalUserDto>>> GetAllByUserType(string type)
    {
        var serviceResponse = new ServiceResponse<List<PortalUserDto>>();
        var dbContext = await _context.PortalUser.Where(u => u.UserType == type).Include(u => u.Role).ToListAsync();

        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PortalUserDto>(p)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<PortalUserDto>> GetUserByID(int id)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        var dbContext = await _context.PortalUser.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id );

        serviceResponse.Data = _mapper.Map<PortalUserDto>(dbContext);
        return serviceResponse;
    }
    public async Task<ServiceResponse<PortalUserDto>> GetUserByNationalId(string id)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        var dbContext = await _context.PortalUser.Include(u => u.Role).FirstOrDefaultAsync(u => u.NationalId == id );

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

    public async Task<ServiceResponse<PortalUserDto>> UpdateUserRole(UpdatePortalUserRoleDto updatePortalUser)
    {
        var serviceResponse = new ServiceResponse<PortalUserDto>();
        try
        {
            var portalUser = await _context.PortalUser.FirstOrDefaultAsync(z => z.Id == updatePortalUser.Id);
            var OldData = await _context.PortalUser.FirstOrDefaultAsync(e => e.Id == updatePortalUser.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
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
