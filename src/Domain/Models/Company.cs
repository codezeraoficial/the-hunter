using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Company : User
    {
        public KindOfCompany KindOfCompany { get; set; }
        public IEnumerable<JobOffer> JobOffers { get; set; }
    }
}
