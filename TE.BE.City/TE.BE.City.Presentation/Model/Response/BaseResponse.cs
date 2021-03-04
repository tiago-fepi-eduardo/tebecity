using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TE.BE.City.Infra.CrossCutting;

namespace TE.BE.City.Presentation.Model
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ErrorDetail Error { get; set; }
    }
}
