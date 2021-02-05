using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.BE.City.Presentation.Model
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public BaseErrorResponse Error { get; set; }
    }
}
