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
        public RegistrarUsuarioViewModelValidations()
        {
			RuleFor(vm => vm.Email)
				.NotEmpty()
				.WithMessage("O campo Email é obrigatório")
				.EmailAddress()
				.WithMessage("Email inválido");

			RuleFor(vm => vm.Password)
				.NotEmpty()
				.WithMessage("O campo Senha é obrigatório");

            RuleFor(vm => vm.ConfirmPassword)
                .Must((vm, confirmPassword) => vm.Password == confirmPassword)
                .WithMessage("O campo confirmacao de senha deve corresponder ao campo senha");
		}
    }
}
