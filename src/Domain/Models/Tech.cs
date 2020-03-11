using System;

namespace Domain.Models
{
    public class Tech : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; }

    }
}
