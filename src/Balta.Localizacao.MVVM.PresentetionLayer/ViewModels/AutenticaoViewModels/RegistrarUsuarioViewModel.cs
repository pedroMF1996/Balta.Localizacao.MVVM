using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels
{
    public sealed class RegistrarUsuarioViewModel : BaseViewModel<AutenticacaoModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

		public override bool IsValid()
		{
			ValidationResult = new RegistrarUsuarioViewModelValidations().Validate(this);
			return base.IsValid();
		}
	}

    public class RegistrarUsuarioViewModelValidations : AbstractValidator<RegistrarUsuarioViewModel>
    {
		public static readonly string EmailInvalidErrorMessage = "Email inválido";
		public static readonly string EmailRequiredErrorMessage = "O campo Email é obrigatório";
		public static readonly string PasswordRequiredErrorMessage = "O campo Senha é obrigatório";
		public static readonly string ConfirmPasswordUnmatchedErrorMessage = "O campo confirmacao de senha deve corresponder ao campo senha";
		public RegistrarUsuarioViewModelValidations()
        {
			RuleFor(vm => vm.Email)
				.NotEmpty()
				.WithMessage(EmailRequiredErrorMessage)
				.EmailAddress()
				.WithMessage(EmailInvalidErrorMessage);

			RuleFor(vm => vm.Password)
				.NotEmpty()
				.WithMessage(PasswordRequiredErrorMessage);

			RuleFor(vm => vm.ConfirmPassword)
                .Must((vm, confirmPassword) => vm.Password == confirmPassword)
                .WithMessage(ConfirmPasswordUnmatchedErrorMessage);
		}
    }
}
