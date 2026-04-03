
using ClinicApi.Data;
using ClinicApi.Services;
using ClinicApi.Services.AppointmentReviewServices;
using ClinicApi.Services.AppointmentServices;
using ClinicApi.Services.AuditServices;
using ClinicApi.Services.AuthorizeServices;
using ClinicApi.Services.AuthorizeServices.Rules;
using ClinicApi.Services.CountriesServices;
using ClinicApi.Services.DoctorAvailbleTimeServices;
using ClinicApi.Services.Entity;
using ClinicApi.Services.PersonalImagesServices;
using ClinicApi.Services.PersonServices;
using ClinicApi.Services.Request;
using ClinicApi.Services.RiskLevelServices;
using ClinicApi.Services.RoleServices;
using ClinicApi.Services.Seed;
using ClinicApi.Services.SickLeaveServices;
using ClinicApi.Services.Survey;
using ClinicApi.Services.ZoneServices;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ClinicApi
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
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IEntityService, EntityService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAuthRepositery, AuthRepositery>();
            builder.Services.AddScoped<IZoneSerice, ZoneService>();
            builder.Services.AddScoped<IPersonalImages, PersonalImages>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<ISurveyService, SurveyService>();
            builder.Services.AddScoped<ISeedService, SeedService>();
            builder.Services.AddScoped<IAuditService, AuditService>();
            builder.Services.AddScoped<IDoctorAvailbleTimeService, DoctorAvailbleTimeService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IAppointmentReviewService, AppointmentReviewService>();
            builder.Services.AddScoped<IRiskLevelService, RiskLevelService>();
            builder.Services.AddScoped<ISickLeaveService, SickLeaveService>();
            builder.Services.AddScoped<ICountriesService, CountriesService>();
            builder.Services.AddScoped<IAuthorizeService, AuthorizeService>();
            builder.Services.AddScoped<MagicString>();
            builder.Services.AddScoped<TokenRoles>();
            builder.Services.AddSingleton<IAuthorizeService>(sp =>
            {
                var service = new AuthorizeService();

                service.AddRule(new EntityExternalOnlyRule());
                service.AddRule(new DepartmentOfficerRule());
                service.AddRule(new PortalRolesRule());

                return service;
            });

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