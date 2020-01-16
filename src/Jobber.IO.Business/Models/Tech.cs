using System;

namespace Jobber.IO.Business.Models
{
    public class Tech : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
