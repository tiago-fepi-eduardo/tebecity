﻿using System;
using System.Collections.Generic;

namespace TE.BE.City.Presentation.Model.Response
{
    public class SewerSearchResponse : BaseResponse
    {
        public SewerSearchResponse()
        {
            Contacts = new List<SewerResponse>();
        }

        public int Total { get; set; }
        public int Page { get; set; }
        public List<SewerResponse> Contacts { get; set; }
    }
}
