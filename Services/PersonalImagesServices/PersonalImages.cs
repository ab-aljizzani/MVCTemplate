using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Models.PersonalImagesModel;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.PersonalImagesServices;

public class PersonalImages : IPersonalImages
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public PersonalImages(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<PersonalImgDto>>> AddNewPersonalImages(PersonalImgDto newPersonalImages)
    {
        var serviceResponse = new ServiceResponse<List<PersonalImgDto>>();
        var personalImg = _mapper.Map<PersonalImg>(newPersonalImages);
        _context.PersonalImg.Add(personalImg);
        _context.SaveChanges();
        serviceResponse.Data = await _context.Zone.Select(z => _mapper.Map<PersonalImgDto>(z)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<PersonalImgDto>> DeletePersonalImages(int id)
    {
        var serviceResponse = new ServiceResponse<PersonalImgDto>();
        try
        {
            var personalImg = await _context.PersonalImg.FirstOrDefaultAsync(p => p.Id == id);
            if (personalImg is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.PersonalImg.Remove(personalImg);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PersonalImgDto>(personalImg);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PersonalImgDto>>> GetAllPersonalImages()
    {
        var serviceResponse = new ServiceResponse<List<PersonalImgDto>>();
        var dbContext = await _context.PersonalImg.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PersonalImgDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<PersonalImgDto>> GetPersonalImagesByID(int id)
    {
        var serviceResponse = new ServiceResponse<PersonalImgDto>();
        var dbContext = await _context.PersonalImg.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<PersonalImgDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<PersonalImgDto>> UpdatePersonalImages(UpdatePersonalImgDto updatePersonalImages)
    {
        var serviceResponse = new ServiceResponse<PersonalImgDto>();
        try
        {
            var personalImg = await _context.PersonalImg.FirstOrDefaultAsync(z => z.Id == updatePersonalImages.Id);
            if (personalImg is null)
            {
                throw new Exception($"The Id '{updatePersonalImages.Id}'Is Not Founde...");
            }
            _mapper.Map(updatePersonalImages, personalImg);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PersonalImgDto>(personalImg);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
