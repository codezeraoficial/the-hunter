using System;

namespace Domain.Models
{
    public class Skill : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public Guid JobOfferId { get; private set; }
        public JobOffer JobOffer { get; private set; }

    }
}
