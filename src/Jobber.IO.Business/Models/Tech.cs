using System;

namespace Jobber.IO.Business.Models
{
    public class Tech : Entity
    {
        public string TechName { get; set; }
        public string TechDescription { get; set; }
        public int TechLong { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
