using System.Collections.Generic;

namespace GoHunter.Business.Models
{
    public class Company:Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }        
        public string Email { get; set; }
        public bool Active { get; set; }
        
        public Address Address { get; set; }       
        
        public KindPlan KindPlan { get; set; }
        public KindOfCompany KindOfCompany { get; set; }

        public IEnumerable<JobOffer> JobOffers { get; set; }

    }
}
