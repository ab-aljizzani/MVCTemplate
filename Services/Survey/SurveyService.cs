using System;
using System.Text;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.SurveyDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.Models.SurveyModel;
using ClinicApi.ViewModel.Survey;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
    public async Task<ServiceResponse<int>> AddNewSurvey(InsertSurveyTypeDto newSurvey)
    {
        var serviceResponse = new ServiceResponse<int>();
        var survey = _mapper.Map<Models.SurveyModel.SurveyType>(newSurvey);
        _context.SurveyType.Add(survey);
        _context.SaveChanges();
        serviceResponse.Data = survey.Id;
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

    public async Task<ServiceResponse<int>> AddNewSurveyQuestion(InsertSurveyQuestionDto newSurveyQuestion)
    {
        var serviceResponse = new ServiceResponse<int>();
        var surveyQuestion = _mapper.Map<Models.SurveyModel.SurveyQuestion>(newSurveyQuestion);
        _context.SurveyQuestion.Add(surveyQuestion);
        _context.SaveChanges();
        serviceResponse.Data = surveyQuestion.Id;
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

    public async Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> AddNewUserSurveyAnswerNoPortal(InsertUserSurveyAnswerNoPortalDto newUserSurveyAnswer)
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyAnswerDto>>();
        var userSurveyAnswer = _mapper.Map<Models.SurveyModel.UserSurveyAnswer>(newUserSurveyAnswer);
        _context.UserSurveyAnswer.Add(userSurveyAnswer);
        _context.SaveChanges();
        serviceResponse.Data = await _context.UserSurveyAnswer.Select(p => _mapper.Map<GetUserSurveyAnswerDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserSurveyAnswerTimeDto>>> AddNewUserSurveyAnswerTime(InsertUserSurveyAnswerTimeDto newUserSurveyAnswer)
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyAnswerTimeDto>>();
        var userSurveyAnswerTimes = _mapper.Map<Models.SurveyModel.UserSurveyAnswerTimes>(newUserSurveyAnswer);
        _context.UserSurveyAnswerTimes.Add(userSurveyAnswerTimes);
        _context.SaveChanges();
        serviceResponse.Data = await _context.UserSurveyAnswerTimes.Select(p => _mapper.Map<GetUserSurveyAnswerTimeDto>(p)).ToListAsync();
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

    public async Task<ServiceResponse<List<GetUserSurveyAnswerTimeDto>>> GetAllUserSurveyAnswerTime()
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyAnswerTimeDto>>();
        var dbContext = await _context.UserSurveyAnswerTimes.Include(u => u.SurveyQuestion).Include(u => u.SurveyAnswer).Select(s => new { s.Id, s.AnswerTime }).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetUserSurveyAnswerTimeDto>(p)).ToList();
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

    public async Task<ServiceResponse<string>> GetSurveyAnswerPointByID(int id)
    {
        var serviceResponse = new ServiceResponse<string>();
        var dbContext = await _context.SurveyAnswer.Where(p => p.Id == id).Select(a => a.AnswerPoint).FirstOrDefaultAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<string>(dbContext);
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

    public async Task<ServiceResponse<List<GetSurveyQuestionDto>>> GetSurveyQuestionBySurvTypeId(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetSurveyQuestionDto>>();
        var dbContext = await _context.SurveyQuestion.Include(s => s.SurveyAnswer).Where(p => p.SurveyTypeId == id).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetSurveyQuestionDto>(p)).ToList();
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

    public async Task<ServiceResponse<bool>> CheckUserSurveyAnswerBySurveyTypeID(int id)
    {
        var serviceResponse = new ServiceResponse<bool>();
        var dbContext = await _context.UserSurveyAnswer.Where(p => p.SurveyTypeId == id).Include(u => u.surveyAnswer).Include(u => u.SurveyQuestion).Include(u => u.Person).Include(u => u.PortalUser).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        if (dbContext.Count() > 0)
            serviceResponse.Data = false;
        else
            serviceResponse.Data = true;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<object>>> GetUserSurveyAnswerTimeByAppointId(int id, int questionId)
    {
        var serviceResponse = new ServiceResponse<List<object>>();
        var dbContext = await _context.UserSurveyAnswerTimes.Where(p => p.AppointmentId == id && p.SurveyQuestionId == questionId).Include(u => u.SurveyQuestion).Include(u => u.SurveyAnswer).ToListAsync(); ;
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<object>(new { p.SurveyQuestion.Question, p.SurveyAnswer.Answer, p.AnswerTime })).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateSurveyTypeDto>> UpdateSurvey(UpdateSurveyTypeDto updateSurvey)
    {
        var serviceResponse = new ServiceResponse<UpdateSurveyTypeDto>();
        try
        {
            var survey = await _context.SurveyType.FirstOrDefaultAsync(z => z.Id == updateSurvey.Id);
            var OldData = await _context.SurveyType.FirstOrDefaultAsync(e => e.Id == updateSurvey.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
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
            var OldData = await _context.SurveyAnswer.FirstOrDefaultAsync(e => e.Id == updateSurveyAnswer.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
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
            var OldData = await _context.SurveyAnswerType.FirstOrDefaultAsync(e => e.Id == updateSurveyAnswerType.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
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
            var OldData = await _context.SurveyQuestion.FirstOrDefaultAsync(e => e.Id == updateSurveyQuestion.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
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
            var OldData = await _context.UserSurveyAnswer.FirstOrDefaultAsync(e => e.Id == updateUserSurveyAnswer.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
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

    public async Task<ServiceResponse<List<GetUserSurveyListDto>>> GetAllUserSurveyList()
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyListDto>>();
        var dbContext = await _context.UserSurveyList.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetUserSurveyListDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserSurveyListDto>> GetUserSurveyListByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetUserSurveyListDto>();
        var dbContext = await _context.UserSurveyList.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetUserSurveyListDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserSurveyListDto>>> AddNewUserSurveyList(InsertUserSurveyListDto newSurveyList)
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyListDto>>();
        var usersurveyList = _mapper.Map<Models.SurveyModel.UserSurveyList>(newSurveyList);
        var usersurvey = await _context.UserSurveyList.FirstOrDefaultAsync(u => u.AppointmentId == newSurveyList.AppointmentId && u.SurveyTypeId == newSurveyList.SurveyTypeId && u.RequestId == newSurveyList.RequestId);
        if (usersurvey != null)
        {
            throw new Exception($"The Survey Already Inserted For This Appointment...");
        }
        _context.UserSurveyList.Add(usersurveyList);
        _context.SaveChanges();
        serviceResponse.Data = await _context.UserSurveyList.Select(p => _mapper.Map<GetUserSurveyListDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateUserSurveyListDto>> UpdateUserSurveyList(UpdateUserSurveyListDto updateSurveyList)
    {
        var serviceResponse = new ServiceResponse<UpdateUserSurveyListDto>();
        try
        {
            var userSurveyList = await _context.UserSurveyList.FirstOrDefaultAsync(z => z.Id == updateSurveyList.Id);
            var OldData = await _context.UserSurveyList.FirstOrDefaultAsync(e => e.Id == updateSurveyList.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (userSurveyList is null)
            {
                throw new Exception($"The Id '{updateSurveyList.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSurveyList, userSurveyList);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateUserSurveyListDto>(userSurveyList);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserSurveyListDto>> DeleteUserSurveyList(int id)
    {
        var serviceResponse = new ServiceResponse<GetUserSurveyListDto>();
        try
        {
            var survey = await _context.UserSurveyList.FirstOrDefaultAsync(p => p.Id == id);
            if (survey is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.UserSurveyList.Remove(survey);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetUserSurveyListDto>(survey);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateUserSurveyListScoreAndInserted>> UpdateUserSurveyListScoreAndInserted(UpdateUserSurveyListScoreAndInserted updateSurveyList)
    {
        var serviceResponse = new ServiceResponse<UpdateUserSurveyListScoreAndInserted>();
        try
        {
            var userSurveyList = await _context.UserSurveyList.FirstOrDefaultAsync(z => z.Id == updateSurveyList.Id);
            var OldData = await _context.UserSurveyList.FirstOrDefaultAsync(e => e.Id == updateSurveyList.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (userSurveyList is null)
            {
                throw new Exception($"The Id '{updateSurveyList.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSurveyList, userSurveyList);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateUserSurveyListScoreAndInserted>(userSurveyList);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserSurveyListDto>>> GetUserSurveyListByReqId(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyListDto>>();
        var dbContext = await _context.UserSurveyList.Where(p => p.RequestId == id).Include(u => u.SurveyType).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetUserSurveyListDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserSurveyScoreDto>> GetUserSurveyListScore(int appid, int reqId, int survTypeID)
    {
        var serviceResponse = new ServiceResponse<GetUserSurveyScoreDto>();
        var dbContext = await _context.UserSurveyList.Where(p => p.RequestId == reqId && p.AppointmentId == appid && p.SurveyTypeId == survTypeID).FirstOrDefaultAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id's '{appid + ' ' + reqId + ' ' + survTypeID}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetUserSurveyScoreDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserSurveyListDto>>> GetAllUserReportSurveyList()
    {
        var serviceResponse = new ServiceResponse<List<GetUserSurveyListDto>>();
        var dbContext = await _context.UserSurveyList.Where(p => p.IsSurveyInserted == false && p.SurveyType.TypeRole.ToLower() == "report").Include(u => u.SurveyType).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetUserSurveyListDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateUserSurveyListPladgeApproved>> UpdateUserSurveyListPladgeApproved(UpdateUserSurveyListPladgeApproved updateSurvey)
    {
        var serviceResponse = new ServiceResponse<UpdateUserSurveyListPladgeApproved>();
        try
        {
            var userSurveyList = await _context.UserSurveyList.FirstOrDefaultAsync(z => z.Id == updateSurvey.Id);
            var OldData = await _context.UserSurveyList.FirstOrDefaultAsync(e => e.Id == updateSurvey.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (userSurveyList is null)
            {
                throw new Exception($"The Id '{updateSurvey.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSurvey, userSurveyList);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateUserSurveyListPladgeApproved>(userSurveyList);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserSurveyAnswerTimeCountDto>> GetUserSurveyAnswerTimeCountByRequestId(int requestId)
    {
        var serviceResponse = new ServiceResponse<GetUserSurveyAnswerTimeCountDto>();

        try
        {
            var repeated = await _context.UserSurveyAnswerTimes
                .AsNoTracking()
                .Where(x => x.RequestId == requestId && x.SurveyQuestionId > 1)
                .GroupBy(x => x.SurveyQuestionId)
                .Where(g => g.Count() > 1)
                .Select(g => new GetRepeatedSurveyQuestionIdDto
                {
                    SurveyQuestionId = g.Key,
                    RepeatCount = g.Count()
                })
                .OrderBy(x => x.SurveyQuestionId)
                .ToListAsync();

            serviceResponse.Data = new GetUserSurveyAnswerTimeCountDto
            {
                RequestId = requestId,
                Count = repeated.Count,
                SurveyQuestionIds = repeated.Select(x => x.SurveyQuestionId).ToList(),
                RepeatedQuestions = repeated
            };
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}
