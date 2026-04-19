using System;
using System.ComponentModel.DataAnnotations;

namespace MVCTemplate.Dtos.PortalUserModelDto.Update;

public class UpdatePortalUserPhoneDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
    [Display(Name = "رقم الجوال")]
    public string PhoneNumber { get; set; } = string.Empty;
}
