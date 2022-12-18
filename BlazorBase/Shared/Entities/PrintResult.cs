using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBase.Shared.Entities
{
    public class PrintResult
    {
        public PrintResult()
        {

        }

        public PrintResult(string filename, RequestResult requestResult)
        {
            Filename = filename;
            RequestResult = requestResult;
        }

        public string? Filename { get; set; } 
        public RequestResult? RequestResult { get; set; }
    }
}
