using AspNetCoreMvc.Client.Domain.Tools;
using FluentValidation;
using System;

namespace AspNetCoreMvc.Client.Domain.Models.Validations
{
    public class ClientJuridicalValidation : AbstractValidator<ClientJuridical>
    {
        public ClientJuridicalValidation()
        {
            RuleFor(x => x.Id)
                .Equal(Guid.Empty)
                .WithMessage("O Id é invalido.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O campo Cep é obrigatório.")
                .EmailAddress()
                .WithMessage("O campo e-mail é invalido")
                .Length(5, 100)
                .WithMessage("O campo e-mail deve conter entre 5 e 100 caracteres.");

            RuleFor(x => x.FantasyName)
                .NotEmpty()
                .WithMessage("O campo Nome Fantasia é obrigatorio")
                .Length(1, 100)
                .WithMessage("O campo Nome Fantasia precisa ter entre 1 e 100 caracteres");

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("O campo Razão Social é obrigatorio")
                .Length(1, 256)
                .WithMessage("O campo Razão Social precisa ter entre 1 e 256 caracteres");

            RuleFor(x => x.Cnpj.IsCnpj())
                .NotEqual(false)
                .WithMessage("O Cnpj informado não é valido");
        }
    }
}
