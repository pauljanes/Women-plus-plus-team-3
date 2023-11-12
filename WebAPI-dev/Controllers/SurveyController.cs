using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_dev.Dtos.Survey;
using WebAPI_dev.Services.SurveyService;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSurveyResponseDto>>> GetSingle(int id)
        {
            var response = await _surveyService.GetSurveyById(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}