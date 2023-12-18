using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels.Validations;

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
}
