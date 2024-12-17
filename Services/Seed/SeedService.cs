using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.PortalUserModelDto.Insert;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Models.AuditsModel;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Reponse;
using Microsoft.AspNetCore.Http.HttpResults;

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
    public async Task<ServiceResponse<string>> SeedAll()
    {
        var serviceResponse = new ServiceResponse<string>();
        List<InsertRequestStatusDto> newRequestStatus = new List<InsertRequestStatusDto>();
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "انتظار الموافقة", StatusOrder = 1 });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الارسال الى العيادة", StatusOrder = 2 });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم جدولة الطلب", StatusOrder = 3 });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الحضور", StatusOrder = 4 });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "لم يحضر", StatusOrder = 5 });
        newRequestStatus.Add(new InsertRequestStatusDto { Status = "تم الانتهاء", StatusOrder = 6 });

        List<InsertRequestTypeDto> newRequestType = new List<InsertRequestTypeDto>();
        newRequestType.Add(new InsertRequestTypeDto { Type = "داخلي من الإدارة" });
        newRequestType.Add(new InsertRequestTypeDto { Type = "خارجي من العيادة" });


        List<RoleDto> newRole = new List<RoleDto>();
        newRole.Add(new RoleDto { RoleName = "SuperAdmin", RoleArabName = "مدير كامل النظام", Roletype = "Both" });
        newRole.Add(new RoleDto { RoleName = "Admin", RoleArabName = "مدير النظام", Roletype = "Both" });
        newRole.Add(new RoleDto { RoleName = "EntityContact", RoleArabName = "ضابط اتصال", Roletype = "Portal" });
        newRole.Add(new RoleDto { RoleName = "DeptAdmin", RoleArabName = "مدير ادارة", Roletype = "Portal" });
        newRole.Add(new RoleDto { RoleName = "DeptEditor", RoleArabName = "مدخل بيانات الادارة", Roletype = "Portal" });
        newRole.Add(new RoleDto { RoleName = "Reception", RoleArabName = "استقبال", Roletype = "Dash" });
        newRole.Add(new RoleDto { RoleName = "Doctor", RoleArabName = "طبيب", Roletype = "Dash" });

        List<ZoneDto> newZone = new List<ZoneDto>();
        newZone.Add(new ZoneDto { ZoneName = "الأولى" });
        newZone.Add(new ZoneDto { ZoneName = "الثانية" });
        newZone.Add(new ZoneDto { ZoneName = "الثالثة" });
        List<InsertSurveyTypeDto> newSurvey = new List<InsertSurveyTypeDto>();
        newSurvey.Add(new InsertSurveyTypeDto { Type = "لم يتم تعيين نموذج" });
        newSurvey.Add(new InsertSurveyTypeDto { Type = "نموذج الإفصاح" });
        newSurvey.Add(new InsertSurveyTypeDto { Type = "نموذج المقياس" });

        List<AddEntityDto> newEntity = new List<AddEntityDto>();
        newEntity.Add(new AddEntityDto { EntityType = "داخلي", EntityName = "رئاسة الحرس الملكي" });

        List<AddDepartmentDto> newDept = new List<AddDepartmentDto>();
        newDept.Add(new AddDepartmentDto { DepartmentName = "الاتصالات وتقنية المعلومات", EntityId = 1 });

        List<InsertSurveyQuestionDto> newSurveyQ = new List<InsertSurveyQuestionDto>();
        newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل تعاني حاليا أو سبق أن عانيت من مشاكل أو اعراض نفسية أو جسدية قد تشكل تهديدا لسلامتك وسلامة الآخرين", SurveyTypeId = 2 });
        newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل سبق لك أن إستخدمت مواد محظورة بطريقة أثرت سلبا على سلوكك أو تفكيرك", SurveyTypeId = 2 });
        newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل سبق لك أن حاولت الإضرار بنفسك أو بغيرك", SurveyTypeId = 2 });
        newSurveyQ.Add(new InsertSurveyQuestionDto { Question = "هل تستخدم حاليا أو سبق أن إستخدمت أدوية نفسية", SurveyTypeId = 2 });

        List<InsertSurveyAnswerDto> newSurveyA = new List<InsertSurveyAnswerDto>();
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 1 });
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 1 });
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 2 });
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 2 });
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 3 });
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 3 });
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "نعم", SurveyQuestionId = 4 });
        newSurveyA.Add(new InsertSurveyAnswerDto { Answer = "لا", SurveyQuestionId = 4 });

        List<AppointmentStatusDto> newAppointmentStatus = new List<AppointmentStatusDto>();
        newAppointmentStatus.Add(new AppointmentStatusDto { Status = "تمت الجدولة" });
        newAppointmentStatus.Add(new AppointmentStatusDto { Status = "تم الحضور" });
        newAppointmentStatus.Add(new AppointmentStatusDto { Status = "لم يحضر" });

        List<PerscritionDto> newPerscrition = new List<PerscritionDto>();
        newPerscrition.Add(new PerscritionDto { PerscriptionName = "بدون وصفة طبية" });

        // InsertPortalUserDto newPortalUser = new InsertPortalUserDto()
        // {
        //     Username = "1083622900",
        //     NationalId = "1083622900",
        //     Password = "Zero8021#",
        //     ConfirmPassword = "Zero8021#",
        //     UserFullName = "عبدالرحمن علي أبكر الجيزاني",
        //     Email = "b@b.com",
        //     Code = "",
        //     PhoneNumber = "0563438021",
        //     DateOfBirth = "24/05/1993",
        //     UserType = "رئيسي",
        //     LoginAttemp = 0,
        //     LastLogin = DateTime.Now.ToString(),
        //     CreatedDate = DateTime.Now.ToString(),
        //     PasswordExpires = false,
        //     Status = "Active",
        //     PersonalImgId = 1,
        //     EntityId = 1,
        //     DepartmentId = 1,
        //     RoleId = 1
        // };
        // if (await _auth.UserExists(newPortalUser.Username))
        // {
        //     serviceResponse.Success = false;
        //     serviceResponse.Message = "User Already Exists...";
        // }
        // else
        // {
        //     CreatePasswordHash(newPortalUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
        //     var user = _mapper.Map<PortalUser>(newPortalUser);
        //     user.PasswordSalt = passwordSalt;
        //     user.PasswordHash = passwordHash;

        //     _context.PortalUser.Add(user);
        // }

        // foreach (var item in newSurveyA)
        // {
        //     var requestAnswer = _mapper.Map<Models.SurveyModel.SurveyAnswer>(item);
        //     _context.SurveyAnswer.Add(requestAnswer);
        // }

        //       foreach (var item in newRequestType)
        // {
        //     var requestType = _mapper.Map<Models.RequestTypeModel.RequestType>(item);
        //     _context.RequestType.Add(requestType);
        // }

        // foreach (var item in newSurveyQ)
        // {
        //     var requestStatus = _mapper.Map<Models.SurveyModel.SurveyQuestion>(item);
        //     _context.SurveyQuestion.Add(requestStatus);
        // }

        // foreach (var item in newRequestStatus)
        // {
        //     var requestStatus = _mapper.Map<Models.RequestModel.RequestStatus>(item);
        //     _context.RequestStatus.Add(requestStatus);
        // }

        // foreach (var item in newRole)
        // {
        //     var role = _mapper.Map<Models.Role.Role>(item);
        //     _context.Role.Add(role);
        // }

        // foreach (var item in newEntity)
        // {
        //     var entity = _mapper.Map<Models.Entity.Entity>(item);
        //     _context.Entity.Add(entity);
        // }

        // foreach (var item in newDept)
        // {
        //     var dept = _mapper.Map<Models.Entity.Department>(item);
        //     _context.Department.Add(dept);
        // }

        // foreach (var item in newZone)
        // {
        //     var zone = _mapper.Map<Models.ZoneModel.Zone>(item);
        //     _context.Zone.Add(zone);
        // }
        foreach (var item in newSurvey)
        {
            var survey = _mapper.Map<Models.SurveyModel.SurveyType>(item);
            _context.SurveyType.Add(survey);
        }
        // foreach (var item in newAppointmentStatus)
        // {
        //     var status = _mapper.Map<Models.AppointmentModel.AppointmentStatus>(item);
        //     _context.AppointmentStatus.Add(status);
        // }
        // foreach (var item in newPerscrition)
        // {
        //     var perscription = _mapper.Map<Models.AppointmentModel.Perscription>(item);
        //     _context.Perscription.Add(perscription);
        // }

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
