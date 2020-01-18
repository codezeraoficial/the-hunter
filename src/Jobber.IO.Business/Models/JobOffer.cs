using System;
using System.Collections.Generic;

namespace Jobber.IO.Business.Models
{
    public class JobOffer:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Long { get; set; }

        public KindOccupation KindOccupation { get; set; }

        public Occupation Occupation { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        
        public IEnumerable<Tech> Techs { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

    }
}
