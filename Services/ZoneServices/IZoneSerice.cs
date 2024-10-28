using System;
using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Dtos.ZoneModelDto.Update;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.ZoneServices;

public interface IZoneSerice
{
    Task<ServiceResponse<List<ZoneDto>>> GetAllZone();
    Task<ServiceResponse<ZoneDto>> GetZoneByID(int id);
    Task<ServiceResponse<List<ZoneDto>>> AddNewZone(ZoneDto newZone);
    Task<ServiceResponse<ZoneDto>> UpdateZone(UpdateZoneDto updateZone);
    Task<ServiceResponse<ZoneDto>> DeleteZone(int id);
}
