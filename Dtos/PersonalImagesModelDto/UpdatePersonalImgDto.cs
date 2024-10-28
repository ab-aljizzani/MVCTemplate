using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApi.Dtos.PersonalImagesModelDto;

public class UpdatePersonalImgDto
{
    public int Id { get; set; }
    public byte[]? PersonalImage { get; set; }
    public byte[]? DocumentImg { get; set; }
    [NotMapped]
    public IFormFile? ImgFile { get; set; }
    [NotMapped]
    public IFormFile? DocFile { get; set; }
}
