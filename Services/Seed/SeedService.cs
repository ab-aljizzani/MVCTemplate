using System;
using System.Runtime.CompilerServices;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.AppointmentDto.Insert;
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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.Seed;

public class SeedService : ISeedService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IAuthRepositery _auth;

    public SeedService(IMapper mapper, DataContext context, IAuthRepositery auth)
    {
        _auth = auth;
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<string>> DeleteAll()
    {
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

        var fsss7 = FormattableStringFactory.Create("ALTER TABLE SickLeave NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss7);
        var all7 = from c in _context.SickLeave select c;
        _context.SickLeave.RemoveRange(all7);
        var fs7 = FormattableStringFactory.Create("DBCC CHECKIDENT('SickLeave', RESEED, 0)");
        _context.Database.ExecuteSql(fs7);
        var fsss77 = FormattableStringFactory.Create("ALTER TABLE SickLeave CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss77);

        var fss8 = FormattableStringFactory.Create("ALTER TABLE UserSurveyList NOCHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fss8);
        var all8 = from c in _context.UserSurveyList select c;
        _context.UserSurveyList.RemoveRange(all8);
        var fs8 = FormattableStringFactory.Create("DBCC CHECKIDENT('UserSurveyList', RESEED, 0)");
        _context.Database.ExecuteSql(fs8);
        var fsss8 = FormattableStringFactory.Create("ALTER TABLE UserSurveyList CHECK CONSTRAINT all");
        _context.Database.ExecuteSql(fsss8);

        await _context.SaveChangesAsync();
        serviceResponse.Data = "Delete Seed Exicutes Successfuly";
        return serviceResponse;
    }
    public async Task<ServiceResponse<string>> SeedAll()
    {
        var serviceResponse = new ServiceResponse<string>();
        List<InsertRequestStatusDto> newRequestStatus = new List<InsertRequestStatusDto>();
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "انتظار الموافقة", StatusOrder = 1, BadgeColor = "badge rounded-pill bg-dark mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الارسال الى العيادة", StatusOrder = 2, BadgeColor = "badge rounded-pill bg-warning mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم جدولة الطلب", StatusOrder = 3, BadgeColor = "badge rounded-pill bg-success mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الحضور", StatusOrder = 4, BadgeColor = "badge rounded-pill bg-primary mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "لم يحضر", StatusOrder = 5, BadgeColor = "badge rounded-pill bg-danger mx-auto" });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الانتهاء", StatusOrder = 6, BadgeColor = "badge rounded-pill bg-soft-dark mx-auto" });

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
        newZone.Add(new ZoneDto { ZoneName = "الأولى" });
        newZone.Add(new ZoneDto { ZoneName = "الثانية" });
        newZone.Add(new ZoneDto { ZoneName = "الثالثة" });
        // List<InsertSurveyTypeDto> newSurvey = new List<InsertSurveyTypeDto>();
        // newSurvey.Add(new InsertSurveyTypeDto { Type = "لم يتم تعيين نموذج" });
        // newSurvey.Add(new InsertSurveyTypeDto { Type = "نموذج الإفصاح" });
        // newSurvey.Add(new InsertSurveyTypeDto { Type = "نموذج المقياس" });



        // List<InsertSurveyQuestionDto> newSurveyQ = new List<InsertSurveyQuestionDto>();
        // newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل تعاني حاليا أو سبق أن عانيت من مشاكل أو اعراض نفسية أو جسدية قد تشكل تهديدا لسلامتك وسلامة الآخرين", SurveyTypeId = 2 });
        // newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل سبق لك أن إستخدمت مواد محظورة بطريقة أثرت سلبا على سلوكك أو تفكيرك", SurveyTypeId = 2 });
        // newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل سبق لك أن حاولت الإضرار بنفسك أو بغيرك", SurveyTypeId = 2 });
        // newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل تستخدم حاليا أو سبق أن إستخدمت أدوية نفسية", SurveyTypeId = 2 });

        // List<InsertSurveyAnswerDto> newSurveyA = new List<InsertSurveyAnswerDto>();
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 1 });
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 1 });
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 2 });
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 2 });
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 3 });
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 3 });
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 4 });
        // newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 4 });

        // List<AppointmentStatusDto> newAppointmentStatus = new List<AppointmentStatusDto>();
        // newAppointmentStatus.Add(new AppointmentStatusDto { Status = "تمت الجدولة", BadgeColor = "badge rounded-pill bg-success mx-auto" });
        // newAppointmentStatus.Add(new AppointmentStatusDto { Status = "تم الحضور", BadgeColor = "badge rounded-pill bg-primary mx-auto" });
        // newAppointmentStatus.Add(new AppointmentStatusDto { Status = "لم يحضر", BadgeColor = "badge rounded-pill bg-danger mx-auto" });

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
        // foreach (var item in newSurveyA)
        // {
        //     var requestAnswer = _mapper.Map<Models.SurveyModel.SurveyAnswer>(item);
        //     _context.SurveyAnswer.Add(requestAnswer);
        // }

        // foreach (var item in newSurveyQ)
        // {
        //     var requestStatus = _mapper.Map<Models.SurveyModel.SurveyQuestion>(item);
        //     _context.SurveyQuestion.Add(requestStatus);
        // }

        // foreach (var item in newSurvey)
        // {
        //     var survey = _mapper.Map<Models.SurveyModel.SurveyType>(item);
        //     _context.SurveyType.Add(survey);
        // }
        // foreach (var item in newAppointmentStatus)
        // {
        //     var status = _mapper.Map<Models.AppointmentModel.AppointmentStatus>(item);
        //     _context.AppointmentStatus.Add(status);
        // }
        // foreach (var item in newAppointment)
        // {
        //     var appointment = _mapper.Map<Models.AppointmentModel.Appointment>(item);
        //     _context.Appointment.Add(appointment);
        // }

        await _context.SaveChangesAsync();
        serviceResponse.Data = "Seed Exicutes Successfuly";
        return serviceResponse;
    }

    public async Task<ServiceResponse<string>> SeedEntityDept()
    {
        List<AddEntityDto> newEntity = new List<AddEntityDto>();
        newEntity.Add(new AddEntityDto { EntityType = "داخلي", EntityName = "رئاسة الحرس الملكي" });

        List<AddDepartmentDto> newDept = new List<AddDepartmentDto>();
        newDept.Add(new AddDepartmentDto { DepartmentName = "الاتصالات وتقنية المعلومات", EntityId = 1 });
        newDept.Add(new AddDepartmentDto { DepartmentName = "الإدارة الطبية", EntityId = 1 });


        foreach (var item in newEntity)
        {
            var entity = _mapper.Map<Models.Entity.Entity>(item);
            _context.Entity.Add(entity);
        }
        foreach (var item in newDept)
        {
            var dept = _mapper.Map<Models.Entity.Department>(item);
            _context.Department.Add(dept);
        }
        var serviceResponse = new ServiceResponse<string>();
        await _context.SaveChangesAsync();
        serviceResponse.Data = "Seed Exicutes Successfuly";
        return serviceResponse;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
