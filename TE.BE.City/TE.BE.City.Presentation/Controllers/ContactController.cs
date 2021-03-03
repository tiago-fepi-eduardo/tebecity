using AutoMapper;
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
            try
            {
                var contactEntity = new ContactEntity();
                contactEntity.Subject = request.Subject;
                contactEntity.Message = request.Message;
                contactEntity.Email = request.Email;
                
                return Response(true, await _contactService.Post(contactEntity));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }

        /// <summary>
        /// Get all item if id is null or 0. Get one item by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<IEnumerable<ContactResponseModel>> Get(int id = 0)
        {
            var usersResponseModel = new List<ContactResponseModel>();
            
            try
            {
                if (id > 0)
                {
                    var userEntity = await _contactService.GetById(id);
                    _mapper.Map(userEntity, usersResponseModel);
                }
                else
                {
                    var usersEntity = await _contactService.GetAll();
                    _mapper.Map(usersEntity, usersResponseModel);
                }
            }
            catch (Exception ex)
            {
                var exception = new ContactResponseModel()
                {
                    Error = new Model.BaseErrorResponse()
                    {
                        Code = ex.HResult,
                        Type = ex.StackTrace,
                        Message = ex.Message
                    }
                };
                usersResponseModel.Add(exception);
                return usersResponseModel;
            }

            return usersResponseModel;
        }

        /// <summary>
        /// Update one item.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ContactRequestModel request)
        {
            try
            {
                var contactEntity = new ContactEntity();
                contactEntity.Id = request.Id;
                contactEntity.Subject = request.Subject;
                contactEntity.Message = request.Message;
                contactEntity.Email = request.Email;

                return Response(true, await _contactService.Put(contactEntity));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }

        /// <summary>
        /// delete one item.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Response(true, await _contactService.Delete(id));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }
    }
}
