using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return Ok(await _bookRepository.GetAsync());
        }

        [HttpGet("{bookId:int}")]
        public ActionResult<Book> Get(int bookId)
        {
            var book = _bookRepository.Get(bookId);

            if (book == null)
            {
                return NoContent();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Post(Book book)
        {
            return _bookRepository.Add(book);
        }

        [HttpPut("{bookId:int}")]
        public ActionResult<Actor> Put(int bookId, Book book)
        {
            _bookRepository.Update(book);
            return Ok(book);
        }

        [HttpDelete("{bookId:int}")]
        public ActionResult Delete(int bookId)
        {
            _bookRepository.Remove(bookId);
            return Ok();
        }
    }
}
