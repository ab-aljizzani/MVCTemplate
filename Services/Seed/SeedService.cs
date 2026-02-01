using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.AppointmentDto.Insert;
using ClinicApi.Dtos.CountriesDto.Get;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.PortalUserModelDto.Insert;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RiskLevelDto.Insert;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Models.AuditsModel;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Reponse;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.Seed;

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

        var RequestType = FormattableStringFactory.Create("ALTER TABLE RequestType NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(RequestType);
        var RequestType_reseed = from c in _context.RequestType select c;
        _context.RequestType.RemoveRange(RequestType_reseed);
        var RequestType_ = FormattableStringFactory.Create("DBCC CHECKIDENT('RequestType', RESEED, 0)");
        _context.Database.ExecuteSql(RequestType_);
        var RequestType_check = FormattableStringFactory.Create("ALTER TABLE RequestType CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(RequestType_check);

        var RequestStatus = FormattableStringFactory.Create("ALTER TABLE RequestStatus NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(RequestStatus);
        var RequestStatus_reseed = from c in _context.RequestStatus select c;
        _context.RequestStatus.RemoveRange(RequestStatus_reseed);
        var RequestStatus_ = FormattableStringFactory.Create("DBCC CHECKIDENT('RequestStatus', RESEED, 0)");
        _context.Database.ExecuteSql(RequestStatus_);
        var RequestStatus_check = FormattableStringFactory.Create("ALTER TABLE RequestStatus CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(RequestStatus_check);

        var Role = FormattableStringFactory.Create("ALTER TABLE Role NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Role);
        var Role_reseed = from c in _context.Role select c;
        _context.Role.RemoveRange(Role_reseed);
        var Role_ = FormattableStringFactory.Create("DBCC CHECKIDENT('Role', RESEED, 0)");
        _context.Database.ExecuteSql(Role_);
        var Role_check = FormattableStringFactory.Create("ALTER TABLE Role CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Role_check);

        var Entity = FormattableStringFactory.Create("ALTER TABLE Entity NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Entity);
        var Entity_reseed = from c in _context.Entity select c;
        _context.Entity.RemoveRange(Entity_reseed);
        var Entity_ = FormattableStringFactory.Create("DBCC CHECKIDENT('[Entity]', RESEED, 0)");
        _context.Database.ExecuteSql(Entity_);
        var Entity_check = FormattableStringFactory.Create("ALTER TABLE Entity CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Entity_check);

        var Department = FormattableStringFactory.Create("ALTER TABLE Department NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Department);
        var Department_reseed = from c in _context.Department select c;
        _context.Department.RemoveRange(Department_reseed);
        var Department_ = FormattableStringFactory.Create("DBCC CHECKIDENT('[Department]', RESEED, 0)");
        _context.Database.ExecuteSql(Department_);
        var Department_check = FormattableStringFactory.Create("ALTER TABLE Department CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Department_check);

        var Zone = FormattableStringFactory.Create("ALTER TABLE Zone NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Zone);
        var Zone_reseed = from c in _context.Zone select c;
        _context.Zone.RemoveRange(Zone_reseed);
        var Zone_ = FormattableStringFactory.Create("DBCC CHECKIDENT('Zone', RESEED, 0)");
        _context.Database.ExecuteSql(Zone_);
        var Zone_check = FormattableStringFactory.Create("ALTER TABLE Zone CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Zone_check);

        var Perscription = FormattableStringFactory.Create("ALTER TABLE Perscription NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Perscription);
        var Perscription_reseed = from c in _context.Perscription select c;
        _context.Perscription.RemoveRange(Perscription_reseed);
        var Perscription_ = FormattableStringFactory.Create("DBCC CHECKIDENT('Perscription', RESEED, 0)");
        _context.Database.ExecuteSql(Perscription_);
        var Perscription_check = FormattableStringFactory.Create("ALTER TABLE Perscription CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(Perscription_check);

        var RiskLevel = FormattableStringFactory.Create("ALTER TABLE RiskLevel NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(RiskLevel);
        var RiskLevel_reseed = from c in _context.RiskLevel select c;
        _context.RiskLevel.RemoveRange(RiskLevel_reseed);
        var RiskLevel_ = FormattableStringFactory.Create("DBCC CHECKIDENT('RiskLevel', RESEED, 0)");
        _context.Database.ExecuteSql(RiskLevel_);
        var RiskLevel_check = FormattableStringFactory.Create("ALTER TABLE RiskLevel CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(RiskLevel_check);


        var fss1 = FormattableStringFactory.Create("ALTER TABLE Request NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss1);
        var all1 = from c in _context.Request select c;
        _context.Request.RemoveRange(all1);
        var fs1 = FormattableStringFactory.Create("DBCC CHECKIDENT('Request', RESEED, 0)");
        _context.Database.ExecuteSql(fs1);
        var fsss1 = FormattableStringFactory.Create("ALTER TABLE Request CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss1);

        var fss2 = FormattableStringFactory.Create("ALTER TABLE Appointment NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss2);
        var all2 = from c in _context.Appointment select c;
        _context.Appointment.RemoveRange(all2);
        var fs2 = FormattableStringFactory.Create("DBCC CHECKIDENT('Appointment', RESEED, 0)");
        _context.Database.ExecuteSql(fs2);
        var fsss2 = FormattableStringFactory.Create("ALTER TABLE Appointment CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss2);

        var fss3 = FormattableStringFactory.Create("ALTER TABLE AppointmentReview NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss3);
        var all3 = from c in _context.AppointmentReview select c;
        _context.AppointmentReview.RemoveRange(all3);
        var fs3 = FormattableStringFactory.Create("DBCC CHECKIDENT('AppointmentReview', RESEED, 0)");
        _context.Database.ExecuteSql(fs3);
        var fsss3 = FormattableStringFactory.Create("ALTER TABLE AppointmentReview CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss3);

        var fsss7 = FormattableStringFactory.Create("ALTER TABLE SickLeave NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss7);
        var all7 = from c in _context.SickLeave select c;
        _context.SickLeave.RemoveRange(all7);
        var fs7 = FormattableStringFactory.Create("DBCC CHECKIDENT('SickLeave', RESEED, 0)");
        _context.Database.ExecuteSql(fs7);
        var fsss77 = FormattableStringFactory.Create("ALTER TABLE SickLeave CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss77);

        var fss4 = FormattableStringFactory.Create("ALTER TABLE Person NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss4);
        var all4 = from c in _context.Person select c;
        _context.Person.RemoveRange(all4);
        var fs4 = FormattableStringFactory.Create("DBCC CHECKIDENT('Person', RESEED, 0)");
        _context.Database.ExecuteSql(fs4);
        var fsss4 = FormattableStringFactory.Create("ALTER TABLE Person CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss4);

        var fss5 = FormattableStringFactory.Create("ALTER TABLE UserSurveyAnswer NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss5);
        var all5 = from c in _context.UserSurveyAnswer select c;
        _context.UserSurveyAnswer.RemoveRange(all5);
        var fs5 = FormattableStringFactory.Create("DBCC CHECKIDENT('UserSurveyAnswer', RESEED, 0)");
        _context.Database.ExecuteSql(fs5);
        var fsss5 = FormattableStringFactory.Create("ALTER TABLE UserSurveyAnswer CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss5);

        var fss6 = FormattableStringFactory.Create("ALTER TABLE UserSurveyAnswerTimes NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss6);
        var all6 = from c in _context.UserSurveyAnswerTimes select c;
        _context.UserSurveyAnswerTimes.RemoveRange(all6);
        var fs6 = FormattableStringFactory.Create("DBCC CHECKIDENT('UserSurveyAnswerTimes', RESEED, 0)");
        _context.Database.ExecuteSql(fs6);
        var fsss6 = FormattableStringFactory.Create("ALTER TABLE UserSurveyAnswerTimes CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss6);


        var fss8 = FormattableStringFactory.Create("ALTER TABLE UserSurveyList NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss8);
        var all8 = from c in _context.UserSurveyList select c;
        _context.UserSurveyList.RemoveRange(all8);
        var fs8 = FormattableStringFactory.Create("DBCC CHECKIDENT('UserSurveyList', RESEED, 0)");
        _context.Database.ExecuteSql(fs8);
        var fsss8 = FormattableStringFactory.Create("ALTER TABLE UserSurveyList CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss8);

        var fss9 = FormattableStringFactory.Create("ALTER TABLE SurveyType NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss9);
        var all9 = from c in _context.SurveyType select c;
        _context.SurveyType.RemoveRange(all9);
        var fs9 = FormattableStringFactory.Create("DBCC CHECKIDENT('SurveyType', RESEED, 0)");
        _context.Database.ExecuteSql(fs9);
        var fsss9 = FormattableStringFactory.Create("ALTER TABLE SurveyType CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss9);

        var fss10 = FormattableStringFactory.Create("ALTER TABLE SurveyQuestion NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss10);
        var all10 = from c in _context.SurveyQuestion select c;
        _context.SurveyQuestion.RemoveRange(all10);
        var fs10 = FormattableStringFactory.Create("DBCC CHECKIDENT('SurveyQuestion', RESEED, 0)");
        _context.Database.ExecuteSql(fs10);
        var fs110 = FormattableStringFactory.Create("Delete from SurveyQuestion ");
        _context.Database.ExecuteSql(fs110);
        var fsss10 = FormattableStringFactory.Create("ALTER TABLE SurveyQuestion CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss10);


        var fss11 = FormattableStringFactory.Create("ALTER TABLE SurveyAnswer NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss11);
        var all11 = from c in _context.SurveyAnswer select c;
        _context.SurveyAnswer.RemoveRange(all11);
        var fs11 = FormattableStringFactory.Create("DBCC CHECKIDENT('SurveyAnswer', RESEED, 0)");
        _context.Database.ExecuteSql(fs11);
        var fs111 = FormattableStringFactory.Create("Delete from SurveyAnswer");
        _context.Database.ExecuteSql(fs111);
        var fsss11 = FormattableStringFactory.Create("ALTER TABLE SurveyAnswer CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss11);

        var fss12 = FormattableStringFactory.Create("ALTER TABLE Countries NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss12);
        var all12 = from c in _context.SurveyType select c;
        _context.SurveyType.RemoveRange(all9);
        var fs12 = FormattableStringFactory.Create("DBCC CHECKIDENT('Countries', RESEED, 0)");
        _context.Database.ExecuteSql(fs12);
        var fsss12 = FormattableStringFactory.Create("ALTER TABLE Countries CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss12);

        await _context.SaveChangesAsync();
        serviceResponse.Data = "Delete Seed Exicutes Successfuly";
        return serviceResponse;
    }
    public async Task<ServiceResponse<string>> SeedAll()
    {
        if (!_config.GetValue<bool>("Seed:Enabled"))
            return new ServiceResponse<string> { Success = false, Message = "Seeding is disabled (Seed:Enabled=false)." };
        var serviceResponse = new ServiceResponse<string>();
        List<InsertRequestStatusDto> newRequestStatus = new List<InsertRequestStatusDto>();
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "انتظار الموافقة", StatusOrder = 1, BadgeColor = "badge rounded-pill bg-dark mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الارسال الى العيادة", StatusOrder = 2, BadgeColor = "badge rounded-pill bg-warning mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم جدولة الطلب", StatusOrder = 3, BadgeColor = "badge rounded-pill bg-success mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الحضور", StatusOrder = 4, BadgeColor = "badge rounded-pill bg-primary mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "لم يحضر", StatusOrder = 5, BadgeColor = "badge rounded-pill bg-danger mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الانتهاء", StatusOrder = 6, BadgeColor = "badge rounded-pill bg-soft-dark mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "بحاجة لتقييم الطبيب", StatusOrder = 7, BadgeColor = "badge rounded-pill bg-dark mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "إنتظار تقرير العمل", StatusOrder = 8, BadgeColor = "badge rounded-pill bg-dark mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم وصول تقرير العمل", StatusOrder = 9, BadgeColor = "badge rounded-pill bg-dark mx-auto" });

        List<InsertRequestTypeDto> newRequestType = new List<InsertRequestTypeDto>();
        newRequestType.Add(new InsertRequestTypeDto { Type = "داخلي من الإدارة", BadgeColor = "badge rounded-pill bg-primary mx-auto" });
        newRequestType.Add(new InsertRequestTypeDto { Type = "خارجي من العيادة", BadgeColor = "badge rounded-pill bg-success mx-auto" });


        List<RoleDto> newRole = new List<RoleDto>();
        newRole.Add(new RoleDto { RoleName = "SuperAdmin", RoleArabName = "مدير كامل النظام", Roletype = "Both" });
        newRole.Add(new RoleDto { RoleName = "Admin", RoleArabName = "مدير النظام", Roletype = "Both" });
        newRole.Add(new RoleDto { RoleName = "EntityContact", RoleArabName = "ضابط اتصال", Roletype = "Portal" });
        newRole.Add(new RoleDto { RoleName = "DeptAdmin", RoleArabName = "مدير ادارة", Roletype = "Portal" });
        newRole.Add(new RoleDto { RoleName = "DeptEditor", RoleArabName = "مدخل بيانات الادارة", Roletype = "Portal" });
        newRole.Add(new RoleDto { RoleName = "Reception", RoleArabName = "استقبال", Roletype = "Dash" });
        newRole.Add(new RoleDto { RoleName = "Doctor", RoleArabName = "طبيب", Roletype = "Dash" });
        newRole.Add(new RoleDto { RoleName = "Person", RoleArabName = "شخص", Roletype = "Both" });
        newRole.Add(new RoleDto { RoleName = "Specialist", RoleArabName = "اخصائي", Roletype = "Dash" });

        List<ZoneDto> newZone = new List<ZoneDto>();
        newZone.Add(new ZoneDto { ZoneName = "قريب" });
        newZone.Add(new ZoneDto { ZoneName = "متوسط" });
        newZone.Add(new ZoneDto { ZoneName = "بعيد" });


        List<AppointmentStatusDto> newAppointmentStatus = new List<AppointmentStatusDto>();
        newAppointmentStatus.Add(new AppointmentStatusDto { Status = "تمت الجدولة", BadgeColor = "badge rounded-pill bg-success mx-auto" });
        newAppointmentStatus.Add(new AppointmentStatusDto { Status = "تم الحضور", BadgeColor = "badge rounded-pill bg-primary mx-auto" });
        newAppointmentStatus.Add(new AppointmentStatusDto { Status = "لم يحضر", BadgeColor = "badge rounded-pill bg-danger mx-auto" });

        List<PerscritionDto> newPerscrition = new List<PerscritionDto>();
        newPerscrition.Add(new PerscritionDto { PerscriptionName = "بدون وصفة طبية" });

        // List<InsertAppointmentDto> newAppointment = new List<InsertAppointmentDto>();
        // newAppointment.Add(new InsertAppointmentDto
        // {
        //     PortalUserId = 2,
        //     // SurveyTypeId = 1,
        //     PerscriptionId = 1,
        //     IsPersonShowUp = false,
        //     // IsSurveyInserted = false,
        //     ApponitmentDate = "--",
        //     AppointmentStartTime = "--" + ":" + "--",
        //     AppointmentEndTime = "--" + ":" + "--",
        //     AppointmentReview = "--",
        //     AppointmentDay = "--",
        //     RiskLevelId = 1
        // });
        List<InsertRiskLevelDto> newRiskLevel = new List<InsertRiskLevelDto>();
        newRiskLevel.Add(new InsertRiskLevelDto { Risk = "لا يوجد خطر" });
        newRiskLevel.Add(new InsertRiskLevelDto { Risk = "منخفض" });
        newRiskLevel.Add(new InsertRiskLevelDto { Risk = "متوسط" });
        newRiskLevel.Add(new InsertRiskLevelDto { Risk = "عالي" });



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
            EntityId = 1,
            DepartmentId = 1,
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
            EntityId = 1,
            DepartmentId = 1,
            RoleId = 1,
            EmpIamImgUrl = "",
            IsFirstLogin = false,
            IsFromShamel = false
        });
        newPortalUser.Add(new InsertPortalUserNoPersonalImgDto
        {
            Username = "1234567891",
            NationalId = "1234567891",
            Password = "Aa@123456#",
            ConfirmPassword = "Aa@123456#",
            UserFullName = "Test Test Test",
            Email = "bbb@b.com",
            Code = "0000",
            PhoneNumber = "0555555555",
            DateOfBirth = "01/02/1990",
            UserType = "رئيسي",
            LoginAttemp = 0,
            LastLogin = DateTime.Now.ToString(),
            CreatedDate = DateTime.Now.ToString(),
            PasswordExpires = false,
            Status = "Active",
            EntityId = 1,
            DepartmentId = 1,
            RoleId = 7,
            EmpIamImgUrl = "",
            IsFirstLogin = false,
            IsFromShamel = false
        });
        newPortalUser.Add(new InsertPortalUserNoPersonalImgDto
        {
            Username = "1234567892",
            NationalId = "1234567892",
            Password = "Aa@123456#",
            ConfirmPassword = "Aa@123456#",
            UserFullName = "Test Test Test",
            Email = "bbbb@b.com",
            Code = "0000",
            PhoneNumber = "0555555555",
            DateOfBirth = "01/02/1990",
            UserType = "رئيسي",
            LoginAttemp = 0,
            LastLogin = DateTime.Now.ToString(),
            CreatedDate = DateTime.Now.ToString(),
            PasswordExpires = false,
            Status = "Active",
            EntityId = 1,
            DepartmentId = 1,
            RoleId = 9,
            EmpIamImgUrl = "",
            IsFirstLogin = false,
            IsFromShamel = false
        });

        List<AddDepartmentDto> newDept = new List<AddDepartmentDto>();
        newDept.Add(new AddDepartmentDto { DepartmentName = "الاتصالات وتقنية المعلومات", EntityId = 1 });
        newDept.Add(new AddDepartmentDto { DepartmentName = "الإدارة الطبية", EntityId = 1 });

        foreach (var item in newDept)
        {
            var dept = _mapper.Map<Models.Entity.Department>(item);
            _context.Department.Add(dept);
        }

        foreach (var item in newRequestType)
        {
            var requestType = _mapper.Map<Models.RequestTypeModel.RequestType>(item);
            _context.RequestType.Add(requestType);
        }

        foreach (var item in newPortalUser)
        {
            CreatePasswordHash(item.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<PortalUser>(item);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _context.PortalUser.Add(user);
        }


        foreach (var item in newRequestStatus)
        {
            var requestStatus = _mapper.Map<Models.RequestModel.RequestStatus>(item);
            _context.RequestStatus.Add(requestStatus);
        }

        foreach (var item in newRole)
        {
            var role = _mapper.Map<Models.Role.Role>(item);
            _context.Role.Add(role);
        }
        foreach (var item in newZone)
        {
            var zone = _mapper.Map<Models.ZoneModel.Zone>(item);
            _context.Zone.Add(zone);
        }
        foreach (var item in newPerscrition)
        {
            var perscription = _mapper.Map<Models.AppointmentModel.Perscription>(item);
            _context.Perscription.Add(perscription);
        }
        foreach (var item in newRiskLevel)
        {
            var risk = _mapper.Map<Models.RiskLevelModel.RiskLevel>(item);
            _context.RiskLevel.Add(risk);
        }

        foreach (var item in newAppointmentStatus)
        {
            var status = _mapper.Map<Models.AppointmentModel.AppointmentStatus>(item);
            _context.AppointmentStatus.Add(status);
        }


        await _context.SaveChangesAsync();
        serviceResponse.Data = "Seed Exicutes Successfuly";
        return serviceResponse;
    }

    public async Task<ServiceResponse<string>> SeedEntityDept()
    {
        if (!_config.GetValue<bool>("Seed:Enabled"))
            return new ServiceResponse<string> { Success = false, Message = "Seeding is disabled (Seed:Enabled=false)." };

        List<AddEntityDto> newEntity = new List<AddEntityDto>();
        newEntity.Add(new AddEntityDto { EntityType = "داخلي", EntityName = "رئاسة الحرس الملكي" });



        foreach (var item in newEntity)
        {
            var entity = _mapper.Map<Models.Entity.Entity>(item);
            _context.Entity.Add(entity);
        }

        await SeedCuntriesFromExcel();
        await SeedSurveysFromExcel();
        var serviceResponse = new ServiceResponse<string>();
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
        }
        else
        {
            throw new FileNotFoundException($"Countries Excel file not found at: {excelPath}");
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

            // Default backup path (SQL Server default backup directory)
            var backupPath = Path.Combine(@"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup", backupFileName);

            // Create backup
            var backupQuery = $"BACKUP DATABASE [{databaseName}] TO DISK = '{backupPath}' WITH FORMAT, INIT, NAME = '{databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
            await _context.Database.ExecuteSqlRawAsync(backupQuery);

            serviceResponse.Message = $"Database backup created successfully at: {backupPath}";

            // Set database to single user mode to close all connections
            var singleUserQuery = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            await _context.Database.ExecuteSqlRawAsync(singleUserQuery);

            // Close the current connection from this context
            await _context.Database.CloseConnectionAsync();

            // Build a new connection string to the master database
            var masterConnectionString = ChangeDatabaseInConnectionString(connectionString, "master");

            // Drop the database using a new connection to master
            using (var sqlConnection = new Microsoft.Data.SqlClient.SqlConnection(masterConnectionString))
            {
                await sqlConnection.OpenAsync();
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
            var connectionString = _context.Database.GetConnectionString();
            var databaseName = GetDatabaseNameFromConnectionString(connectionString);
            var singleUserQuery = $"ALTER DATABASE [{databaseName}] SET MULTI_USER";
            await _context.Database.ExecuteSqlRawAsync(singleUserQuery);
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

            // Default backup path (SQL Server default backup directory)
            var backupPath = Path.Combine(@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup", backupFileName);

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

    public async Task<ServiceResponse<string>> SeedSurveysFromExcel()
    {
        var excelPath = Path.Combine(_env.ContentRootPath, "Surveys.xlsx");
        if (!File.Exists(excelPath))
        {
            excelPath = Path.Combine(_env.WebRootPath, "Surveys.xlsx");
        }
        else
        {
            throw new FileNotFoundException($"Surveys Excel file not found at: {excelPath}");
        }

        var newSurveyTypes = new List<InsertSurveyTypeDto>();
        var newSurveyQuestions = new List<InsertSurveyQuestionDto>();
        var newSurveyAnswers = new List<InsertSurveyAnswerDto>();

        using (var workbook = new XLWorkbook(excelPath))
        {
            // Sheet: Types -> SurveyType
            var typesSheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name.Equals("Types", StringComparison.OrdinalIgnoreCase));
            if (typesSheet != null)
            {
                var usedRange = typesSheet.RangeUsed();
                if (usedRange != null)
                {
                    var header = usedRange.FirstRowUsed();
                    var headers = header.Cells().Select((c, i) => new { Name = c.GetString().Trim(), Index = i + 1 }).ToList();

                    int typeCol = headers.FirstOrDefault(h => h.Name.Equals("Type", StringComparison.OrdinalIgnoreCase))?.Index ?? 1;
                    int engTypeCol = headers.FirstOrDefault(h => h.Name.Equals("EngType", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;
                    int typeRoleCol = headers.FirstOrDefault(h => h.Name.Equals("TypeRole", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;

                    foreach (var row in usedRange.RowsUsed().Skip(1))
                    {
                        var dto = new InsertSurveyTypeDto
                        {
                            Type = row.Cell(typeCol).GetString().Trim(),
                            EngType = engTypeCol > 0 ? row.Cell(engTypeCol).GetString().Trim() : null,
                            TypeRole = typeRoleCol > 0 ? row.Cell(typeRoleCol).GetString().Trim() : null
                        };
                        if (!string.IsNullOrWhiteSpace(dto.Type))
                            newSurveyTypes.Add(dto);
                    }
                }
            }

            // Sheet: Questions -> SurveyQuestion
            var questionsSheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name.Equals("Questions", StringComparison.OrdinalIgnoreCase));
            if (questionsSheet != null)
            {
                var usedRange = questionsSheet.RangeUsed();
                if (usedRange != null)
                {
                    var header = usedRange.FirstRowUsed();
                    var headers = header.Cells().Select((c, i) => new { Name = c.GetString().Trim(), Index = i + 1 }).ToList();

                    int questionCol = headers.FirstOrDefault(h => h.Name.Equals("Question", StringComparison.OrdinalIgnoreCase))?.Index ?? 1;
                    int surveyTypeIdCol = headers.FirstOrDefault(h => h.Name.Equals("SurveyTypeId", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;
                    int questionEngCol = headers.FirstOrDefault(h => h.Name.Equals("QuestionEng", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;
                    int orderCol = headers.FirstOrDefault(h => h.Name.Equals("QuestionOrderNumber", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;

                    foreach (var row in usedRange.RowsUsed().Skip(1))
                    {
                        var dto = new InsertSurveyQuestionDto
                        {
                            Question = row.Cell(questionCol).GetString().Trim(),
                            SurveyTypeId = surveyTypeIdCol > 0 ? row.Cell(surveyTypeIdCol).GetValue<int>() : 0,
                            QuestionEng = questionEngCol > 0 ? row.Cell(questionEngCol).GetString().Trim() : null,
                            QuestionOrderNumber = orderCol > 0 ? row.Cell(orderCol).GetValue<int>().ToString() : ""
                        };
                        if (!string.IsNullOrWhiteSpace(dto.Question))
                            newSurveyQuestions.Add(dto);
                    }
                }
            }

            // Sheet: Answers -> SurveyAnswer
            var answersSheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name.Equals("Answers", StringComparison.OrdinalIgnoreCase));
            if (answersSheet != null)
            {
                var usedRange = answersSheet.RangeUsed();
                if (usedRange != null)
                {
                    var header = usedRange.FirstRowUsed();
                    var headers = header.Cells().Select((c, i) => new { Name = c.GetString().Trim(), Index = i + 1 }).ToList();

                    int answerCol = headers.FirstOrDefault(h => h.Name.Equals("Answer", StringComparison.OrdinalIgnoreCase))?.Index ?? 1;
                    int surveyQuestionIdCol = headers.FirstOrDefault(h => h.Name.Equals("SurveyQuestionId", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;
                    int answerPointCol = headers.FirstOrDefault(h => h.Name.Equals("AnswerPoint", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;
                    int answerEngCol = headers.FirstOrDefault(h => h.Name.Equals("AnswerEng", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;

                    foreach (var row in usedRange.RowsUsed().Skip(1))
                    {
                        var dto = new InsertSurveyAnswerDto
                        {
                            Answer = row.Cell(answerCol).GetString().Trim(),
                            SurveyQuestionId = surveyQuestionIdCol > 0 ? row.Cell(surveyQuestionIdCol).GetValue<int>() : 0,
                            AnswerPoint = answerPointCol > 0 ? row.Cell(answerPointCol).GetValue<int>().ToString().ToString() : "",
                            AnswerEng = answerEngCol > 0 ? row.Cell(answerEngCol).GetString().Trim() : null
                        };
                        if (!string.IsNullOrWhiteSpace(dto.Answer))
                            newSurveyAnswers.Add(dto);
                    }
                }
            }
        }

        // Insert SurveyTypes
        foreach (var dto in newSurveyTypes)
        {
            var entity = _mapper.Map<Models.SurveyModel.SurveyType>(dto);
            _context.SurveyType.Add(entity);
        }

        // Insert SurveyQuestions
        foreach (var dto in newSurveyQuestions)
        {
            var entity = _mapper.Map<Models.SurveyModel.SurveyQuestion>(dto);
            _context.SurveyQuestion.Add(entity);
        }

        // Insert SurveyAnswers
        foreach (var dto in newSurveyAnswers)
        {
            var entity = _mapper.Map<Models.SurveyModel.SurveyAnswer>(dto);
            _context.SurveyAnswer.Add(entity);
        }

        await _context.SaveChangesAsync();

        return new ServiceResponse<string>
        {
            Data = $"Seeded {newSurveyTypes.Count} survey types, {newSurveyQuestions.Count} questions, {newSurveyAnswers.Count} answers from Excel."
        };
    }
}
