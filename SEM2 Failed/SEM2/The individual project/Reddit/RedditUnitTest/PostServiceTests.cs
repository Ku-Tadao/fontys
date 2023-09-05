using Xunit;
using Moq;
using RedditBusinessLayer.Services;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Entities;
using System.Collections.Generic;

namespace RedditUnitTest
{
    public class PostServiceTests
    {
        [Fact]
        public void GetPosts_ReturnsListOfPosts()
        {
            // Arrange
            var mockPostRepository = new Mock<IPostRepository>();
            // Set up the GetPosts method on the mock IPostRepository object to return a predefined list of posts
            mockPostRepository.Setup(repo => repo.GetPosts()).Returns(new List<Post>
            {
                new Post(1, "Title1", "Content1", System.DateTime.Now, 1, 1),
                new Post(2, "Title2", "Content2", System.DateTime.Now, 2, 2)
            });

            var postService = new PostService(mockPostRepository.Object);

            // Act
            var result = postService.GetPosts();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Title1", result[0].Title);
            Assert.Equal("Content2", result[1].Content);
        }

        [Fact]
        public void GetPostById_ReturnsPost()
        {
            // Arrange
            var mockPostRepository = new Mock<IPostRepository>();
            mockPostRepository.Setup(repo => repo.GetPostById(1)).Returns(new Post(1, "Title1", "Content1", System.DateTime.Now, 1, 1));

            var postService = new PostService(mockPostRepository.Object);

            // Act
            var result = postService.GetPostById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Title1", result.Title);
        }

        [Fact]
        public void PostService_Constructor_ThrowsArgumentNullException_WhenPostRepositoryIsNull()
        {
            // Arrange
            IPostRepository postRepository = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new PostService(postRepository));
        }

        [Fact]
        public void GetPostById_ThrowsArgumentOutOfRangeException_WhenPostIdIsLessThanOrEqualToZero()
        {
            // Arrange
            var mockPostRepository = new Mock<IPostRepository>();
            var postService = new PostService(mockPostRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => postService.GetPostById(0));
        }


    }
}