using System;

namespace medical_data.ViewModels
{
    public class ParticipantLinkViewModel
    {
        public Guid ParticipantPersonalId { get; set; }
        public int ParticipantMedicalId { get; set; }
    }
}