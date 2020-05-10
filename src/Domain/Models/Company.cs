using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Company : User
    {
        public string Name { get; private set; }
        public KindOfCompany KindOfCompany { get; private set; }

        public IEnumerable<JobOffer> JobOffers { get; private set; }
    }
}
