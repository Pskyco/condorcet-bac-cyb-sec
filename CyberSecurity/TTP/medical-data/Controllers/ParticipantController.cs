using System;
using System.Net.Http;
using System.Threading.Tasks;
using medical_data.Entities;
using medical_data.Interfaces;
using medical_data.Persistence;
using medical_data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medical_data.Controllers
{
    [ApiController]
    [Route("participants")]
    public class ParticipantController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IParticipantService _participantService;

        public ParticipantController(ApplicationDbContext dbContext, IParticipantService participantService)
        {
            _dbContext = dbContext;
            _participantService = participantService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _participantService.GetFullParticipants());
        }
        
        [HttpGet("{participantId}")]
        public async Task<IActionResult> Get(int participantId)
        {
            return Ok(await _participantService.GetFullParticipant(participantId));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipantViewModel model)
        {
            var count = await _dbContext.Set<Participant>().CountAsync();
            
            var medicalParticipant = new Participant();
            medicalParticipant.Height = model.Height;
            medicalParticipant.Height = model.Weight;
            medicalParticipant.HasEverDrank = model.HasEverDrank;
            medicalParticipant.HasEverSmoked = model.HasEverSmoked;
            medicalParticipant.StudyCode = $"BE-{(count + 1):00000}";

            await _dbContext.AddAsync(medicalParticipant);
            await _dbContext.SaveChangesAsync();

            var personalDataParticipant = new PersonalDataParticipantViewModel();
            personalDataParticipant.FirstName = model.FirstName;
            personalDataParticipant.LastName = model.LastName;
            personalDataParticipant.BirthDate = model.BirthDate;
            personalDataParticipant.City = model.City;

            var personalHttpClient = new HttpClient();
            personalHttpClient.BaseAddress = new Uri("https://localhost:44350");
            var result = await personalHttpClient.PostAsJsonAsync("participants", personalDataParticipant);

            if (result.IsSuccessStatusCode)
            {
                var personalDataId = await result.Content.ReadAsAsync<Guid>();
                var subHttpClient = new HttpClient();
                subHttpClient.BaseAddress = new Uri("https://localhost:44349");
                var result2 = await subHttpClient.PostAsJsonAsync("participant-links", new ParticipantLinkViewModel()
                {
                    ParticipantMedicalId = medicalParticipant.Id,
                    ParticipantPersonalId = personalDataId
                });
                if (!result2.IsSuccessStatusCode)
                    throw new Exception("Not added on TTP-side");
            }
            
            return Ok();
        }
    }
}