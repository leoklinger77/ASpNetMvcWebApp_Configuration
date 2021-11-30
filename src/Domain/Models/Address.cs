using System;

namespace AspNetCoreMvc.Client.Domain.Models
{
    public class Address : Entity
    {
        public Guid ClientId { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Reference { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Client Client { get; private set; }

        protected Address() { }

        internal Address(string zipCode, string street, string number, string neighborhood, string city, string state, string complement = null, string reference = null)
        {
            SetAddress(zipCode, street, number, neighborhood, city, state, complement, reference);
        }
        internal void SetAddress(string zipCode, string street, string number, string neighborhood, string city, string state, string complement = null, string reference = null)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            Reference = reference;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
            Reference = reference;
        }
    }
}
