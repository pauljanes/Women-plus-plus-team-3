using Microsoft.AspNetCore.Mvc;
using WebAPI_dev.Dtos.Survey;


namespace WebAPI_dev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {

        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSurveyResponseDto>>>> Get()
        {
            return Ok(await _surveyService.GetAllSurvey());
        }

        [HttpGet("GetSheetById{id}")]
        public async Task<ActionResult<ServiceResponse<GetSurveyResponseDto>>> GetSingle(int id)
        {
            var response = await _surveyService.GetSurveyById(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetDataFromSheetByKey{key}")]
        public async Task<ActionResult<ServiceResponse<GetSurveyResponseDto>>> GetDataFromSurveySheet(string key)
        {
            var response = await _surveyService.GetDataFromSurveySheet(key);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}