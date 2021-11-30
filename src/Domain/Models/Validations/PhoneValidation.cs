using FluentValidation;

namespace AspNetCoreMvc.Client.Domain.Models.Validations
{
    public class PhoneValidation : AbstractValidator<Phone>
    {
        public PhoneValidation()
        {
            RuleFor(x => x.Ddd)
                .NotEmpty()
                .WithMessage("O campo Ddd é obrigatorio.")
                .Length(2, 2)
                .WithMessage("O campo Ddd deve ter 2 caracteres.");

            When(x => x.PhoneType == Enum.PhoneType.Celular, () =>
            {
                RuleFor(x => x.Number)
                    .NotEmpty()
                    .WithMessage("O campo Telefone Celular é obrigatorio.")
                    .Length(9, 9)
                    .WithMessage("O campo Telefone Celular deve conter 9 caracteres.");
            });

            When(x => x.PhoneType == Enum.PhoneType.Comercial, () =>
            {
                RuleFor(x => x.Number)
                    .NotEmpty()
                    .WithMessage("O campo Telefone Comercial é obrigatorio.")
                    .Length(8, 9)
                    .WithMessage("O campo Telefone Comercial deve ter enter 8 a 9 caracteres");
            });

            When(x => x.PhoneType == Enum.PhoneType.Fixo, () =>
            {
                RuleFor(x => x.Number)
                    .NotEmpty()
                    .WithMessage("O campo Telefone Fixo é obrigatorio.")
                    .Length(8, 8)
                    .WithMessage("O campo Telefone Fixo deve ter 8 caracteres.");
            });
        }
    }
}
