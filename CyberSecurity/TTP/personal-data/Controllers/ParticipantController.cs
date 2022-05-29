using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personal_data.Entities;
using personal_data.Persistence;

namespace personal_data.Controllers
{
    [Route("participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ParticipantController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Set<Participant>().ToListAsync());
        }

        [HttpGet("{participantId}")]
        public async Task<IActionResult> Get(Guid participantId)
        {
            return Ok(await _dbContext.Set<Participant>().FindAsync(participantId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Participant model)
        {
            var personalDataParticipant = new Participant();
            personalDataParticipant.FirstName = model.FirstName;
            personalDataParticipant.LastName = model.LastName;
            personalDataParticipant.City = model.City;
            personalDataParticipant.BirthDate = model.BirthDate;

            await _dbContext.AddAsync(personalDataParticipant);
            await _dbContext.SaveChangesAsync();

            return Ok(personalDataParticipant.Id);
        }
    }
}