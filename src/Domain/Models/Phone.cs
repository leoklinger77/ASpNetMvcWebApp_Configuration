using AspNetCoreMvc.Client.Domain.Models.Enum;
using System;

namespace AspNetCoreMvc.Client.Domain.Models
{
    public class Phone : Entity
    {
        public Guid ClientId { get; private set; }
        public string Ddd { get; private set; }
        public string Number { get; private set; }
        public PhoneType PhoneType { get; private set; }

        public Client Client { get; private set; }
        public Phone() { }

        public Phone(string ddd, string number, PhoneType phoneType)
        {
            Ddd = ddd;
            Number = number;
            PhoneType = phoneType;
        }
    }
}
