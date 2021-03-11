using System.ComponentModel.DataAnnotations;

namespace TE.BE.City.Presentation.Model.Request
{
    public class ContactRequestModel
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Closed { get; set; }
    }
}
