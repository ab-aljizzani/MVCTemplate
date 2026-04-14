using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MVCTemplate.Data;
using MVCTemplate.Services;
using MVCTemplate.Services.AuditServices;
using MVCTemplate.Services.AuthorizeServices;
using MVCTemplate.Services.CountriesServices;
using MVCTemplate.Services.RoleServices;
using MVCTemplate.Services.Seed;
using Swashbuckle.AspNetCore.Filters;

namespace MVCTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // var ClientAppURL = builder.Configuration.GetSection("ClientAppURL")?.GetChildren()?.Select(x => x.Value)?.ToList();

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAuthRepositery, AuthRepositery>();
            builder.Services.AddScoped<ISeedService, SeedService>();
            builder.Services.AddScoped<IAuditService, AuditService>();
            builder.Services.AddScoped<ICountriesService, CountriesService>();
            builder.Services.AddScoped<TokenRoles>();
            builder.Services.AddScoped<IAuthorizeService, AuthorizeService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );



            builder.Services.AddCors();
            builder.Services.AddHttpContextAccessor();

            //             builder.Services.AddCors(p =>
            // {
            //     p.AddPolicy("CORSPolicy", builder =>
            //     {
            //         builder.WithOrigins(ClientAppURL.ToArray())
            //     .WithMethods("POST", "GET")
            //     .AllowAnyHeader()
            //     .AllowCredentials();
            //     });
            // });

            builder.Services.AddAntiforgery(options =>
                  {
                      options.HeaderName = "X-XSRF-TOKEN";
                      options.Cookie.HttpOnly = true;
                      //options.Cookie.Domain = ClientAppURL;
                      options.Cookie.SameSite = SameSiteMode.Strict;
                      //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                      options.SuppressXFrameOptionsHeader = false;
                  });

            // Configure the HTTP request pipeline.
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            }
            else
            {
                var corsConfig = builder.Configuration.GetSection("CorsConfig");
                var allowedOrigins = corsConfig.GetSection("AllwedOrigins").Get<string[]>();
                app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().WithOrigins(allowedOrigins));
            }



            app.UseAuthorization();
            app.MapControllers();
            // app.UseCors("CORSPolicy");
            app.Run();
        }
    }
}