using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Tag;
using Xunit;

namespace CramCoding.UnitTests.AutoMapper
{
    public class TagProfileShould
    {
        [Theory]
        [InlineData("architecture")]
        [InlineData("javascript")]
        [InlineData("web-development")]
        public void MapTagEntityToEditTagViewModel(string tagName)
        {
            // ARRANGE
            var tagEntity = new Tag
            {
                Name = tagName
            };

            // ACT
            var mapper = CreateSut();
            var editTagViewModel = mapper.Map<EditTagViewModel>(tagEntity);

            // ASSERT
            Assert.Equal(tagName, editTagViewModel.TagName);
        }

        [Theory]
        [InlineData("architecture")]
        [InlineData("javascript")]
        [InlineData("web-development")]
        public void MapEditTagViewModelToTagEntity(string tagName)
        {
            // ARRANGE
            var editTagViewModel = new EditTagViewModel
            {
                TagName = tagName
            };

            // ACT
            var mapper = CreateSut();
            var tagEntity = mapper.Map<Tag>(editTagViewModel);

            // ASSERT
            Assert.Equal(tagName, tagEntity.Name);
        }

        internal IMapper CreateSut()
        {
            return AutoMapperFactory.Create();
        }
    }
}
