using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.SurveyDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.Models.SurveyModel;
using ClinicApi.ViewModel.Survey;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.Survey;

public class SurveyService : ISurveyService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public SurveyService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<GetSurveyTypeDto>>> AddNewSurvey(InsertSurveyTypeDto newSurvey)
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyTypeDto>>();
        var survey = _mapper.Map<Models.SurveyModel.SurveyType>(newSurvey);
        _context.SurveyType.Add(survey);
        _context.SaveChanges();
        serviceResponse.Data = await _context.SurveyType.Select(p => _mapper.Map<GetSurveyTypeDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyAnswerDto>>> AddNewSurveyAnswer(InsertSurveyAnswerDto newSurveyAnswer)
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyAnswerDto>>();
        var surveyAnswer = _mapper.Map<Models.SurveyModel.SurveyAnswer>(newSurveyAnswer);
        _context.SurveyAnswer.Add(surveyAnswer);
        _context.SaveChanges();
        serviceResponse.Data = await _context.SurveyAnswer.Select(p => _mapper.Map<GetSurveyAnswerDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyAnswerTypeDto>>> AddNewSurveyAnswerType(InsertSurveyAnswerTypeDto newSurveyAnswerType)
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyAnswerTypeDto>>();
        var surveyAnswerType = _mapper.Map<Models.SurveyModel.SurveyAnswerType>(newSurveyAnswerType);
        _context.SurveyAnswerType.Add(surveyAnswerType);
        _context.SaveChanges();
        serviceResponse.Data = await _context.SurveyAnswerType.Select(p => _mapper.Map<GetSurveyAnswerTypeDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyQuestionDto>>> AddNewSurveyQuestion(InsertSurveyQuestionDto newSurveyQuestion)
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyQuestionDto>>();
        var surveyQuestion = _mapper.Map<Models.SurveyModel.SurveyQuestion>(newSurveyQuestion);
        _context.SurveyQuestion.Add(surveyQuestion);
        _context.SaveChanges();
        serviceResponse.Data = await _context.SurveyQuestion.Select(p => _mapper.Map<GetSurveyQuestionDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> AddNewUserSurveyAnswer(InsertUserSurveyAnswerDto newUserSurveyAnswer)
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyAnswerDto>>();
        var userSurveyAnswer = _mapper.Map<Models.SurveyModel.UserSurveyAnswer>(newUserSurveyAnswer);
        _context.UserSurveyAnswer.Add(userSurveyAnswer);
        _context.SaveChanges();
        serviceResponse.Data = await _context.UserSurveyAnswer.Select(p => _mapper.Map<GetUserSurveyAnswerDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSurveyTypeDto>> DeleteSurvey(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyTypeDto>();
        try
        {
            var survey = await _context.SurveyType.FirstOrDefaultAsync(p => p.Id == id);
            if (survey is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.SurveyType.Remove(survey);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSurveyTypeDto>(survey);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSurveyAnswerDto>> DeleteSurveyAnswer(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyAnswerDto>();
        try
        {
            var surveyAnswer = await _context.SurveyAnswer.FirstOrDefaultAsync(p => p.Id == id);
            if (surveyAnswer is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.SurveyAnswer.Remove(surveyAnswer);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSurveyAnswerDto>(surveyAnswer);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSurveyAnswerTypeDto>> DeleteSurveyAnswerType(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyAnswerTypeDto>();
        try
        {
            var surveyAnswerType = await _context.SurveyAnswerType.FirstOrDefaultAsync(p => p.Id == id);
            if (surveyAnswerType is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.SurveyAnswerType.Remove(surveyAnswerType);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSurveyAnswerTypeDto>(surveyAnswerType);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSurveyQuestionDto>> DeleteSurveyQuestion(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyQuestionDto>();
        try
        {
            var surveyQuestion = await _context.SurveyQuestion.FirstOrDefaultAsync(p => p.Id == id);
            if (surveyQuestion is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.SurveyQuestion.Remove(surveyQuestion);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSurveyQuestionDto>(surveyQuestion);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserSurveyAnswerDto>> DeleteUserSurveyAnswer(int id)
    {
        var serviceResponse = new ServiceResponse<GetUserSurveyAnswerDto>();
        try
        {
            var userSurveyAnswer = await _context.UserSurveyAnswer.FirstOrDefaultAsync(p => p.Id == id);
            if (userSurveyAnswer is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.UserSurveyAnswer.Remove(userSurveyAnswer);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetUserSurveyAnswerDto>(userSurveyAnswer);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyTypeDto>>> GetAllSurvey()
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyTypeDto>>();
        var dbContext = await _context.SurveyType.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetSurveyTypeDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyAnswerDto>>> GetAllSurveyAnswer()
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyAnswerDto>>();
        var dbContext = await _context.SurveyAnswer.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetSurveyAnswerDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyAnswerTypeDto>>> GetAllSurveyAnswerType()
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyAnswerTypeDto>>();
        var dbContext = await _context.SurveyAnswerType.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetSurveyAnswerTypeDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyQuestionDto>>> GetAllSurveyQuestion()
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyQuestionDto>>();
        var dbContext = await _context.SurveyQuestion.Include(s => s.SurveyAnswer).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetSurveyQuestionDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> GetAllUserSurveyAnswer()
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyAnswerDto>>();
        var dbContext = await _context.UserSurveyAnswer.Include(u => u.surveyAnswer).Include(u => u.SurveyQuestion).Include(u => u.Person).Include(u => u.PortalUser).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetUserSurveyAnswerDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyAnswerDto>>> GetSurveyAnswerByAnswerType(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyAnswerDto>>();
        var dbContext = await _context.SurveyAnswer.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetSurveyAnswerDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSurveyAnswerDto>> GetSurveyAnswerByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyAnswerDto>();
        var dbContext = await _context.SurveyAnswer.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetSurveyAnswerDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSurveyAnswerTypeDto>> GetSurveyAnswerTypeByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyAnswerTypeDto>();
        var dbContext = await _context.SurveyAnswerType.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetSurveyAnswerTypeDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSurveyTypeDto>> GetSurveyByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyTypeDto>();
        var dbContext = await _context.SurveyType.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetSurveyTypeDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSurveyQesAnswerDto>>> GetSurveyQuestionAnswer(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyQesAnswerDto>>();
        var dbContext = await _context.SurveyQuestion.Where(s => s.SurveyTypeId == id).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetSurveyQesAnswerDto>(p)).ToList();
        return serviceResponse;
    }

    // public async Task<ServiceResponse<object>> GetSurveyQuestionAnswerVm(int SurveyTypeId)
    // {
    //     var serviceResponse = new ServiceResponse<object>();
    //     var surveyQ = await _context.SurveyQuestion.Where(sq => sq.SurveyTypeId == SurveyTypeId).ToListAsync();
    //     var surveyAns = await _context.SurveyAnswer.Where(s => s.SurveyAnswerTypeId == surveyQ.Select(sa => sa.SurveyAnswerTypeId).FirstOrDefault()).ToListAsync();
    //     var surveyVm = new SurveyQuestionAnswerVm() { SurveyQuestion = surveyQ, SurveyAnswer = surveyAns };
    //     if (surveyVm is null)
    //     {
    //         throw new Exception($"Not Founde...");
    //     }
    //     // serviceResponse.Data = surveyVm.Select(p => _mapper.Map<SurveyQuestionAnswerVm>(p)).ToList();
    //     serviceResponse.Data = surveyVm;
    //     return serviceResponse;
    // }
    // public async Task<List<SurveyQuestionAnswerVm>> GetSurveyQuestionVm(int SurveyTypeId)
    // {
    //     var serviceResponse = new ServiceResponse<List<SurveyQuestionAnswerVm>>();
    //     var dbContextQ = await _context.SurveyQuestion.Where(s => s.SurveyTypeId == SurveyTypeId).ToListAsync();
    //     var surveyVm = new SurveyQuestionAnswerVm(){SurveyQuestion = dbContextQ , SurveyAnswer = dbContextA};
    //     serviceResponse.Data = surveyVm.SurveyQuestion.Select(p => _mapper.Map<SurveyQuestionAnswerVm>(p)).ToList();
    //     return serviceResponse;
    // }
    public async Task<ServiceResponse<GetSurveyQuestionDto>> GetSurveyQuestionByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetSurveyQuestionDto>();
        var dbContext = await _context.SurveyQuestion.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetSurveyQuestionDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> GetUserSurveyAnswerByID(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyAnswerDto>>();
        var dbContext = await _context.UserSurveyAnswer.Where(p => p.RequestId == id).Include(u => u.surveyAnswer).Include(u => u.SurveyQuestion).Include(u => u.Person).Include(u => u.PortalUser).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetUserSurveyAnswerDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateSurveyTypeDto>> UpdateSurvey(UpdateSurveyTypeDto updateSurvey)
    {
        var serviceResponse = new ServiceResponse<UpdateSurveyTypeDto>();
        try
        {
            var survey = await _context.SurveyType.FirstOrDefaultAsync(z => z.Id == updateSurvey.Id);
            if (survey is null)
            {
                throw new Exception($"The Id '{updateSurvey.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSurvey, survey);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateSurveyTypeDto>(survey);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateSurveyAnswerDto>> UpdateSurveyAnswer(UpdateSurveyAnswerDto updateSurveyAnswer)
    {
        var serviceResponse = new ServiceResponse<UpdateSurveyAnswerDto>();
        try
        {
            var surveyAnswer = await _context.SurveyAnswer.FirstOrDefaultAsync(z => z.Id == updateSurveyAnswer.Id);
            if (surveyAnswer is null)
            {
                throw new Exception($"The Id '{updateSurveyAnswer.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSurveyAnswer, surveyAnswer);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateSurveyAnswerDto>(surveyAnswer);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateSurveyAnswerTypeDto>> UpdateSurveyAnswerType(UpdateSurveyAnswerTypeDto updateSurveyAnswerType)
    {
        var serviceResponse = new ServiceResponse<UpdateSurveyAnswerTypeDto>();
        try
        {
            var surveyAnswerType = await _context.SurveyAnswerType.FirstOrDefaultAsync(z => z.Id == updateSurveyAnswerType.Id);
            if (surveyAnswerType is null)
            {
                throw new Exception($"The Id '{updateSurveyAnswerType.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSurveyAnswerType, surveyAnswerType);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateSurveyAnswerTypeDto>(surveyAnswerType);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateSurveyQuestionDto>> UpdateSurveyQuestion(UpdateSurveyQuestionDto updateSurveyQuestion)
    {
        var serviceResponse = new ServiceResponse<UpdateSurveyQuestionDto>();
        try
        {
            var surveyQuestion = await _context.SurveyQuestion.FirstOrDefaultAsync(z => z.Id == updateSurveyQuestion.Id);
            if (surveyQuestion is null)
            {
                throw new Exception($"The Id '{updateSurveyQuestion.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSurveyQuestion, surveyQuestion);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateSurveyQuestionDto>(surveyQuestion);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateUserSurveyAnswerDto>> UpdateUserSurveyAnswer(UpdateUserSurveyAnswerDto updateUserSurveyAnswer)
    {
        var serviceResponse = new ServiceResponse<UpdateUserSurveyAnswerDto>();
        try
        {
            var userSurveyAnswer = await _context.UserSurveyAnswer.FirstOrDefaultAsync(z => z.Id == updateUserSurveyAnswer.Id);
            if (userSurveyAnswer is null)
            {
                throw new Exception($"The Id '{updateUserSurveyAnswer.Id}'Is Not Founde...");
            }
            _mapper.Map(updateUserSurveyAnswer, userSurveyAnswer);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateUserSurveyAnswerDto>(userSurveyAnswer);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
