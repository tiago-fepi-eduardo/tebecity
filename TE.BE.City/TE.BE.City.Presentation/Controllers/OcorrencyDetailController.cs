using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OcorrencyDetailController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IOcorrencyDetailService _ocorrencyDetailService;

        public OcorrencyDetailController(IOcorrencyDetailService ocorrencyDetailService, IMapper mapper)
        {
            _ocorrencyDetailService = ocorrencyDetailService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all item.
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        [HttpGet]
        public async Task<OcorrencyDetailSearchResponseModel> Get(int skip = 0, int limit = 50)
        {
            var ocorrencyDetailSearchResponseModel = new OcorrencyDetailSearchResponseModel();
                       
            var ocorrencyDetailEntity = await _ocorrencyDetailService.GetAll(skip, limit);
            _mapper.Map(ocorrencyDetailEntity, ocorrencyDetailSearchResponseModel.OcorrencyDetails);
           
            return ocorrencyDetailSearchResponseModel;
        }
    }
}
