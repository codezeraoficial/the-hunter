using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }

        public Address Address { get; set; }
        public Guid? AddressId { get; set; }

        public KindPlan KindPlan { get; set; }
        public KindOfCompany KindOfCompany { get; set; }

        public IEnumerable<JobOffer> JobOffers { get; set; }

    }
}
