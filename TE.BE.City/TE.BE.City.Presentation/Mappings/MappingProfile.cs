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
            CreateMap<OcorrencyEntity, OcorrencyResponseModel>();
            CreateMap<OcorrencyDetailEntity, OcorrencyDetailResponseModel>();
            CreateMap<OrderStatusEntity, OrderStatusResponseModel>();

            CreateMap<OrderEntity, OrderResponseModel>()
                .ForMember(destination => destination.Ocorrency, map => {
                    map.PreCondition(src => (src.Ocorrency != null));
                    map.MapFrom(source => new OcorrencyResponseModel
                    {
                        Id = source.Ocorrency.Id,
                        Name = source.Ocorrency.Name,
                        Description = source.Ocorrency.Description,
                        CreatedAt = source.Ocorrency.CreatedAt.Date,
                        Closed = source.Ocorrency.Closed
                    });
                })
                .ForMember(destination => destination.OcorrencyDetail, map =>
                {
                    map.PreCondition(src => (src.Ocorrency != null && src.Ocorrency.OcorrencyDetail != null));
                    map.MapFrom(source => new OcorrencyDetailResponseModel
                    {
                        Id = source.Ocorrency.OcorrencyDetail.Id,
                        Description = source.Ocorrency.OcorrencyDetail.Description,
                        CreatedAt = source.Ocorrency.OcorrencyDetail.CreatedAt.Date,
                        Closed = source.Ocorrency.OcorrencyDetail.Closed
                    });
                })
                 .ForMember(destination => destination.OrderStatus, map =>
                 {
                     map.PreCondition(src => (src.OrderStatus != null));
                     map.MapFrom(source => new OrderStatusResponseModel
                     {
                         Id = source.OrderStatus.Id,
                         Name = source.OrderStatus.Name,
                         CreatedAt = source.OrderStatus.CreatedAt.Date,
                         Closed = source.Ocorrency.OcorrencyDetail.Closed
                     });
                 });
        }
    }
}
