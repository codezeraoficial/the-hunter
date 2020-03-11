using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class JobOffer:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContractCode { get; set; }
        public int Long { get; set; }

        public KindOccupation KindOccupation { get; set; }
        public string Occupation { get; set; }
      
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }

        public IEnumerable<Tech> Techs { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

    }
}
