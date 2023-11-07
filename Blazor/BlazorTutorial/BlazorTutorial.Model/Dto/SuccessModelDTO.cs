using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorial.Model.Dto
{
    public class SuccessModelDTO
    {
        public int StatusCode { get; set; }
        public string SuccessMessage { get; set; }
        public object Data { get; set; }
    }
}
