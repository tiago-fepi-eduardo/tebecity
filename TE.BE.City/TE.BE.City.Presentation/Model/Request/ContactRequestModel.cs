using System.ComponentModel.DataAnnotations;

namespace TE.BE.City.Presentation.Model.Request
{
    public class ContactRequestModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public bool? Closed { get; set; }
    }
}
