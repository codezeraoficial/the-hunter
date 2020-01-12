using System;

namespace Jobber.IO.Business.Models
{
    public class Occupation: Entity
    {
        public string OccupationName { get; set; }
        public int Experience { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
