using ClinicApi.Dtos.RequestDto.Get;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RequestDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.ViewModel.Statistics;
using System;

namespace ClinicApi.Services.Request;

public interface IRequestService
{
  Task<ServiceResponse<List<GetRequestDto>>> GetAllRequest();
  Task<ServiceResponse<object>> GetRequestByID(int id);
  Task<ServiceResponse<List<GetRequestDto>>> GetRequestByPersonId(int id);
  Task<ServiceResponse<List<GetRequestDto>>> GetRequestByPersonIdAndReqId(int id, int reqId);
  Task<ServiceResponse<int>> AddNewRequest(InsertRequestDto newRequest);
  Task<ServiceResponse<UpdateRequestDto>> UpdateRequest(UpdateRequestDto updateRequest);
  Task<ServiceResponse<UpdateRequestDto>> UpdateRequestAppsentReason(UpdateRequestAppsentReasonDto updateRequest);
  Task<ServiceResponse<UpdateRequestDto>> UpdateRequestStatusId(UpdateRequestStatusIdDto updateRequest);
    Task<ServiceResponse<UpdateRequestDto>> UpdateRequestShowUp(UpdateRequestShowupDto updateRequest);
    Task<ServiceResponse<UpdateRequestDto>> UpdateRequesIsSurveyInserted(UpdateRequestSurveyInsertedDto updateRequest);
  Task<ServiceResponse<UpdateRequestDto>> UpdateReqAppointmentId(UpdateReqAppointmentIdDto updateRequest);
  Task<ServiceResponse<GetRequestDto>> DeleteRequest(int id);
    Task<ServiceResponse<List<DoctorStatisticsVm>>> GetRequestsStatistics();

    Task<ServiceResponse<List<GetRequestStatusDto>>> GetAllRequestStatus();
  Task<ServiceResponse<GetRequestStatusDto>> GetRequestStatusByID(int id);
  Task<ServiceResponse<List<GetRequestStatusDto>>> AddNewRequestStatus(InsertRequestStatusDto newRequestStatus);
  Task<ServiceResponse<UpdateRequestStatusDto>> UpdateRequestStatus(UpdateRequestStatusDto updateRequestStatus);
  Task<ServiceResponse<GetRequestStatusDto>> DeleteRequestStatus(int id);

  Task<ServiceResponse<List<GetRequestTypeDto>>> GetAllRequestType();
  Task<ServiceResponse<GetRequestTypeDto>> GetRequestTypeByID(int id);
  Task<ServiceResponse<List<GetRequestTypeDto>>> AddNewRequestType(InsertRequestTypeDto newRequestType);
  Task<ServiceResponse<UpdateRequestTypeDto>> UpdateRequestType(UpdateRequestTypeDto updateRequestType);
  Task<ServiceResponse<GetRequestTypeDto>> DeleteRequestType(int id);
}
