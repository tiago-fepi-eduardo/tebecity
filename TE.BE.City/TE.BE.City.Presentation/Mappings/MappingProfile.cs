using AutoMapper;
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
            CreateMap<NewsEntity, NewsResponseModel>();

            CreateMap<OrderEntity, OrderResponseModel>()
                .ForMember(destination => destination.Ocorrency, map => map.MapFrom(source => new OcorrencyResponseModel
                {
                    Id = source.Ocorrency.Id,
                    Name = source.Ocorrency.Name,
                    Description = source.Ocorrency.Description,
                    CreatedAt = source.Ocorrency.CreatedAt,
                    Closed = source.Ocorrency.Closed
                }))
                .ForMember(destination => destination.OcorrencyDetail, map => map.MapFrom(source => new OcorrencyDetailResponseModel
                 {
                     Id = source.Ocorrency.OcorrencyDetail.Id,
                     Description = source.Ocorrency.OcorrencyDetail.Description,
                     CreatedAt = source.Ocorrency.OcorrencyDetail.CreatedAt,
                     Closed = source.Ocorrency.OcorrencyDetail.Closed
                }))
                 .ForMember(destination => destination.OrderStatus, map => map.MapFrom(source => new OrderStatusResponseModel
                 {
                     Id = source.OrderStatus.Id,
                     Name = source.OrderStatus.Name,
                     CreatedAt = source.OrderStatus.CreatedAt,
                     Closed = source.Ocorrency.OcorrencyDetail.Closed
                 }));
        }
    }
}
