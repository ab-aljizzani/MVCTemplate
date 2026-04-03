using ClinicApi.Models.AuthorizeModel;
using System;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetRequestStatusDto : IAuthorizeModel
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public int StatusOrder { get; set; }
    public string BadgeColor { get; set; } = string.Empty;

    public int RequestStatusId { get; set; }

    public bool IsImportant { get; set; }

    public bool isEmergency { get; set; }

    public bool IsPersonShowUp { get; set; }

    public int PortalUserId { get; set; }

    public string RoleName { get; set; }
    public string TypeRole { get; set; }
}
