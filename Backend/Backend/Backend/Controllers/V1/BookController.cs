using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<Book>> Get(int bookId)
        {
            var book = await _bookRepository.Get(bookId);

            if (book == null)
            {
                return NoContent();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            return await _bookRepository.Add(book);
        }

        [HttpPut("{bookId:int}")]
        public async Task<ActionResult<Book>> Put(int bookId, Book book)
        {
            if (book == null || bookId != book.BookId)
            {
                return BadRequest("Id de atualização do objecto não confere.");
            }

            return Ok(await _bookRepository.Update(book));
        }

        [HttpDelete("{bookId:int}")]
        public async Task<ActionResult> Delete(int bookId)
        {
            await _bookRepository.Remove(bookId);
            return Ok();
        }
    }
}
