using System;

namespace MVCTemplate.Dtos.CountriesDto.Get;

public class GetCountrieDto
{
    public int Id { get; set; }
    public string Country { get; set; } = string.Empty;
}
