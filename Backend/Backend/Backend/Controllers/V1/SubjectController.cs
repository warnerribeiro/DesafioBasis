using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ILogger<SubjectController> logger, ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> Get()
        {
            return Ok(await _subjectRepository.GetAsync());
        }

        [HttpGet("{subjectId:int}")]
        public ActionResult<Subject> Get(int subjectId)
        {
            var subject = _subjectRepository.Get(subjectId);

            if (subject == null)
            {
                return NoContent();
            }

            return Ok(subject);
        }

        [HttpPost]
        public ActionResult<Subject> Post(Subject subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }

            return _subjectRepository.Add(subject);
        }

        [HttpPut("{subjectId:int}")]
        public ActionResult<Subject> Put(int subjectId, Subject subject)
        {
            if (subject == null || subjectId != subject.SubjectId) 
            {
                return BadRequest();
            }
            
            return Ok(_subjectRepository.Update(subject));
        }

        [HttpDelete("{subjectId:int}")]
        public ActionResult Delete(int subjectId)
        {
            _subjectRepository.Remove(subjectId);
            return Ok();
        }
    }
}
