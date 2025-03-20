using System;
using ClinicApi.Models.AppintmentReviewModel;
using ClinicApi.Models.AppointmentModel;
using ClinicApi.Models.AuditsModel;
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
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {

  }
  public DbSet<Entity> Entity => Set<Entity>();
  public DbSet<Department> Department => Set<Department>();
  public DbSet<Role> Role => Set<Role>();
  public DbSet<PortalUser> PortalUser => Set<PortalUser>();
  public DbSet<DashboardUser> DashboardUser => Set<DashboardUser>();
  public DbSet<Zone> Zone => Set<Zone>();
  public DbSet<PersonalImg> PersonalImg => Set<PersonalImg>();
  public DbSet<Person> Person => Set<Person>();
  public DbSet<Request> Request => Set<Request>();
  public DbSet<RequestStatus> RequestStatus => Set<RequestStatus>();
  public DbSet<RequestType> RequestType => Set<RequestType>();
  public DbSet<SurveyType> SurveyType => Set<SurveyType>();
  public DbSet<SurveyQuestion> SurveyQuestion => Set<SurveyQuestion>();
  public DbSet<SurveyAnswer> SurveyAnswer => Set<SurveyAnswer>();
  public DbSet<SurveyAnswerType> SurveyAnswerType => Set<SurveyAnswerType>();
  public DbSet<UserSurveyAnswer> UserSurveyAnswer => Set<UserSurveyAnswer>();
  public DbSet<UserSurveyAnswerTimes> UserSurveyAnswerTimes => Set<UserSurveyAnswerTimes>();
  public DbSet<DoctorAvailbleTime> DoctorAvailbleTime => Set<DoctorAvailbleTime>();
  public DbSet<Audits> Audits => Set<Audits>();
  public DbSet<Appointment> Appointment => Set<Appointment>();
  public DbSet<AppointmentStatus> AppointmentStatus => Set<AppointmentStatus>();
  public DbSet<Perscription> Perscription => Set<Perscription>();
  public DbSet<RiskLevel> RiskLevel => Set<RiskLevel>();
  public DbSet<SickLeave> SickLeave => Set<SickLeave>();
  public DbSet<UserSurveyList> UserSurveyList => Set<UserSurveyList>();
  public DbSet<AppointmentReview> AppointmentReview => Set<AppointmentReview>();
}
