﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Request;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AsphaltController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAsphaltService _asphaltService;

        public AsphaltController(IAsphaltService asphaltService, IMapper mapper)
        {
            _asphaltService = asphaltService;
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
        public async Task<AsphaltSearchResponse> Get(int id, int ocorrencyId, int skip = 0, int limit = 50)
        {
            var asphaltSearchResponse = new AsphaltSearchResponse();
            
            if (id > 0)
            {
                var asphaltEntity = await _asphaltService.GetById(id);
                _mapper.Map(asphaltEntity, asphaltSearchResponse.AsphaltList);
                asphaltSearchResponse.Total = asphaltEntity.Count();
            }
            else if (ocorrencyId > 0)
            {
                var asphaltEntity = await _asphaltService.GetByOcorrencyId(false, ocorrencyId);
                _mapper.Map(asphaltEntity, asphaltSearchResponse.AsphaltList);
                asphaltSearchResponse.Total = asphaltEntity.Count();
            }
            else
            {
                var asphaltEntity = await _asphaltService.GetAll(false, skip, limit);
                _mapper.Map(asphaltEntity, asphaltSearchResponse.AsphaltList);
                asphaltSearchResponse.Total = await _asphaltService.GetCount(false);
            }

            return asphaltSearchResponse;
        }

        /// <summary>
        /// Post new item.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AsphaltRequest request)
        {
            var asphaltEntity = new AsphaltEntity();
            asphaltEntity.Longitude = request.Longitude;
            asphaltEntity.Latitude = request.Latitude;
            asphaltEntity.IsPaved = request.IsPaved;
            asphaltEntity.HasHoles = request.HasHoles;
            asphaltEntity.HasPavedSidewalks = request.HasPavedSidewalks;
            asphaltEntity.CreatedAt = DateTime.Now.ToUniversalTime();
            asphaltEntity.UserId = request.UserId;
            asphaltEntity.StatusId = request.StatusId;

            var result = await _asphaltService.Post(asphaltEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// Update one item.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AsphaltRequest request)
        {
            var asphaltEntity = new AsphaltEntity();
            asphaltEntity.Id = request.Id;
            asphaltEntity.CreatedAt = DateTime.Now.ToUniversalTime();

            var result = await _asphaltService.Put(asphaltEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// delete one item.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _asphaltService.Delete(id);

            return Response(result.IsSuccess, null);
        }
    }
}
