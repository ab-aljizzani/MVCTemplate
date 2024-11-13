using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.Entity.Get;

public class DepatmentByEntityIdDto
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال الإدارة")]
    [Display(Name = "الإدارة")]
    public string DepartmentName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    // public int EntityId { get; set; }
    // public GetEntityDto? Entity { get; set; }
}
