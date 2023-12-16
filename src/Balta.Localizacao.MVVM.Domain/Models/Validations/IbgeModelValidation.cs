using Balta.Localizacao.MVVM.Core.utils;
using FluentValidation;

namespace Balta.Localizacao.MVVM.Domain.Models.Validations
{
    public class IbgeModelValidation : AbstractValidator<IbgeModel>
    {
        public static readonly string IdRequiredErrorMessage = "O campo Codigo é obrigatorio.";
        public static readonly string IdLengthErrorMessage = "O campo Codigo deve conter 7 caracteres.";
        public static readonly string IdOnlyNumbersErrorMessage = "O campo Codigo deve conter apenas numeros.";
        public static readonly string CityRequiredErrorMessage = "O campo Cidade é obrigatorio.";
        public static readonly string CityMaxLengthErrorMessage = "O campo Cidade deve conter até 150 caracteres.";
        public static readonly string StateRequiredErrorMessage = "O campo Estado é obrigatorio.";
        public static readonly string StateLengthErrorMessage = "O código Estado conter até 2 caracteres.";

        public IbgeModelValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(IdRequiredErrorMessage)
                .Length(7)
                .WithMessage(IdLengthErrorMessage)
                .Must(id => id.IsOnlyNumbers())
                .WithMessage(IdOnlyNumbersErrorMessage);
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage(CityRequiredErrorMessage)
                .MaximumLength(150)
                .WithMessage(CityMaxLengthErrorMessage);
            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage(StateRequiredErrorMessage)
                .MaximumLength(2)
                .WithMessage(StateLengthErrorMessage);
        }
    }
}
