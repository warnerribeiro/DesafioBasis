using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Api.Controllers.V1;

namespace WebApi.Test.ControllersTest.V1
{
    public class BookControllerTest
    {
        private readonly Mock<IBookRepository> mockRepository;
        private readonly IBookRepository _repository;
        private readonly Mock<ILogger<BookController>> mockController;
        private readonly BookController _controller;

        private readonly ILogger<BookController> _logger;
        private bool _disposed = false;

        Book obj = new Book
        {
            BookId = 1,
            Edition = 1,
            Publisher = "Editora",
            Title = "Titulo",
            YearOfPublication = "2015"
        };

        IList<Book> list = new List<Book>
        {
            new Book
            {
                BookId = 1,
                Edition = 1,
                Publisher = "Editora",
                Title = "Titulo",
                YearOfPublication = "2015"
            },
            new Book
            {
                BookId = 2,
                Edition = 2,
                Publisher = "Editora 2",
                Title = "Titulo 2",
                YearOfPublication = "2016"
            }
        };

        public BookControllerTest()
        {
            mockRepository = new(MockBehavior.Strict);
            mockRepository.Setup(a => a.GetAsync(1)).ReturnsAsync(() => obj);
            mockRepository.Setup(a => a.GetAsync()).ReturnsAsync(() => list);
            mockRepository.Setup(a => a.AddAsync(obj)).ReturnsAsync(() => obj);
            mockRepository.Setup(a => a.UpdateAsync(obj)).ReturnsAsync(() => obj);
            mockRepository.Setup(a => a.RemoveAsync(1)).Returns(() => Task.Run(() => { }));

            _repository = mockRepository.Object;
            _controller = new BookController(null, _repository);
        }

        [Fact]
        public async void GetAllReturnTest()
        {
            var actionResult = await _controller.GetAsync();
            var result = (OkObjectResult)actionResult.Result;

            Assert.Equal(result.Value, list);
            Mock.Get(_repository).Verify(a => a.GetAsync());
        }

        [Fact]
        public async void GetIdReturnTest()
        {
            var actionResult = await _controller.GetAsync(1);
            var result = (OkObjectResult)actionResult.Result;

            Assert.Equal(result.Value, obj);
            Mock.Get(_repository).Verify(a => a.GetAsync(1));
        }

        [Fact]
        public async void PostReturnTest()
        {
            var authorActionResult = await _controller.PostAsync(obj);
            var result = (OkObjectResult)authorActionResult.Result;

            Assert.Equal(result.Value, obj);
            Mock.Get(_repository).Verify(a => a.AddAsync(obj));
        }

        [Fact]
        public async void PutReturnTest()
        {
            var authorActionResult = await _controller.PutAsync(1, obj);
            var result = (OkObjectResult)authorActionResult.Result;

            Assert.Equal(result.Value, obj);
            Mock.Get(_repository).Verify(a => a.UpdateAsync(obj));
        }

        [Fact]
        public async void PutValidateDiffIdest()
        {
            var authorActionResult = await _controller.PutAsync(2, obj);
            var result = (BadRequestObjectResult)authorActionResult.Result;

            Assert.Equal(result.Value, "Id de atualização do objecto não confere.");
            Assert.Equal(result.StatusCode, 400);
            Assert.IsType<BadRequestObjectResult>(authorActionResult.Result);
        }

        [Fact]
        public async void DeleteReturnTest()
        {
            var authorActionResult = await _controller.DeleteAsync(1);

            Mock.Get(_repository).Verify(a => a.RemoveAsync(1));
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

            mockRepository.Reset();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~BookControllerTest()
        {
            mockRepository.Reset();
            Dispose(false);
        }
    }
}
