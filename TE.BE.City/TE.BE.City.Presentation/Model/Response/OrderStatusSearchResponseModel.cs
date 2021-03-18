using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.BE.City.Presentation.Model.Response
{
    public class OrderStatusSearchResponseModel : BaseResponse
    {
        public OrderStatusSearchResponseModel()
        {
            OrderStatus = new List<OrderStatusResponseModel>();
        }
        public int Total { get; set; }
        public int Page { get; set; }
        public List<OrderStatusResponseModel> OrderStatus { get; set; }
    }
}
