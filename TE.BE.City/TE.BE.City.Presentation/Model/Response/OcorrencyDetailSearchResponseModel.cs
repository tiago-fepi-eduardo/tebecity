using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.BE.City.Presentation.Model.Response
{
    public class OcorrencyDetailSearchResponseModel : BaseResponse
    {
        public OcorrencyDetailSearchResponseModel()
        {
            OcorrencyDetails = new List<OcorrencyDetailResponseModel>();
        }
        public int Total { get; set; }
        public int Page { get; set; }
        public List<OcorrencyDetailResponseModel> OcorrencyDetails { get; set; }
    }
}
