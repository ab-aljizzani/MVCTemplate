using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApi.Data.PersonalImagesModelDto;

public class PersonalImgDto
{
    public int Id { get; set; }
    public byte[]? PersonalImage { get; set; }
    public byte[]? DocumentImg { get; set; }
    [NotMapped]
    [Display(Name = "الصورة الشخصية")]
    public IFormFile? ImgFile { get; set; }
    [NotMapped]
    [Display(Name = "صورة الهوية الوطنية")]
    public IFormFile? DocFile { get; set; }
}
