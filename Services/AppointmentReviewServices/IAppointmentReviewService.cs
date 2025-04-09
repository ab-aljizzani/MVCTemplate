using System;
using ClinicApi.Dtos.ApoointmentReviewDto.Get;
using ClinicApi.Dtos.ApoointmentReviewDto.Insert;
using ClinicApi.Dtos.ApoointmentReviewDto.Update;
using ClinicApi.Models.AppintmentReviewModel;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.AppointmentReviewServices;

public interface IAppointmentReviewService
{
    Task<ServiceResponse<List<GetAppointmentReviewDto>>> GetAllAppointmentReview();
    Task<ServiceResponse<List<object>>> GetAppointmentReviewByAppointmentId(int id);
    Task<ServiceResponse<GetAppointmentReviewDto>> GetAppointmentReviewByID(int id);
    Task<ServiceResponse<List<GetAppointmentReviewDto>>> AddNewAppointmentReview(InsertAppointmentReviewDto newAppointmentReview);
    Task<ServiceResponse<GetAppointmentReviewDto>> UpdateAppointmentReview(UpdateAppointmentReview_Dto updateAppointmentReview);
    Task<ServiceResponse<GetAppointmentReviewDto>> DeleteAppointmentReview(int id);
}
