using System;

namespace Domain.Models
{
    public class Occupation : Entity
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string CompanyName { get; private set; }
        public string Description { get; private set; }


        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
    }
}