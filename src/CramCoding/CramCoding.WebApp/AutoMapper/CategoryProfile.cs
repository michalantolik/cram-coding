using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.ViewComponents.CategoryMenu;
using System.Linq;

namespace CramCoding.WebApp.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest =>
                    dest.CategoryName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Subcategories,
                    opt => opt.MapFrom(src => src.Children.Select(c => c.Name).ToArray()));
        }
    }
}
