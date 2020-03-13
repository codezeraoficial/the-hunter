using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Employee : User
    {
        public DateTime BirthDate { get; set; }        
        public IEnumerable<Tech> Techs { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Occupation> Occupations { get; set; }
    }
}
