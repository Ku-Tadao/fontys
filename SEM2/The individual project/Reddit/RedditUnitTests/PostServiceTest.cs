using RedditBusinessLayer.Services;
using RedditDataLayer.Repos;
using RedditBusinessLayer.Entities;

namespace RedditUnitTests
{
    public class PostServiceTests
    {
        [Fact]
        public void CreatePost_WithValidData_CreatesPost()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;

            // Act
            var post = postService.CreatePost(title, content, dateCreated, userId, subredditId);

            // Assert
            Assert.NotNull(post);
            Assert.Equal(title, post.Title);
            Assert.Equal(content, post.Content);
            Assert.Equal(dateCreated, post.DateCreated);
            Assert.Equal(userId, post.UserId);
            Assert.Equal(subredditId, post.SubredditId);
        }

        [Fact]
        public void CreatePost_WithEmptyTitle_ThrowsArgumentException()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => postService.CreatePost(title, content, dateCreated, userId, subredditId));
        }

        [Fact]
        public void CreatePost_WithWhitespaceTitle_ThrowsArgumentException()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = " ";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => postService.CreatePost(title, content, dateCreated, userId, subredditId));
        }
        [Fact]
        public void CreatePost_WithEmptyContent_ThrowsArgumentException()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = "";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => postService.CreatePost(title, content, dateCreated, userId, subredditId));
        }

        [Fact]
        public void CreatePost_WithWhitespaceContent_ThrowsArgumentException()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = " ";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => postService.CreatePost(title, content, dateCreated, userId, subredditId));
        }

        [Fact]
        public void UpdatePostTitle_WithValidData_UpdatesTitle()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;
            var post = postService.CreatePost(title, content, dateCreated, userId, subredditId);
            var newTitle = "New Test Title";

            // Act
            postService.UpdatePostTitle(post.Id, newTitle);

            // Assert
            Assert.Equal(newTitle, post.Title);
        }
        [Fact]
        public void UpdatePostTitle_WithEmptyTitle_ThrowsArgumentException()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;
            var post = postService.CreatePost(title, content, dateCreated, userId, subredditId);
            var newTitle = "";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => postService.UpdatePostTitle(post.Id, newTitle));
        }

        [Fact]
        public void UpdatePostContent_WithValidData_UpdatesContent()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;
            var post = postService.CreatePost(title, content, dateCreated, userId, subredditId);
            var newContent = "New Test Content";

            // Act
            postService.UpdatePostContent(post.Id, newContent);

            // Assert
            Assert.Equal(newContent, post.Content);
        }

        [Fact]
        public void UpdatePostContent_WithEmptyContent_ThrowsArgumentException()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;
            var post = postService.CreatePost(title, content, dateCreated, userId, subredditId);
            var newContent = "";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => postService.UpdatePostContent(post.Id, newContent));
        }
        [Fact]
        public void UpdatePostContent_WithWhitespaceContent_ThrowsArgumentException()
        {
            // Arrange
            var postRepository = new PostRepository();
            var postService = new PostService(postRepository);
            var title = "Test Title";
            var content = "Test Content";
            var dateCreated = DateTime.Now;
            var userId = 1;
            var subredditId = 1;
            var post = postService.CreatePost(title, content, dateCreated, userId, subredditId);
            var newContent = " ";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => postService.UpdatePostContent(post.Id, newContent));
        }
    }
}