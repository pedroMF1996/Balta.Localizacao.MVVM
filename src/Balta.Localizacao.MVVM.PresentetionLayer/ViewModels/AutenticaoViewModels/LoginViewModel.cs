using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels.Validations;
using System.ComponentModel.DataAnnotations;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels
{
	public sealed class LoginViewModel:BaseViewModel<AutenticacaoModel>
    {
		[Required(ErrorMessage = "O campo Email é obrigatório")]
		[EmailAddress(ErrorMessage = "Email inválido")]
		public string Email { get; set; }

		[Required(ErrorMessage = "O campo Senha é obrigatório")]
		public string Password { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new LoginViewModelValidations().Validate(this);
            return base.IsValid();
        }
    }
}
