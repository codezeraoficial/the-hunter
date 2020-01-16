using System;
using System.Collections.Generic;

namespace Jobber.IO.Business.Models
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Image { get; set; }
        public string Document { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }        
        public KindPlan KindPlan { get; set; }
        public Occupation Occupation { get; set; }        
        public Address Address { get; set; }
        public bool Active { get; set; }

        public IEnumerable<Tech> Techs { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Occupation> Occupations { get; set; }
    }
}
