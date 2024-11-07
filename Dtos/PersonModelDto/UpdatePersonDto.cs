using System;

namespace ClinicApi.Dtos.PersonModelDto;

public class UpdatePersonDto
{
    public int Id { get; set; }
    public string NationalId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string FullArabicName { get; set; } = string.Empty;
    public string FullEnglishName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public int ZoneId { get; set; }
    public int EntityId { get; set; }
    public int PersonalImgId { get; set; }
    public int DepartmentId { get; set; }
    public string NationalIdType { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
}
