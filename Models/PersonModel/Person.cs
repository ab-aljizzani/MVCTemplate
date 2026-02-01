using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.PersonModel;

public class Person
{
    public int Id { get; set; }
    public string NationalId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string FullArabicName { get; set; } = string.Empty;
    public string FullEnglishName { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int ZoneId { get; set; }
    public Models.ZoneModel.Zone? Zone { get; set; }
    public int EntityId { get; set; }
    public Models.Entity.Entity? Entity { get; set; }
    public int DepartmentId { get; set; }
    public Models.Entity.Department? Department { get; set; }
    public string NationalIdType { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public int? PersonalImgId { get; set; }
    public Models.PersonalImagesModel.PersonalImg? PersonalImg { get; set; }
    public string Code { get; set; } = string.Empty;
    public int? RoleId { get; set; }
    public Models.Role.Role? Role { get; set; }
    public bool IsInternal { get; set; }
    public bool IsImportant { get; set; }
}
