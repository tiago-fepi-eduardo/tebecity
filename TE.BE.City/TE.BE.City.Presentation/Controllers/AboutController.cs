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
    public class AboutController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get all item if id is null or 0. Get one item by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<AboutResponseModel> Get()
        {
            var aboutResponseModel = new AboutResponseModel();

            try
            {
                var aboutEntity = await _aboutService.Get();
                _mapper.Map(aboutEntity, aboutResponseModel);
            }
            catch (Exception ex)
            {
                /*
                aboutResponseModel.Error = new Model.BaseErrorResponse()
                {
                    Code = ex.HResult,
                    Type = ex.StackTrace,
                    Message = ex.Message
                };
                */
            }

            return aboutResponseModel;
        }
    }
}
