using System;

namespace ClinicApi.Dtos.PersonalImagesModelDto;

public class UpdatePersonalImgDto
{
    public int Id { get; set; }
    public byte[]? PersonalImage { get; set; }
    public byte[]? DocumentImg { get; set; }
}
