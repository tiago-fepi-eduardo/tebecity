﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Request;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TrashController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITrashService _trashService;

        public TrashController(ITrashService trashService, IMapper mapper)
        {
            _trashService = trashService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all item if id is null or 0. Get one item by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<TrashSearchResponse> Get(bool? closed, int skip = 0, int limit = 10, int id = 0)
        {
            var trashSearchResponse = new TrashSearchResponse();

            if (id > 0)
            {
                var userEntity = await _trashService.GetById(id);
                _mapper.Map(userEntity, trashSearchResponse.TrashList);
            }
            else if (closed != null)
            {
                var userEntity = await _trashService.GetClosed((bool)closed, skip, limit);
                _mapper.Map(userEntity, trashSearchResponse.TrashList);
            }
            else
            {
                var usersEntity = await _trashService.GetAll(skip, limit);
                _mapper.Map(usersEntity, trashSearchResponse.TrashList);
            }

            trashSearchResponse.Page = skip / limit;
            trashSearchResponse.Total = await _trashService.GetCount(closed);

            return trashSearchResponse;
        }

        /// <summary>
        /// Post new user.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TrashRequest request)
        {
            var trashEntity = new TrashEntity();
            trashEntity.Longitude = request.Longitude;
            trashEntity.Latitude = request.Latitude;
            trashEntity.HasRoadcleanUp = request.HasRoadcleanUp;
            trashEntity.HowManyTimes = request.HowManyTimes;
            trashEntity.HasAccumulatedTrash = request.HasAccumulatedTrash;
            trashEntity.CreatedAt = DateTime.Now.ToUniversalTime();
            trashEntity.UserId = request.UserId;
            trashEntity.StatusId = request.StatusId;

            var result = await _trashService.Post(trashEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// Update one item.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TrashRequest request)
        {
            var trashEntity = new TrashEntity();
            trashEntity.Id = request.Id;
            trashEntity.Longitude = request.Longitude;
            trashEntity.Latitude = request.Latitude;
            trashEntity.HasRoadcleanUp = request.HasRoadcleanUp;
            trashEntity.HowManyTimes = request.HowManyTimes;
            trashEntity.HasAccumulatedTrash = request.HasAccumulatedTrash;
            trashEntity.CreatedAt = DateTime.Now.ToUniversalTime();
            trashEntity.UserId = request.UserId;
            trashEntity.StatusId = request.StatusId;

            var result = await _trashService.Put(trashEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// delete one item.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _trashService.Delete(id);

            return Response(result.IsSuccess, null);
        }
    }
}
