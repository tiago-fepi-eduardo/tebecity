using System;

namespace TE.BE.City.Presentation.Model.Response
{
    public class UserResponseModel : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
        public bool Block { get; set; }
    }
}
