using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.BE.City.Presentation.Model.Response
{
    public class OcorrencySearchResponseModel : BaseResponse
    {
        public OcorrencySearchResponseModel()
        {
            Ocorrencies = new List<OcorrencyResponseModel>();
        }
        public int Total { get; set; }
        public int Page { get; set; }
        public List<OcorrencyResponseModel> Ocorrencies { get; set; }
    }
}
