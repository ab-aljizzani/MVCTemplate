using System;
using AutoMapper;
using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.ApoointmentReviewDto.Get;
using ClinicApi.Dtos.ApoointmentReviewDto.Insert;
using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.AppointmentDto.Insert;
using ClinicApi.Dtos.AppointmentDto.Update;
using ClinicApi.Dtos.CountriesDto.Get;
using ClinicApi.Dtos.DashboardUserDto;
using ClinicApi.Dtos.DashboardUserDto.Insert;
using ClinicApi.Dtos.DashboardUserDto.Update;
using ClinicApi.Dtos.DoctorAvailbleTimeDto;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Insert;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Update;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.Entity.Get;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.PortalUserModelDto.Insert;
using ClinicApi.Dtos.PortalUserModelDto.Update;
using ClinicApi.Dtos.RequestDto.Get;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RequestDto.Update;
using ClinicApi.Dtos.RiskLevelDto.Get;
using ClinicApi.Dtos.RiskLevelDto.Insert;
using ClinicApi.Dtos.RiskLevelDto.Update;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.RoleDto.Update;
using ClinicApi.Dtos.SickLeaveDto.Get;
using ClinicApi.Dtos.SickLeaveDto.Insert;
using ClinicApi.Dtos.SickLeaveDto.Update;
using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.SurveyDto.Update;
using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Dtos.ZoneModelDto.Update;
using ClinicApi.Models.AppintmentReviewModel;
using ClinicApi.Models.AppointmentModel;
using ClinicApi.Models.CountriesModel;
using ClinicApi.Models.DashboarUserModel;
using ClinicApi.Models.DoctorAvailbleTimeModel;
using ClinicApi.Models.Entity;
using ClinicApi.Models.PersonalImagesModel;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.RequestModel;
using ClinicApi.Models.RequestTypeModel;
using ClinicApi.Models.RiskLevelModel;
using ClinicApi.Models.Role;
using ClinicApi.Models.SickLeaveModel;
using ClinicApi.Models.SurveyModel;
using ClinicApi.Models.ZoneModel;
using ClinicApi.ViewModel.Survey;

namespace ClinicApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Entity, GetEntityDto>();
        CreateMap<AddEntityDto, Entity>();
        CreateMap<UpdateEntityDto, Entity>();

        CreateMap<AddDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDot, Department>();

        CreateMap<Department, AddDepartmentDto>();
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentDto, Department>();
        CreateMap<DeptEntityDto, Department>();
        CreateMap<Department, DeptEntityDto>();

        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<UpdateRoleDto, Role>();

        CreateMap<PortalUser, PortalUserDto>();
        CreateMap<PortalUserDto, PortalUser>();
        CreateMap<UpdatePortalUserDto, PortalUser>();
        CreateMap<InsertPortalUserDto, PortalUser>();
        CreateMap<PasswordExpireUpdateDto, PortalUser>();
        CreateMap<PasswordInitialDto, PortalUser>();
        CreateMap<UpdatePortalUserPhoneDto, PortalUser>();
        CreateMap<UpdatePortalUserRoleDto, PortalUser>();
        CreateMap<InsertPortalUserNoPersonalImgDto, PortalUser>();
        CreateMap<InsertPortalUserDto, InsertPortalUserNoPersonalImgDto>();

        CreateMap<DashboardUser, DashboardUserDto>();
        CreateMap<DashboardUserDto, DashboardUser>();
        CreateMap<UpdateDashboardUserDto, DashboardUser>();
        CreateMap<InsertDashboardUserDto, DashboardUser>();
        CreateMap<DashboardPasswordExpireUpdateDto, DashboardUser>();
        CreateMap<DashboardPasswordInitialDto, DashboardUser>();
        CreateMap<UpdateDashboardUserPhoneDto, DashboardUser>();



        CreateMap<Zone, ZoneDto>();
        CreateMap<ZoneDto, Zone>();
        CreateMap<UpdateZoneDto, Zone>();

        CreateMap<PersonalImg, PersonalImgDto>();
        CreateMap<PersonalImgDto, PersonalImg>();
        CreateMap<UpdatePersonalImgDto, PersonalImg>();

        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();
        CreateMap<UpdatePersonDto, Person>();
        CreateMap<Person, UpdatePersonDto>();
        CreateMap<InsertPersonDto, Person>();
        CreateMap<Person, InsertPersonDto>();
        CreateMap<InsertPersonNoPersonImgDto, Person>();
        CreateMap<InsertPersonDto, InsertPersonNoPersonImgDto>();
        CreateMap<UpdatePersonDto, UpdatePersonNoPersonalImgDto>();
        CreateMap<UpdatePersonNoPersonalImgDto, UpdatePersonDto>();
        CreateMap<UpdatePersonNoPersonalImgDto, Person>();

        CreateMap<GetRequestDto, Request>();
        CreateMap<InsertRequestDto, Request>();
        CreateMap<UpdateRequestDto, Request>();
        CreateMap<Request, GetRequestDto>();
        CreateMap<Request, InsertRequestDto>();
        CreateMap<Request, UpdateRequestDto>();
        CreateMap<UpdateRequestAppsentReasonDto, Request>();
        CreateMap<UpdateRequestStatusIdDto, Request>();
        CreateMap<UpdateRequestSurveyInsertedDto, Request>();
        CreateMap<UpdateReqAppointmentIdDto, Request>();

        CreateMap<GetRequestStatusDto, RequestStatus>();
        CreateMap<InsertRequestStatusDto, RequestStatus>();
        CreateMap<UpdateRequestStatusDto, RequestStatus>();
        CreateMap<RequestStatus, GetRequestStatusDto>();
        CreateMap<RequestStatus, InsertRequestStatusDto>();
        CreateMap<RequestStatus, UpdateRequestStatusDto>();

        CreateMap<GetRequestStatusDto, RequestType>();
        CreateMap<InsertRequestTypeDto, RequestType>();
        CreateMap<UpdateRequestTypeDto, RequestType>();
        CreateMap<RequestType, GetRequestTypeDto>();
        CreateMap<RequestType, InsertRequestTypeDto>();
        CreateMap<RequestType, UpdateRequestTypeDto>();

        CreateMap<GetSurveyTypeDto, SurveyType>();
        CreateMap<InsertSurveyTypeDto, SurveyType>();
        CreateMap<UpdateSurveyTypeDto, SurveyType>();
        CreateMap<SurveyType, GetSurveyTypeDto>();
        CreateMap<SurveyType, InsertSurveyTypeDto>();
        CreateMap<SurveyType, UpdateSurveyTypeDto>();

        CreateMap<GetSurveyAnswerDto, SurveyAnswer>();
        CreateMap<InsertSurveyAnswerDto, SurveyAnswer>();
        CreateMap<UpdateSurveyAnswerDto, SurveyAnswer>();
        CreateMap<SurveyAnswer, GetSurveyAnswerDto>();
        CreateMap<SurveyAnswer, InsertSurveyAnswerDto>();
        CreateMap<SurveyAnswer, UpdateSurveyAnswerDto>();

        CreateMap<GetSurveyAnswerTypeDto, SurveyAnswerType>();
        CreateMap<InsertSurveyAnswerTypeDto, SurveyAnswerType>();
        CreateMap<UpdateSurveyAnswerTypeDto, SurveyAnswerType>();
        CreateMap<SurveyAnswerType, GetSurveyAnswerTypeDto>();
        CreateMap<SurveyAnswerType, InsertSurveyAnswerTypeDto>();
        CreateMap<SurveyAnswerType, UpdateSurveyAnswerTypeDto>();


        CreateMap<GetSurveyQuestionDto, SurveyQuestion>();
        CreateMap<InsertSurveyQuestionDto, SurveyQuestion>();
        CreateMap<UpdateSurveyQuestionDto, SurveyQuestion>();
        CreateMap<SurveyQuestion, GetSurveyQuestionDto>();
        CreateMap<SurveyQuestion, InsertSurveyQuestionDto>();
        CreateMap<SurveyQuestion, UpdateSurveyQuestionDto>();

        CreateMap<GetUserSurveyAnswerDto, UserSurveyAnswer>();
        CreateMap<InsertUserSurveyAnswerDto, UserSurveyAnswer>();
        CreateMap<UpdateUserSurveyAnswerDto, UserSurveyAnswer>();
        CreateMap<UserSurveyAnswer, GetUserSurveyAnswerDto>();
        CreateMap<UserSurveyAnswer, InsertUserSurveyAnswerDto>();
        CreateMap<UserSurveyAnswer, UpdateUserSurveyAnswerDto>();
        CreateMap<InsertUserSurveyAnswerNoPortalDto, UserSurveyAnswer>();

        CreateMap<GetUserSurveyAnswerTimeDto, UserSurveyAnswerTimes>();
        CreateMap<UserSurveyAnswerTimes, GetUserSurveyAnswerTimeDto>();
        CreateMap<InsertUserSurveyAnswerTimeDto, UserSurveyAnswerTimes>();


        CreateMap<GetSurveyQesAnswerDto, SurveyQuestion>();
        CreateMap<SurveyQuestion, GetSurveyQesAnswerDto>();

        CreateMap<GetUserSurveyListDto, UserSurveyList>();
        CreateMap<GetUserSurveyListTypesDto, UserSurveyList>();
        CreateMap<InsertUserSurveyListDto, UserSurveyList>();
        CreateMap<UpdateUserSurveyListDto, UserSurveyList>();
        CreateMap<UserSurveyList, GetUserSurveyListDto>();
        CreateMap<UserSurveyList, GetUserSurveyListTypesDto>();
        CreateMap<UserSurveyList, InsertUserSurveyListDto>();
        CreateMap<UserSurveyList, UpdateUserSurveyListDto>();
        CreateMap<UserSurveyList, UpdateUserSurveyListScoreAndInserted>();
        CreateMap<UpdateUserSurveyListScoreAndInserted, UserSurveyList>();
        CreateMap<GetUserSurveyScoreDto, UserSurveyList>();
        CreateMap<UserSurveyList, GetUserSurveyScoreDto>();
        CreateMap<UserSurveyList, UpdateUserSurveyListPladgeApproved>();
        CreateMap<UpdateUserSurveyListPladgeApproved, UserSurveyList>();

        CreateMap<GetDoctorAvailbleTimeDto, DoctorAvailbleTime>();
        CreateMap<DoctorAvailbleTime, GetDoctorAvailbleTimeDto>();
        CreateMap<InsertDoctorAvailbleTimeDto, DoctorAvailbleTime>();
        CreateMap<UpdateDoctorAvailbleTimeDto, DoctorAvailbleTime>();
        CreateMap<UpdateDoctorIsActive, DoctorAvailbleTime>();


        CreateMap<AppointmentDto, Appointment>();
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<InsertAppointmentDto, Appointment>();
        CreateMap<UpdateAppointmentDto, Appointment>();
        CreateMap<UpdateAppointmentDto, Appointment>();
        CreateMap<UpdateIsPersonShowup, Appointment>();
        CreateMap<UpdateAppointmentSurveyTypeIdDto, Appointment>();
        CreateMap<UpdateAppointmentIsSurveyInsertedDto, Appointment>();
        CreateMap<UpdateAppointmentReviewDto, Appointment>();
        CreateMap<UpdateAppointmentDoctorReviewDto, Appointment>();

        CreateMap<AppointmentStatusDto, AppointmentStatus>();
        CreateMap<AppointmentStatus, AppointmentStatusDto>();
        CreateMap<InsertAppointmentStatusDto, AppointmentStatus>();
        CreateMap<UpdateAppointmentStatusDto, AppointmentStatus>();

        CreateMap<PerscritionDto, Perscription>();
        CreateMap<Perscription, PerscritionDto>();
        CreateMap<InsertPerscriptionDto, Perscription>();
        CreateMap<UpdatePerscriptionDto, Perscription>();

        CreateMap<GetRiskLevelDto, RiskLevel>();
        CreateMap<RiskLevel, GetRiskLevelDto>();
        CreateMap<InsertRiskLevelDto, RiskLevel>();
        CreateMap<UpdateRiskLevelDto, RiskLevel>();

        CreateMap<GetSickLeaveDto, SickLeave>();
        CreateMap<SickLeave, GetSickLeaveDto>();
        CreateMap<InsertSickLeaveDto, SickLeave>();
        CreateMap<UpdateSickLeaveDto, SickLeave>();

        CreateMap<GetAppointmentReviewDto, AppointmentReview>();
        CreateMap<AppointmentReview, GetAppointmentReviewDto>();
        CreateMap<GetCustomAppointmentReivewDto, AppointmentReview>();
        CreateMap<AppointmentReview, GetCustomAppointmentReivewDto>();
        CreateMap<InsertAppointmentReviewDto, AppointmentReview>();
        CreateMap<UpdateAppointmentReviewDto, AppointmentReview>();

        CreateMap<GetCountrieDto, Countries>();
        CreateMap<Countries, GetCountrieDto>();

    }
}
