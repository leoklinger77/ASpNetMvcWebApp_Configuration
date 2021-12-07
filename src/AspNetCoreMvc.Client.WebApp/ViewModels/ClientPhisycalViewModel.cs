using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc.Client.WebApp.ViewModels
{
    public class ClientPhisycalViewModel : ClientViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        

        [Display(Name = "Fixo")]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "O campo {0} está inválido.")]
        public string CelHome { get; set; }

        [Display(Name = "Comercial")]
        [StringLength(16, MinimumLength = 11, ErrorMessage = "O campo {0} está inválido.")]
        public string CelCommercial { get; set; }

        [Display(Name = "Celular")]
        [StringLength(16, MinimumLength = 11, ErrorMessage = "O campo {0} está inválido.")]
        public string CelSmartPhone { get; set; }
    }
}
