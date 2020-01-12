using System;

namespace Jobber.IO.Business.Models
{
    public class Skill: Entity
    {
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public int SkillLong { get; set; }
        public string SkillLink { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
