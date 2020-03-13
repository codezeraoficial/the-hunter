using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public abstract class User : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public Guid? AddressId { get; set; }
        public KindPlan KindPlan { get; set; }

        public Address Address { get; set; }
    }
}
