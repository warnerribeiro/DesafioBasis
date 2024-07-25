using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
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
            _authorRepository.Update(author);
            return Ok(author);
        }

        [HttpDelete("{authorId:int}")]
        public ActionResult Delete(int authorId)
        {
            _authorRepository.Remove(authorId);
            return Ok();
        }

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[Route("/error")]
        //public IActionResult HandleError() => Problem();

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[Route("/error-development")]
        //public IActionResult HandleErrorDev([FromServices] IHostEnvironment hostEnvironment) 
        //{
        //    if (!hostEnvironment.IsDevelopment())
        //    {
        //        return NotFound();
        //    }

        //    var exceptionHandlerFeature =
        //        HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        //    return Problem(
        //        detail: exceptionHandlerFeature.Error.StackTrace,
        //        title: exceptionHandlerFeature.Error.Message);
        //}
    }
}
