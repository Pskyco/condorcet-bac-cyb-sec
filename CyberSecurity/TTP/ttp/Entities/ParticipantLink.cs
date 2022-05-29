using System;

namespace ttp.Entities
{
    public class ParticipantLink
    {
        public int Id { get; set; }
        public Guid ParticipantPersonalId { get; set; }
        public int ParticipantMedicalId { get; set; }
    }
}