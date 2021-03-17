using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels;

namespace CramCoding.WebApp.AutoMapper
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest =>
                    dest.Header,
                    opt => opt.MapFrom(src => src.Header))
                .ForMember(dest =>
                    dest.Content,
                    opt => opt.MapFrom(src => src.Content));
        }
    }
}
