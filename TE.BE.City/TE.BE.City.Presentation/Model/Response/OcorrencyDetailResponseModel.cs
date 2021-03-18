using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.BE.City.Presentation.Model.Response
{
    public class OcorrencyDetailResponseModel : BaseResponse
    {
        public string Description { get; set; }
        public bool Closed { get; set; }
        public int OcorrencyId { get; set; }
    }
}
