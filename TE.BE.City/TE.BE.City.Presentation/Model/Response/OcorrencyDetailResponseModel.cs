﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.BE.City.Presentation.Model
{
    public class OcorrencyDetailResponseModel : BaseResponse
    {
        public string Description { get; set; }
        public OcorrencyResponseModel OcorrencyId { get; set; }
    }
}
