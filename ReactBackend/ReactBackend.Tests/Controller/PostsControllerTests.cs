using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ReactBackend.Controllers;
using ReactBackend.Data;
using ReactBackend.Interfaces;

namespace ReactBackend.Tests.Controller
{
    public class PostsControllerTests
    {
        private readonly IPostsRepository _postsRepository;

        public PostsControllerTests()
        {
            _postsRepository = A.Fake<IPostsRepository>();
        }

        [Fact]
        public void PostController_Get_ReturnTaskActionResultIEnumerablePost()
        {
            //Arrange
            var controller = new PostsController(_postsRepository);

            //Act
            var result = controller.GetPosts();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<IEnumerable<Post>>>));
        }

        [Fact]
        public void PostsController_Create_ReturnTaskActionResultPost()
        {
            //Arrange
            var post = A.Fake<Post>();
            var controller = new PostsController(_postsRepository);

            //Act
            var result = controller.Create(post);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<Post>>));
        }

        [Fact]
        public void PostController_Delete_ReturnTaskActionResultIEnumerablePost()
        {
            // Arrange
            var controller = new PostsController(_postsRepository);

            // Act
            var result = controller.Delete(10);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<IEnumerable<Post>>>));
        }
    }
}

