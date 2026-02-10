using System;
using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.SurveyDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.ViewModel.Survey;

namespace ClinicApi.Services.Survey;

public interface ISurveyService
{
    Task<ServiceResponse<List<GetSurveyTypeDto>>> GetAllSurvey();
    Task<ServiceResponse<GetSurveyTypeDto>> GetSurveyByID(int id);
    Task<ServiceResponse<int>> AddNewSurvey(InsertSurveyTypeDto newSurvey);
    Task<ServiceResponse<UpdateSurveyTypeDto>> UpdateSurvey(UpdateSurveyTypeDto updateSurvey);
    Task<ServiceResponse<GetSurveyTypeDto>> DeleteSurvey(int id);

    Task<ServiceResponse<List<GetSurveyAnswerDto>>> GetAllSurveyAnswer();
    Task<ServiceResponse<GetSurveyAnswerDto>> GetSurveyAnswerByID(int id);
    Task<ServiceResponse<string>> GetSurveyAnswerPointByID(int id);
    Task<ServiceResponse<List<GetSurveyAnswerDto>>> GetSurveyAnswerByAnswerType(int id);
    Task<ServiceResponse<List<GetSurveyAnswerDto>>> AddNewSurveyAnswer(InsertSurveyAnswerDto newSurveyAnswer);
    Task<ServiceResponse<UpdateSurveyAnswerDto>> UpdateSurveyAnswer(UpdateSurveyAnswerDto updateSurveyAnswer);
    Task<ServiceResponse<GetSurveyAnswerDto>> DeleteSurveyAnswer(int id);

    Task<ServiceResponse<List<GetSurveyAnswerTypeDto>>> GetAllSurveyAnswerType();
    Task<ServiceResponse<GetSurveyAnswerTypeDto>> GetSurveyAnswerTypeByID(int id);
    Task<ServiceResponse<List<GetSurveyAnswerTypeDto>>> AddNewSurveyAnswerType(InsertSurveyAnswerTypeDto newSurveyAnswerType);
    Task<ServiceResponse<UpdateSurveyAnswerTypeDto>> UpdateSurveyAnswerType(UpdateSurveyAnswerTypeDto updateSurveyAnswerType);
    Task<ServiceResponse<GetSurveyAnswerTypeDto>> DeleteSurveyAnswerType(int id);

    Task<ServiceResponse<List<GetSurveyQuestionDto>>> GetAllSurveyQuestion();
    Task<ServiceResponse<GetSurveyQuestionDto>> GetSurveyQuestionByID(int id);
    Task<ServiceResponse<List<GetSurveyQuestionDto>>> GetSurveyQuestionBySurvTypeId(int id);
    Task<ServiceResponse<List<GetSurveyQesAnswerDto>>> GetSurveyQuestionAnswer(int id);
    Task<ServiceResponse<int>> AddNewSurveyQuestion(InsertSurveyQuestionDto newSurveyQuestion);
    Task<ServiceResponse<UpdateSurveyQuestionDto>> UpdateSurveyQuestion(UpdateSurveyQuestionDto updateSurveyQuestion);
    Task<ServiceResponse<GetSurveyQuestionDto>> DeleteSurveyQuestion(int id);

    Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> GetAllUserSurveyAnswer();
    Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> GetUserSurveyAnswerByID(int id);

    Task<ServiceResponse<bool>> CheckUserSurveyAnswerBySurveyTypeID(int id);
    Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> AddNewUserSurveyAnswer(InsertUserSurveyAnswerDto newUserSurveyAnswer);
    Task<ServiceResponse<List<GetUserSurveyAnswerDto>>> AddNewUserSurveyAnswerNoPortal(InsertUserSurveyAnswerNoPortalDto newUserSurveyAnswer);
    Task<ServiceResponse<UpdateUserSurveyAnswerDto>> UpdateUserSurveyAnswer(UpdateUserSurveyAnswerDto updateUserSurveyAnswer);
    Task<ServiceResponse<GetUserSurveyAnswerDto>> DeleteUserSurveyAnswer(int id);


    Task<ServiceResponse<List<GetUserSurveyAnswerTimeDto>>> GetAllUserSurveyAnswerTime();
    Task<ServiceResponse<List<object>>> GetUserSurveyAnswerTimeByAppointId(int id, int questionId);
    Task<ServiceResponse<GetUserSurveyAnswerTimeCountDto>> GetUserSurveyAnswerTimeCountByRequestId(int requestId);
    Task<ServiceResponse<List<GetUserSurveyAnswerTimeDto>>> AddNewUserSurveyAnswerTime(InsertUserSurveyAnswerTimeDto newUserSurveyAnswer);
    // Task<ServiceResponse<object>> GetSurveyQuestionAnswerVm(int SurveyTypeId);

    Task<ServiceResponse<List<GetUserSurveyListDto>>> GetAllUserSurveyList();
    Task<ServiceResponse<List<GetUserSurveyListDto>>> GetAllUserReportSurveyList();
    Task<ServiceResponse<GetUserSurveyListDto>> GetUserSurveyListByID(int id);
    Task<ServiceResponse<GetUserSurveyScoreDto>> GetUserSurveyListScore(int appid, int reqId, int survTypeID);
    Task<ServiceResponse<List<GetUserSurveyListDto>>> GetUserSurveyListByReqId(int id);
    Task<ServiceResponse<List<GetUserSurveyListDto>>> AddNewUserSurveyList(InsertUserSurveyListDto newSurvey);
    Task<ServiceResponse<UpdateUserSurveyListDto>> UpdateUserSurveyList(UpdateUserSurveyListDto updateSurvey);
    Task<ServiceResponse<UpdateUserSurveyListScoreAndInserted>> UpdateUserSurveyListScoreAndInserted(UpdateUserSurveyListScoreAndInserted updateSurvey);
    Task<ServiceResponse<UpdateUserSurveyListPladgeApproved>> UpdateUserSurveyListPladgeApproved(UpdateUserSurveyListPladgeApproved updateSurvey);
    Task<ServiceResponse<GetUserSurveyListDto>> DeleteUserSurveyList(int id);
}
