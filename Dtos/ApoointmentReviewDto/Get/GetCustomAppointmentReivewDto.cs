using ClinicApi.Models.AuthorizeModel;
using System;

namespace ClinicApi.Dtos.ApoointmentReviewDto.Get;

public class GetCustomAppointmentReivewDto : IAuthorizeModel
{
    public string Review { get; set; } = string.Empty;
    public string ReviewDate { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string RoleArabName { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;

    public int RequestStatusId { get; set; }

    public bool IsImportant  { get; set; }

    public bool isEmergency  { get; set; }

    public bool IsPersonShowUp  { get; set; }

    public int PortalUserId  { get; set; }
    public int StatusOrder { get; set; }
    public string TypeRole  { get; set; }
}
