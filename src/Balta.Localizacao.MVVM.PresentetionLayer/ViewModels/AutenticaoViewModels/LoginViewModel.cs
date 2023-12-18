using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using FluentValidation;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels
{
	public sealed class LoginViewModel:BaseViewModel<AutenticacaoModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }

		public override bool IsValid()
		{
            ValidationResult = new LoginViewModelValidations().Validate(this);
			return base.IsValid();
		}
	}

    public class LoginViewModelValidations : AbstractValidator<LoginViewModel>
    {
        public static readonly string EmailInvalidErrorMessage = "Email inválido";
        public static readonly string EmailRequiredErrorMessage = "O campo Email é obrigatório";
        public static readonly string PasswordRequiredErrorMessage = "O campo Senha é obrigatório";
        public LoginViewModelValidations()
        {
            RuleFor(vm => vm.Email)
                .NotEmpty()
                .WithMessage(EmailRequiredErrorMessage)
                .EmailAddress()
                .WithMessage(EmailInvalidErrorMessage);

            RuleFor(vm => vm.Password)
                .NotEmpty()
                .WithMessage(PasswordRequiredErrorMessage);
        }
    }
}
