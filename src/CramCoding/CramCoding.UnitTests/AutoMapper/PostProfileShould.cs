using AutoMapper;
using CramCoding.Domain.Entities;
using CramCoding.WebApp.ViewModels.Admin.Post;
using CramCoding.WebApp.ViewModels.Home.Post;
using Xunit;

namespace CramCoding.UnitTests.AutoMapper
{
    public class PostProfileShould
    {
        [Fact]
        public void MapPostEntityToAdminPostViewModel()
        {
            // ARRANGE
            var postEntity = new Post
            {
                Header = "Header 123",
                Content = "Best post content for tests ever"
            };

            // ACT
            var mapper = CreateSut();
            var postViewModel = mapper.Map<AdminPostViewModel>(postEntity);

            // ASSERT
            Assert.Equal(postEntity.Header, postViewModel.Header);
            Assert.Equal(postEntity.Content, postViewModel.Content);
        }

        [Fact]
        public void MapPostEntityToHomePostViewModel()
        {
            // ARRANGE
            var postEntity = new Post
            {
                Header = "Header 123",
                Content = "Best post content for tests ever"
            };

            // ACT
            var mapper = CreateSut();
            var postViewModel = mapper.Map<HomePostViewModel>(postEntity);

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
