using System.Collections.Generic;
using System.Threading.Tasks;
using medical_data.ViewModels;

namespace medical_data.Interfaces
{
    public interface IParticipantService
    {
        Task<ParticipantViewModel> GetFullParticipant(int participantId);
        Task<List<ParticipantViewModel>> GetFullParticipants();

        Task UpdateParticipant(int participantId, decimal weight, decimal height, bool hasEverDrank,
            bool hasEverSmoked);
    }
}