using System;
using System.Text;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Models.PersonalImagesModel;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace ClinicApi.Services.PersonalImagesServices;

public class PersonalImages : IPersonalImages
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _web;

    public PersonalImages(IMapper mapper, DataContext context, IWebHostEnvironment web)
    {
        _mapper = mapper;
        _context = context;
        _web = web;
    }
    public async Task<ServiceResponse<int>> AddNewPersonalImages(PersonalImgDto newPersonalImages)
    {
        var serviceResponse = new ServiceResponse<int>();
        using (var memoryStream = new MemoryStream())
        {
            if (newPersonalImages.ImgFile != null)
            {
                await newPersonalImages.ImgFile.CopyToAsync(memoryStream);
                if (memoryStream.Length < 2097152)
                {
                    var file = new PersonalImgDto()
                    {
                        PersonalImage = memoryStream.ToArray(),
                    };
                    newPersonalImages.PersonalImage = memoryStream.ToArray();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "The file is too large.";
                }
            }
        }
        using (var memoryStream = new MemoryStream())
        {
            if (newPersonalImages.DocFile != null)
            {
                await newPersonalImages.DocFile.CopyToAsync(memoryStream);
                if (memoryStream.Length < 2097152)
                {
                    var file = new PersonalImgDto()
                    {
                        DocumentImg = memoryStream.ToArray(),
                    };
                    newPersonalImages.DocumentImg = memoryStream.ToArray();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "The file is too large.";
                }
            }
        }
        if (newPersonalImages.DocumentImg is null && newPersonalImages.PersonalImage is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No Data Was Interd";
        }
        else
        {
            var personalImg = _mapper.Map<PersonalImg>(newPersonalImages);
            _context.PersonalImg.Add(personalImg);
            _context.SaveChanges();
            serviceResponse.Data = personalImg.Id;
        }
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

    public async Task<ServiceResponse<int>> UpdatePersonalImages(UpdatePersonalImgDto updatePersonalImages)
    {
        var serviceResponse = new ServiceResponse<int>();
        try
        {
            var personalImg = await _context.PersonalImg.FirstOrDefaultAsync(z => z.Id == updatePersonalImages.Id);
            var OldData = await _context.PersonalImg.FirstOrDefaultAsync(e => e.Id == updatePersonalImages.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (personalImg is null)
            {
                throw new Exception($"The Id '{updatePersonalImages.Id}'Is Not Founde...");
            }
            using (var memoryStream = new MemoryStream())
            {
                if (updatePersonalImages.ImgFile != null)
                {
                    await updatePersonalImages.ImgFile.CopyToAsync(memoryStream);
                    if (memoryStream.Length < 2097152)
                    {
                        var file = new PersonalImgDto()
                        {
                            PersonalImage = memoryStream.ToArray(),
                        };
                        updatePersonalImages.PersonalImage = memoryStream.ToArray();
                    }
                    else
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = "The file is too large.";
                    }
                }
                else
                    updatePersonalImages.PersonalImage = personalImg.PersonalImage;
            }
            using (var memoryStream = new MemoryStream())
            {
                if (updatePersonalImages.DocFile != null)
                {
                    await updatePersonalImages.DocFile.CopyToAsync(memoryStream);
                    if (memoryStream.Length < 2097152)
                    {
                        var file = new PersonalImgDto()
                        {
                            DocumentImg = memoryStream.ToArray(),
                        };
                        updatePersonalImages.DocumentImg = memoryStream.ToArray();
                    }
                    else
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = "The file is too large.";
                    }
                }
                else
                    updatePersonalImages.DocumentImg = personalImg.DocumentImg;
            }
            if (updatePersonalImages.DocumentImg is null && updatePersonalImages.PersonalImage is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No Data Was Interd";
            }
            else
            {
                _mapper.Map(updatePersonalImages, personalImg);
                await _context.SaveChangesAsync();
                serviceResponse.Data = personalImg.Id;
            }

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
