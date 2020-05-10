using System;

namespace Domain.Models
{
    public class Address : Entity
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Cep { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }

        public Employee Employee { get; private set; }
        public Company Company { get; private set; }
    }
}
