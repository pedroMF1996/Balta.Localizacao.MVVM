using FluentValidation;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels.Validations
{
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
