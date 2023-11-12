using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_dev.Dtos.Survey
{
    public class GetSurveyResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Summary { get; set; }
    }
}