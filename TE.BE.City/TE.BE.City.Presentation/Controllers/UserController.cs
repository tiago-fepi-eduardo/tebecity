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

            if (userEntity == null)
            {
                return new AuthenticateResponseModel()
                {
                    Error = new Model.BaseErrorResponse()
                    {
                        Code = (int)ErrorCode.UserNotIdentified,
                        Type = ErrorCode.UserNotIdentified.ToString(),
                        Message = ErrorCode.UserNotIdentified.ToString()
                    }
                };
            }

            return authenticateResponseModel;
        }

        /// <summary>
        /// Post new user.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserRequestModel request)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = request.FirstName;
                userEntity.LastName = request.LastName;
                userEntity.Username = request.Username;
                userEntity.Password = request.Password;

                return Response(true, await _userService.Post(userEntity));
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
        public async Task<IEnumerable<UserResponseModel>> Get(int id = 0)
        {
            var usersResponseModel = new List<UserResponseModel>();
            
            try
            {
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
            }
            catch (Exception ex)
            {
                var exception = new UserResponseModel()
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
        public async Task<ActionResult> Put([FromBody] UserRequestModel request)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.Id = request.Id;
                userEntity.FirstName = request.FirstName;
                userEntity.LastName = request.LastName;
                userEntity.Username = request.Username;
                userEntity.Password = request.Password;

                return Response(true, await _userService.Put(userEntity));
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
                return Response(true, await _userService.Delete(id));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }
    }
}
