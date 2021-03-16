using System;
using System.Collections.Generic;

namespace TE.BE.City.Presentation.Model.Response
{
    public class NewsSearchResponseModel : BaseResponse
    {
        public NewsSearchResponseModel()
        {
            News = new List<NewsResponseModel>();
        }

        public int Total { get; set; }
        public int Page { get; set; }
        public List<NewsResponseModel> News { get; set; }
    }
}
