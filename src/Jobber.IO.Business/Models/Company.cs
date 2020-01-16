using System.Collections.Generic;

namespace Jobber.IO.Business.Models
{
    public class Company:Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public List<string> Image { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public KindOfCompany KindOfCompany { get; set; }
        public Address Address { get; set; }

        public Occupation OccupationSeek { get; set; }
        public KindOccupation KindOfEmployee { get; set; }
        public KindPlan KindPlan { get; set; }

        public IEnumerable<Tech> Techs { get; set; }
        public IEnumerable<JobOffer> Jobbers { get; set; }
    }
}
