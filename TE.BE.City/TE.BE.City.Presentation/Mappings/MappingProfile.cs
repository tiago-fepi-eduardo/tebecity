using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserResponseModel>();
            CreateMap<AboutEntity, AboutResponseModel>();
            CreateMap<ContactEntity, ContactResponseModel>();
            CreateMap<UserEntity, AuthenticateResponseModel>();
        }
    }
}
