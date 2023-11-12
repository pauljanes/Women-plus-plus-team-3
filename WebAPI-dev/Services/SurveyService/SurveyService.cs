using WebAPI_dev.Dtos.Survey;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System.Text.Json;
using System;
using System.IO;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;

namespace WebAPI_dev.Services.SurveyService
{
    public class SurveyService : ISurveyService
    {
        private static List<Survey> surveys = new List<Survey> {
            new Survey { Id = 1, Name = "Eg1", Summary = "" },
            new Survey { Id = 2, Name = "EG2", Summary = "" }
        };

        private readonly IMapper _mapper;

        public SurveyService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetSurveyResponseDto>>> GetAllSurvey()
        {
            var serviceResponse = new ServiceResponse<List<GetSurveyResponseDto>>();
            serviceResponse.Data = surveys.Select(c => _mapper.Map<GetSurveyResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSurveyResponseDto>> GetSurveyById(int id)
        {
            var serviceResponse = new ServiceResponse<GetSurveyResponseDto>();
            try
            {
                var survey = surveys.FirstOrDefault(c => c.Id == id) ?? throw new Exception($"Survey with ID '{id} not found! ");
                serviceResponse.Data = _mapper.Map<GetSurveyResponseDto>(survey);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSurveyResponseDto>> GetDataFromSurveySheet(string key)
        {


            // Replace with the path to your credentials JSON file
            string credentialsPath = "Files/womenplusplus-3efa728a100f.json";

            // Specify the spreadsheet ID and range
            string spreadsheetId = "1QLDdgUndRdgYSJfT9Ynn6a8voyHcwGg1cHl65Wdiq5Y";
            string range = "'Form Responses 1'!A:E";

            // Authenticate using the credentials file
            var credential = GoogleCredential.FromFile(credentialsPath)
                .CreateScoped("https://www.googleapis.com/auth/spreadsheets");

            // Create Google Sheets API service
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "WomenPlusPlus",
            });

            // Make the request to retrieve values
            var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = request.Execute();

            // Access the values in the response
            var values = response.Values;

            //Add response into survey summary - parse json           
            Survey survey = new Survey { Id = 1, Key = "1QLDdgUndRdgYSJfT9Ynn6a8voyHcwGg1cHl65Wdiq5Y", Name = "Form Responses 1" };
            survey.Summary = JsonSerializer.Serialize(values);

            var serviceResponse = new ServiceResponse<GetSurveyResponseDto>();
            serviceResponse.Data = _mapper.Map<GetSurveyResponseDto>(survey);
            return serviceResponse;
        }
    }
}
