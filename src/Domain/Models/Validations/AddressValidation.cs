using FluentValidation;

namespace AspNetCoreMvc.Client.Domain.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .WithMessage("O campo Cep é obrigatório.")
                .Length(8, 8)
                .WithMessage("O campo Cep deve conter 8 caracteres.");

            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("O campo Logradouro é obrigatorio")
                .Length(5, 100)
                .WithMessage("O campo Logradouro precisa ter entre 2 e 100 caracteres");

            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("O campo número é obrigatorio")
                .Length(1, 10)
                .WithMessage("O campo número precisa ter entre 1 e 10 caracteres");


            RuleFor(x => x.Neighborhood)
                .NotEmpty()
                .WithMessage("O campo cidade é obrigatorio")
                .Length(2, 100)
                .WithMessage("O campo cidade precisa ter entre 2 e 100 caracteres");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("O campo cidade é obrigatorio")
                .Length(2, 100)
                .WithMessage("O campo cidade precisa ter entre 2 e 100 caracteres");

            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage("O campo Estado é obrigatorio")
                .Length(2, 2)
                .WithMessage("O campo Estado precisa ter 2 caracteres");

            RuleFor(x => x.Complement)
                .Length(1, 100)
                .WithMessage("O campo número precisa ter entre 1 e 100 caracteres");

            RuleFor(x => x.Reference)
                .Length(1, 100)
                .WithMessage("O campo Refenrecia precisa ter entre 1 e 100 caracteres");
        }
    }
}
