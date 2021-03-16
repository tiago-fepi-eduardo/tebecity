using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all item if id is null or 0. Get one item by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<NewsSearchResponseModel> Get(bool? closed, int skip=0, int limit=10, int id = 0)
        {
            var newsSearchResponseModel = new NewsSearchResponseModel();

            if (id > 0)
            {
                var userEntity = await _newsService.GetById(id);
                _mapper.Map(userEntity, newsSearchResponseModel.News);
            }
            else if (closed != null)
            {
                var userEntity = await _newsService.GetClosed((bool)closed, skip, limit);
                _mapper.Map(userEntity, newsSearchResponseModel.News);
            }
            else
            {
                var usersEntity = await _newsService.GetAll(skip, limit);
                _mapper.Map(usersEntity, newsSearchResponseModel.News);
            }

            newsSearchResponseModel.Page = skip / limit;
            newsSearchResponseModel.Total = await _newsService.GetCount(closed);

            return newsSearchResponseModel;
        }
    }
}
