using System;

namespace TE.BE.City.Presentation.Model.Response
{
    public class ContactResponseModel : BaseResponse
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
