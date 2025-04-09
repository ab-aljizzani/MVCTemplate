using System;
using ClinicApi.Models.PersonModel;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetCustomRequestDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    public int RequestStatusId { get; set; }
    public int RiskLevelId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string AppsentReason { get; set; } = string.Empty;
    public string ApponitmentDate { get; set; } = string.Empty;
    public string AppointmentDay { get; set; } = string.Empty;
    public string AppointmentStartTime { get; set; } = string.Empty;
    public string RoleArabName { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;
    public string FullArabicName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ZoneName { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public byte[]? PersonalImage { get; set; }
    public int? PersonalImgId { get; set; }
    public string Risk { get; set; } = string.Empty;
}
