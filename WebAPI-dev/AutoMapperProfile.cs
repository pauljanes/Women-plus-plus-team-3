using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_dev.Dtos.Survey;

namespace WebAPI_dev
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Survey, GetSurveyResponseDto>();

        }
    }
}