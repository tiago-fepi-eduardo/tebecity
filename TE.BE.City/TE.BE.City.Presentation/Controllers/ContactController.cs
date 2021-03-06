﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting.Enum;
using TE.BE.City.Presentation.Model.Request;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ContactController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        /// <summary>
        /// Post new user.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactRequestModel request)
        {
            var contactEntity = new ContactEntity();
            contactEntity.Subject = request.Subject;
            contactEntity.Message = request.Message;
            contactEntity.Email = request.Email;
            contactEntity.Closed = false;
            contactEntity.CreatedAt = DateTime.Now.ToUniversalTime();

            var result = await _contactService.Post(contactEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// Get all item if id is null or 0. Get one item by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<ContactSearchResponseModel> Get(bool? closed, int skip=0, int limit=10, int id = 0)
        {
            var contactSearchResponseModel = new ContactSearchResponseModel();
            
            if (id > 0)
            {
                var userEntity = await _contactService.GetById(id);
                _mapper.Map(userEntity, contactSearchResponseModel.Contacts);
            }
            else if (closed != null)
            {
                var userEntity = await _contactService.GetClosed((bool)closed, skip, limit);
                _mapper.Map(userEntity, contactSearchResponseModel.Contacts);
            }
            else
            {
                var usersEntity = await _contactService.GetAll(skip, limit);
                _mapper.Map(usersEntity, contactSearchResponseModel.Contacts);
            }

            contactSearchResponseModel.Page = skip / limit;
            contactSearchResponseModel.Total = await _contactService.GetCount(closed);

            return contactSearchResponseModel;
        }

        /// <summary>
        /// Update one item.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ContactRequestModel request)
        {
            var contactEntity = new ContactEntity();
            contactEntity.Id = request.Id;
            contactEntity.Closed = (bool)request.Closed;
            contactEntity.CreatedAt = DateTime.Now.ToUniversalTime();

            var result = await _contactService.Put(contactEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// delete one item.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _contactService.Delete(id);

            return Response(result.IsSuccess,null);
        }
    }
}