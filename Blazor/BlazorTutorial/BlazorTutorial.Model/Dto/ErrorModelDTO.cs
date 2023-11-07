using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorial.Model.Dto
{
    public class ErrorModelDTO
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
