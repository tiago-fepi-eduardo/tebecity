﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TE.BE.City.Presentation.Model.Response
{
    /// <summary>
    /// Model responsable for itens on the user interface. It represent the user interface. Not related to the database tables or domain layer.
    /// </summary>
    public class OrderResponseModel : BaseResponse
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public OcorrencyResponseModel Ocorrency { get; set; }
        public OcorrencyDetailResponseModel OcorrencyDetail { get; set; }
        public OrderStatusResponseModel OrderStatus { get; set; }
    }   
}
