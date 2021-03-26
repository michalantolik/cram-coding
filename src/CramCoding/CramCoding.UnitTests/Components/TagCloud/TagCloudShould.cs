using CramCoding.UnitTests.Models.Repositories.Mocks;
using CramCoding.WebApp.Components.TagCloud;
using CramCoding.WebApp.ViewModels.ViewComponents.TagCloud;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Xunit;

namespace CramCoding.UnitTests.Components
{
    public class TagCloudShould
    {
        [Fact]
        public void InitializeViewWithCorrectViewModel()
        {
            // ARRANGE
            var tagRepositoryMock = new RepositoryMocks().TagRepositoryMock;
            var sut = new TagCloud(tagRepositoryMock);

            // ... based on data in "tagRepositoryMock"
            var expectedViewModel = new TagCloudViewModel
            {
                Header = "Tagi",
                Tags = new[]
                {
                    "Tag 1",
                    "Tag 2",
                    "Tag 3"
                }
            };

            // ACT
            var view = sut.Invoke() as ViewViewComponentResult;

            // ASSERT
            Assert.NotNull(view);

            var viewModel = view.ViewData.Model as TagCloudViewModel;
            Assert.NotNull(viewModel);

            Assert.Equal(expectedViewModel.Header, viewModel.Header);
            Assert.Equal(expectedViewModel.Tags.Length, viewModel.Tags.Length);
            for (int i = 0; i < viewModel.Tags.Length; i++)
            {
                Assert.Equal(expectedViewModel.Tags[i], viewModel.Tags[i]);
            }
        }
    }
}
