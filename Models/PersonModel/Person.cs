using System;

namespace ClinicApi.Models.PersonModel;

public class Person
{
    public int Id { get; set; }
    public string NationalId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string FullArabicName { get; set; } = string.Empty;
    public string FullEnglishName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public int ZoneId { get; set; }
    public Models.ZoneModel.Zone? Zone {get ; set ;}
    public int EntityId { get; set; }
    public int DepartmentId { get; set; }
    public Models.Entity.Department? Department { get; set; }
    public string NationalIdType { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public int PersonalImgId { get; set; }
    public Models.PersonalImagesModel.PersonalImg? PersonalImg { get; set; }
}
