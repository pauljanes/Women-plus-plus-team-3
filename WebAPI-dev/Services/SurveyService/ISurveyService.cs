using WebAPI_dev.Dtos.Survey;

namespace WebAPI_dev.Services.SurveyService
{
    public interface ISurveyService
    {
        Task<ServiceResponse<List<GetSurveyResponseDto>>> GetAllSurvey();
        Task<ServiceResponse<GetSurveyResponseDto>> GetSurveyById(int id);
        Task<ServiceResponse<GetSurveyResponseDto>> GetDataFromSurveySheet(int id);
    }
}