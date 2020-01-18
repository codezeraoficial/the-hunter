using System;

namespace Jobber.IO.Business.Models
{
    public class Skill: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public string Link { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; }

    }
}
