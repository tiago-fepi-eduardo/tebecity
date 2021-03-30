using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
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
        /// <param name="id"></param>
        /// <param name="ocorrencyId"></param>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        [HttpGet]
        public async Task<OcorrencyDetailSearchResponseModel> Get(int id, int ocorrencyId, int skip = 0, int limit = 50)
        {
            var ocorrencyDetailSearchResponseModel = new OcorrencyDetailSearchResponseModel();
            IEnumerable<OcorrencyDetailEntity> ocorrencyDetailsEntity = null;
            
            if (id > 0)
            {
                ocorrencyDetailsEntity = await _ocorrencyDetailService.GetById(id);
                ocorrencyDetailSearchResponseModel.Total = ocorrencyDetailsEntity.Count();
            }
            else if (ocorrencyId > 0)
            {
                ocorrencyDetailsEntity = await _ocorrencyDetailService.GetByOcorrencyId(false, ocorrencyId);
                ocorrencyDetailSearchResponseModel.Total = ocorrencyDetailsEntity.Count();
            }
            else
            {
                ocorrencyDetailsEntity = await _ocorrencyDetailService.GetAll(false, skip, limit);
                ocorrencyDetailSearchResponseModel.Total = await _ocorrencyDetailService.GetCount(false);
            }

            _mapper.Map(ocorrencyDetailsEntity, ocorrencyDetailSearchResponseModel.OcorrencyDetails);

            return ocorrencyDetailSearchResponseModel;
        }
    }
}
