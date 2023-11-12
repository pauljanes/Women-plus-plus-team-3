using WebAPI_dev.Dtos.Survey;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System.Text.Json;

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

        public async Task<ServiceResponse<GetSurveyResponseDto>> GetDataFromSurveySheet(int id)
        {
            Survey survey = new Survey { Id = 1, Name = "", Summary = "" };

            // Load credentials from the JSON file
            var credential = GoogleCredential.FromFile("surveyCredential.json")
                .CreateScoped("https://www.googleapis.com/auth/spreadsheets");

            // Create Google Sheets API service
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "WomenPlusPlus",
            });

            // Specify the spreadsheet ID and range
            string spreadsheetId = "your-spreadsheet-id";
            string range = "Sheet1!A1:B10"; // Update with your actual sheet and range

            // Make the request to retrieve values
            var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = request.Execute();

            // Access the values in the response
            var values = response.Values;

            //Add response into survey summary - parse json 
            survey.Summary = JsonSerializer.Serialize(values);

            var serviceResponse = new ServiceResponse<GetSurveyResponseDto>();
            serviceResponse.Data = _mapper.Map<GetSurveyResponseDto>(survey);
            return serviceResponse;

        }


    }
}
