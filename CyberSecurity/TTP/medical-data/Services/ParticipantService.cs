using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using medical_data.Entities;
using medical_data.Interfaces;
using medical_data.Persistence;
using medical_data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace medical_data.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ParticipantService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task UpdateParticipant(int participantId, decimal weight, decimal height, bool hasEverDrank,
            bool hasEverSmoked)
        {
            var medicalParticipant = await _applicationDbContext.Set<Participant>().FindAsync(participantId);

            if (medicalParticipant == null)
                throw new Exception($"Cannot find medical participant with id {participantId}");

            medicalParticipant.Weight = weight;
            medicalParticipant.Height = height;
            medicalParticipant.HasEverDrank = hasEverDrank;
            medicalParticipant.HasEverSmoked = hasEverSmoked;

            _applicationDbContext.Update(medicalParticipant);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<ParticipantViewModel> GetFullParticipant(int participantId)
        {
            var medicalParticipant = await _applicationDbContext.Set<Participant>().FindAsync(participantId);

            if (medicalParticipant == null)
                throw new Exception($"Cannot find medical participant with id {participantId}");

            var ttpHttpClient = new HttpClient();
            ttpHttpClient.BaseAddress = new Uri("https://localhost:44349");

            var personalParticipantGuid =
                Guid.Parse((await ttpHttpClient.GetStringAsync($"participant-links/{participantId}"))
                    .Replace("\"", ""));

            var personalHttpClient = new HttpClient();
            personalHttpClient.BaseAddress = new Uri("https://localhost:44350");

            var personalParticipant =
                JsonConvert.DeserializeObject<PersonalDataParticipantViewModel>(
                    await personalHttpClient.GetStringAsync($"participants/{personalParticipantGuid}"));

            return new ParticipantViewModel()
            {
                LastName = personalParticipant.LastName,
                FirstName = personalParticipant.FirstName,
                City = personalParticipant.City,
                BirthDate = personalParticipant.BirthDate,
                Height = medicalParticipant.Height,
                Weight = medicalParticipant.Weight,
                StudyCode = medicalParticipant.StudyCode,
                HasEverDrank = medicalParticipant.HasEverDrank,
                HasEverSmoked = medicalParticipant.HasEverSmoked,
            };
        }

        public async Task<List<ParticipantViewModel>> GetFullParticipants()
        {
            var medicalParticipantIds = await _applicationDbContext.Set<Participant>().Select(x => x.Id).ToListAsync();

            var medicalParticipants = new List<ParticipantViewModel>();

            foreach (var medicalParticipantId in medicalParticipantIds)
                medicalParticipants.Add(await GetFullParticipant(medicalParticipantId));

            return medicalParticipants;
        }
    }
}