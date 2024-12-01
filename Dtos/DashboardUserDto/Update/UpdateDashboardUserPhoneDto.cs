using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.DashboardUserDto.Update;

public class UpdateDashboardUserPhoneDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
    [Display(Name = "رقم الجوال")]
    public string PhoneNumber { get; set; } = string.Empty;
}
