using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Employee : User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }

        public IEnumerable<Tech> Techs { get; private set; }
        public IEnumerable<Skill> Skills { get; private set; }
        public IEnumerable<Occupation> Occupations { get; private set; }
    }
}
