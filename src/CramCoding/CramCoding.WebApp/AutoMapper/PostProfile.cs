using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Post;
using CramCoding.WebApp.ViewModels.Home.Post;

namespace CramCoding.WebApp.AutoMapper
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, AdminPostViewModel>()
                .ForMember(dest =>
                    dest.Header,
                    opt => opt.MapFrom(src => src.Header))
                .ForMember(dest =>
                    dest.Content,
                    opt => opt.MapFrom(src => src.Content));

            CreateMap<Post, HomePostViewModel>()
                .ForMember(dest =>
                    dest.Header,
                    opt => opt.MapFrom(src => src.Header))
                .ForMember(dest =>
                    dest.Content,
                    opt => opt.MapFrom(src => src.Content));
        }
    }
}
