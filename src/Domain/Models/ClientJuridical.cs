namespace AspNetCoreMvc.Client.Domain.Models
{
    public class ClientJuridical : Client
    {
        public string CompanyName { get; private set; }
        public string FantasyName { get; private set; }
        public string Cnpj { get; private set; }

        protected ClientJuridical() { }

        public ClientJuridical(string companyName, string fantasyName, string cnpj, string email,
                                string zipCode, string street, string number, string city, string state, string complement = null, string reference = null)
                                : base(email, zipCode, street, number, city, state, complement, reference)
        {            
            CompanyName = companyName;
            FantasyName = fantasyName;
            Cnpj = cnpj;
        }
    }
}
