using System;

namespace AspNetCoreMvc.Client.Domain.Models
{
    public class ClientPhysical : Client
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        protected ClientPhysical() { }

        public ClientPhysical(string name, string cpf, DateTime birthDate, string email, 
                            string zipCode, string street, string number, string city, string state, string complement = null, string reference = null) 
                            : base(email, zipCode, street, number, city, state, complement, reference)
        {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
        }
    }
}
