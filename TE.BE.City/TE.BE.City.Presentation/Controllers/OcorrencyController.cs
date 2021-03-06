﻿using AutoMapper;
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
    public class OcorrencyController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IOcorrencyService _ocorrencyService;

        public OcorrencyController(IOcorrencyService ocorrencyService, IMapper mapper)
        {
            _ocorrencyService = ocorrencyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all item.
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        [HttpGet]
        public async Task<OcorrencySearchResponseModel> Get(int id, int skip = 0, int limit = 50)
        {
            var ocorrencySearchResponseModel = new OcorrencySearchResponseModel();
            IEnumerable<OcorrencyEntity> ocorrencyEntity;

            if (id > 0)
            {
                ocorrencyEntity = await _ocorrencyService.GetById(id);
                ocorrencySearchResponseModel.Total = ocorrencyEntity.Count();
            }
            else
            {
                ocorrencyEntity = await _ocorrencyService.GetAll(false, skip, limit);
                ocorrencySearchResponseModel.Total = await _ocorrencyService.GetCount(false);
            }

            _mapper.Map(ocorrencyEntity, ocorrencySearchResponseModel.Ocorrencies);

            return ocorrencySearchResponseModel;
        }
    }
}
