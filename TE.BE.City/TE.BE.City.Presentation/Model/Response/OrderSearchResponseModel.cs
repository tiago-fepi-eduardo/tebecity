using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TE.BE.City.Presentation.Model.Response
{
    /// <summary>
    /// Model responsable for itens on the user interface. It represent the user interface. Not related to the database tables or domain layer.
    /// </summary>
    public class OrderSearchResponseModel : BaseResponse
    {
        public OrderSearchResponseModel()
        {
            Orders = new List<OrderResponseModel>();
        }
        public int Total { get; set; }
        public int Page { get; set; }
        public List<OrderResponseModel> Orders { get; set; }
    }   
}
