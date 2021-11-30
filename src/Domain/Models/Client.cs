using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvc.Client.Domain.Models
{
    public abstract class Client : Entity
    {
        public string Email { get; protected set; }

        public Address Address { get; protected set; }

        protected List<Phone> _phones = new List<Phone>();
        protected IReadOnlyCollection<Phone> Phones => _phones;

        protected Client() { }

        protected Client(string email, string zipCode, string street, string number, string neighborhood, string city, string state, string complement = null, string reference = null)
        {
            Email = email;
            SetAddress(zipCode, street, number, neighborhood, city, state, complement, reference);
        }

        protected void SetAddress(string zipCode, string street, string number, string neighborhood, string city, string state, string complement = null, string reference = null)
        {
            if (Address == null)
            {
                Address = new Address(zipCode, street, number, neighborhood, city, state, complement, reference);
            }
            else
            {
                Address.SetAddress(zipCode, street, number, neighborhood, city, state, complement, reference);
            }
        }

        protected void AddPhone(Phone phone)
        {
            var numberExist = _phones.Where(x => x.Number == phone.Number).FirstOrDefault();

            if (numberExist != null) throw new Exception("Número existente");
            if (_phones.Count == 3) throw new Exception("Quantidade máxima de telefones atingido.");

            _phones.Add(phone);
        }

        protected void RemovePhone(Phone phone)
        {
            var phoneExist = _phones.Where(x => x.Id == phone.Id).FirstOrDefault();

            if (phoneExist is null) throw new Exception("Phone inexistente");

            _phones.Remove(phoneExist);
        }
    }
}
