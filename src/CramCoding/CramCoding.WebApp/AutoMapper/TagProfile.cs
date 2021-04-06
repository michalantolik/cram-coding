using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Tag;

namespace CramCoding.WebApp.AutoMapper
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, EditTagViewModel>()
                .ForMember(dest =>
                    dest.TagName,
                    opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
