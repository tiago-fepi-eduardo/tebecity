using System;
using System.ComponentModel.DataAnnotations;

namespace TE.BE.City.Presentation.Model
{
    /// <summary>
    /// Model responsable for itens on the user interface. It represent the user interface. Not related to the database tables or domain layer.
    /// </summary>
    public class OrderRequestModel
    {
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int OcorrencyId { get; set; }
        public int OcorrencyDetailId { get; set; }
        public int OrderStatusId { get; set; }
    }   
}
