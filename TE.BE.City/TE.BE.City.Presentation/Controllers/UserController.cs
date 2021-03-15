using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Request;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<AuthenticateResponseModel> Authenticate([FromBody] AuthenticateRequestModel model)
        {
            var authenticateResponseModel = new AuthenticateResponseModel();
            
            var userEntity = await _userService.Authenticate(model.Username, model.Password);

            _mapper.Map(userEntity, authenticateResponseModel);
            
            return authenticateResponseModel;
        }

        /// <summary>
        /// Post new user.
        /// </summary>
        /// <param name="request"></param>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserRequestModel request)
        {
            var userResponseModel = new UserResponseModel();

            var userEntity = new UserEntity();
            userEntity.FirstName = request.FirstName;
            userEntity.LastName = request.LastName;
            userEntity.Username = request.Username;
            userEntity.Password = request.Password;
            userEntity.Active = true;
            userEntity.Block = false;
            userEntity.RoleId = request.RoleId;
            userEntity.CreatedAt = DateTime.Now.ToUniversalTime();

            var result = await _userService.Post(userEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// Get all item if id is null or 0. Get one item by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<IEnumerable<UserResponseModel>> Get(int id = 0)
        {
            var usersResponseModel = new List<UserResponseModel>();
           
            if (id > 0)
            {
                var userEntity = await _userService.GetById(id);
                _mapper.Map(userEntity, usersResponseModel);
            }
            else
            {
                var usersEntity = await _userService.GetAll();
                _mapper.Map(usersEntity, usersResponseModel);
            }
            
            return usersResponseModel;
        }

        /// <summary>
        /// Update one item.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserRequestModel request)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = request.Id;
            userEntity.FirstName = request.FirstName;
            userEntity.LastName = request.LastName;
            userEntity.Username = request.Username;
            userEntity.Password = request.Password;
            userEntity.RoleId = request.RoleId;
            userEntity.CreatedAt = DateTime.Now.ToUniversalTime();

            var result = await _userService.Put(userEntity);

            return Response(result.IsSuccess, null);
        }

        /// <summary>
        /// delete one item.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            return Response(result.IsSuccess, null);
        }
    }
}
