using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class JobOffer:Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ContractCode { get; private set; }
        public int ContractTime { get; private set; }

        public KindOccupation KindOccupation { get; private set; }
        public string Occupation { get; private set; }

        public Guid CompanyId { get; private set; }
        public string CompanyName { get; private set; }

        public IEnumerable<Tech> Techs { get; private set; }
        public IEnumerable<Skill> Skills { get; private set; }

    }
}
