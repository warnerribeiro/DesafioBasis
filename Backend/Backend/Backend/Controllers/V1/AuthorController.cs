﻿using Core.Repository;
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
        public async Task<ActionResult<IEnumerable<Author>>> GetAsync()
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
        public async Task<ActionResult<Author>> PostAsync(Author author)
        {
            return Ok(await _authorRepository.AddAsync(author));
        }

        [HttpPut("{authorId:int}")]
        public async Task<ActionResult<Author>> PutAsync(int authorId, Author author)
        {
            if (author == null || authorId != author.AuthorId)
            {
                return BadRequest("Id de atualização do objecto não confere.");
            }

            return Ok(await _authorRepository.UpdateAsync(author));
        }

        [HttpDelete("{authorId:int}")]
        public async Task<ActionResult> DeleteAsync(int authorId)
        {
            await _authorRepository.RemoveAsync(authorId);
            return Ok();
        }
    }
}
