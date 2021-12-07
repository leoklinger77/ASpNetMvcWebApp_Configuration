using AspNetCoreMvc.Client.Domain.Tools;
using FluentValidation;
using System;

namespace AspNetCoreMvc.Client.Domain.Models.Validations
{
    public class ClientPhisycalValidation : AbstractValidator<ClientPhysical>
    {
        public ClientPhisycalValidation()
        {
            RuleFor(x => x.Id)
                .Equal(Guid.Empty)
                .WithMessage("O Id é invalido.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O campo e-mail é obrigatório.")
                .EmailAddress()
                .WithMessage("O campo e-mail é invalido")
                .Length(5, 100)
                .WithMessage("O campo e-mail deve conter entre 5 e 100 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O campo Nome Fantasia é obrigatorio")
                .Length(1, 100)
                .WithMessage("O campo Nome Fantasia precisa ter entre 1 e 100 caracteres");

            RuleFor(x => ValidateBirthDate(x.BirthDate))
                .NotEqual(false)
                .WithMessage("A data de nascimento não é valida.");


            RuleFor(x => x.Cpf.IsCpf())
                .NotEqual(false)
                .WithMessage("O cpf informado não é valido");
        }

        private bool ValidateBirthDate(DateTime date)
        {
            return DateTime.Now.AddYears(-18).Date <= date.Date;
        }
    }
}
