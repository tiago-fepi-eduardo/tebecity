using System;

namespace TE.BE.City.Presentation.Model.Response
{
    public class NewsResponseModel : BaseResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Closed { get; set; }
    }
}
