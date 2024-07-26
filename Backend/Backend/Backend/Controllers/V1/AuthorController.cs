using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger, IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            return Ok(await _authorRepository.GetAsync());
        }

        [HttpGet("{authorId:int}")]
        public ActionResult<Author> Get(int authorId)
        {
            var author = _authorRepository.Get(authorId);

            if (author == null)
            {
                return NoContent();
            }

            return Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> Post(Author author)
        {
            return _authorRepository.Add(author);
        }

        [HttpPut("{authorId:int}")]
        public ActionResult<Author> Put(int authorId, Author author)
        {
            if (author == null || authorId != author.AuthorId)
            {
                return BadRequest("Id de atualização do objecto não confere.");
            }

            return Ok(_authorRepository.Update(author));
        }

        [HttpDelete("{authorId:int}")]
        public ActionResult Delete(int authorId)
        {
            _authorRepository.Remove(authorId);
            return Ok();
        }
    }
}
