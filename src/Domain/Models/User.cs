using Domain.Enums;
using System;

namespace Domain.Models
{
    public abstract class User : Entity
    {
        public string Document { get; private set; }
        public string Image { get; private set; }
        public bool Active { get; private set; }
        public KindPlan KindPlan { get; private set; }
        public Guid AddressId { get; private set; }

        public Address Address { get; private set; }

        public void LinkAddress(Guid addressId)
        {
            AddressId = addressId;
        }
    }
}
