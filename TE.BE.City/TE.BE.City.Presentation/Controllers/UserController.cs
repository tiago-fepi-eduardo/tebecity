using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Request;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequestModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
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
        public async Task<ActionResult> Get(int id = 0)
        {
            try
            {
                if (id > 0)
                    return Response(true, await _userService.GetById(id));
                else
                    return Response(true, await _userService.GetAll());
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
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
