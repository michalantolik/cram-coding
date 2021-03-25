using CramCoding.WebApp.Controllers;
using CramCoding.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CramCoding.UnitTests.Controllers
{
    public class AdminControllerShould
    {
        [Fact]
        public void ReturnCurrentFormViewWhenAddingInvalidPost()
        {
            // ARRANGE
            var post = new EditPostViewModel();
            var sut = new AdminController();
            sut.ModelState.AddModelError("firstName", "Invalid First Name");

            // ACT
            var result = sut.AddPost(post);

            // ASSERT
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void RedirectToPostsWhenAddingValidPost()
        {
            // ARRANGE
            var post = new EditPostViewModel();
            var sut = new AdminController();

            // ACT
            var result = sut.AddPost(post);

            // ASSERT
            var redirectResult = result as RedirectToActionResult;
            Assert.NotNull(redirectResult);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal(nameof(AdminController.Posts), redirectResult.ActionName);
        }
    }
}
