using System;

namespace AspNetCoreMvc.Client.WebApp.ViewModels
{
    public class PhoneViewModel
    {
        public Guid ClientId { get; set; }
        public string Ddd { get; set; }
        public string Number { get; set; }
        public int PhoneType { get; set; }
    }
}
