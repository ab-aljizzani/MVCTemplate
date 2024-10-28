using System;

namespace ClinicApi.Models.PersonalImagesModel;

public class PersonalImg
{
    public int Id { get; set; }
    public byte[]? PersonalImage { get; set; }
    public byte[]? DocumentImg { get; set; }
}
