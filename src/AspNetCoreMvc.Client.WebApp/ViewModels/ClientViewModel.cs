using System;
using System.Collections.Generic;

namespace AspNetCoreMvc.Client.WebApp.ViewModels
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public AddressViewModel Address { get; set; }
        public ICollection<PhoneViewModel> Phones { get; set; } = new List<PhoneViewModel>();
    }
}
