using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository;
        private readonly ILogger<ActorController> _logger;

        public ActorController(ILogger<ActorController> logger, IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return Ok(await _actorRepository.GetAsync());
        }

        [HttpGet("{actorId:int}")]
        public ActionResult<Actor> Get(int actorId)
        {
            var actor = _actorRepository.Get(actorId);

            if (actor == null)
            {
                return NoContent();
            }

            return Ok(actor);
        }

        [HttpPost]
        public ActionResult<Actor> Post(Actor actor)
        {
            return _actorRepository.Add(actor);
        }

        [HttpPut("{actorId:int}")]
        public ActionResult<Actor> Put(int actorId, Actor actor)
        {
            _actorRepository.Update(actor);
            return Ok(actor);
        }

        [HttpDelete("{actorId:int}")]
        public ActionResult Delete(int actorId)
        {
            _actorRepository.Remove(actorId);
            return Ok();
        }
    }
}
