using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Api.Controllers.V1;

namespace WebApi.Test.ControllersTest.V1
{
    public class AuthorControllerTest : IDisposable
    {
        private readonly Mock<IAuthorRepository> mockAuthor;
        private readonly IAuthorRepository _authorRepository;
        private readonly Mock<ILogger<AuthorController>> mockController;
        private readonly ILogger<AuthorController> _logger;
        private bool _disposed = false;

        AuthorController _authorController;

        Author author = new Author
        {
            AuthorId = 1,
            Name = "Test"
        };

        IList<Author> authorList = new List<Author>
            {
                new Author
                {
                    AuthorId = 1,
                    Name = "Test"
                },
                new Author
                {
                    AuthorId = 2,
                    Name = "Test 2"
                }
            };

        public AuthorControllerTest()
        {
            mockAuthor = new(MockBehavior.Strict);
            mockAuthor.Setup(a => a.Get(1)).Returns(() => author);
            mockAuthor.Setup(a => a.GetAsync()).ReturnsAsync(() => authorList);
            mockAuthor.Setup(a => a.AddAsync(author)).ReturnsAsync(() => author);
            mockAuthor.Setup(a => a.UpdateAsync(author)).ReturnsAsync(() => author);
            mockAuthor.Setup(a => a.RemoveAsync(1)).Returns(() => Task.Run(() => { }));

            _authorRepository = mockAuthor.Object;
            _authorController = new AuthorController(null, _authorRepository);
        }

        [Fact]
        public async void GetAllReturnTest()
        {
            var authorActionResult = await _authorController.GetAsync();
            var result = (OkObjectResult)authorActionResult.Result;

            Assert.Equal(result.Value, authorList);
            Mock.Get(_authorRepository).Verify(a => a.GetAsync());
        }

        [Fact]
        public void GetIdReturnTest()
        {
            var authorResult = (OkObjectResult)_authorController.Get(1).Result;

            Assert.Equal(authorResult.Value, author);
            Mock.Get(_authorRepository).Verify(a => a.Get(1));
        }

        [Fact]
        public async void PostReturnTest()
        {
            var authorActionResult = await _authorController.PostAsync(author);
            var result = (OkObjectResult)authorActionResult.Result;

            Assert.Equal(result.Value, author);
            Mock.Get(_authorRepository).Verify(a => a.AddAsync(author));
        }

        [Fact]
        public async void PutReturnTest()
        {
            var authorActionResult = await _authorController.PutAsync(1, author);
            var result = (OkObjectResult)authorActionResult.Result;

            Assert.Equal(result.Value, author);
            Mock.Get(_authorRepository).Verify(a => a.UpdateAsync(author));
        }

        [Fact]
        public async void PutValidateDiffIdest()
        {
            var authorActionResult = await _authorController.PutAsync(2, author);
            var result = (BadRequestObjectResult)authorActionResult.Result;

            Assert.Equal(result.Value, "Id de atualização do objecto não confere.");
            Assert.Equal(result.StatusCode, 400);
            Assert.IsType<BadRequestObjectResult>(authorActionResult.Result);
        }

        [Fact]
        public async void DeleteReturnTest()
        {
            var authorActionResult = await _authorController.DeleteAsync(1);

            Mock.Get(_authorRepository).Verify(a => a.RemoveAsync(1));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {

            }

            mockAuthor.Reset();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~AuthorControllerTest()
        {
            mockAuthor.Reset();
            Dispose(false);
        }
    }
}