using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.BE.City.Presentation.Model
{
    public class BaseErrorResponse
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
