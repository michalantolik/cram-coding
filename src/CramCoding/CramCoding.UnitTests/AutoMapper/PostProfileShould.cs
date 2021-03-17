using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels;
using Xunit;

namespace CramCoding.UnitTests.AutoMapper
{
    public class PostProfileShould
    {
        [Fact]
        public void MapPostEntityToViewModel()
        {
            // ARRANGE
            var postEntity = new Post
            {
                Header = "Header 123",
                Content = "Best post content for tests ever"
            };

            // ACT
            var mapper = CreateSut();
            var postViewModel = mapper.Map<PostViewModel>(postEntity);

            // ASSERT
            Assert.Equal(postEntity.Header, postViewModel.Header);
            Assert.Equal(postEntity.Content, postViewModel.Content);
        }

        internal IMapper CreateSut()
        {
            return AutoMapperFactory.Create();
        }
    }
}
