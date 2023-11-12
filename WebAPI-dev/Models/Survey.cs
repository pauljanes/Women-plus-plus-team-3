using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_dev.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public string? Key { get; set; }
        public string Name { get; set; } = "";
        public string? Summary { get; set; }
    }
}