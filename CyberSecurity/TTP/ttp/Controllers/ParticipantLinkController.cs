using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ttp.Entities;
using ttp.Persistence;

namespace ttp.Controllers
{
    [ApiController]
    [Route("participant-links")]
    public class ParticipantLinkController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ParticipantLinkController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Set<ParticipantLink>().ToListAsync());
        }

        [HttpGet("{participantId}")]
        public async Task<IActionResult> Get(int participantId)
        {
            return Ok((await _dbContext.Set<ParticipantLink>().FirstOrDefaultAsync(x => x.ParticipantMedicalId == participantId)).ParticipantPersonalId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipantLink model)
        {
            var personalDataParticipant = new ParticipantLink();
            personalDataParticipant.ParticipantMedicalId = model.ParticipantMedicalId;
            personalDataParticipant.ParticipantPersonalId = model.ParticipantPersonalId;

            await _dbContext.AddAsync(personalDataParticipant);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}