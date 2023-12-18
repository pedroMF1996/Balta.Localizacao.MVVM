using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels
{
	public sealed class RegistrarUsuarioViewModel : BaseViewModel<AutenticacaoModel>
    {
		[Required(ErrorMessage = "O campo Email é obrigatório")]
		[EmailAddress(ErrorMessage = "Email inválido")]
		public string Email { get; set; }
		[Required(ErrorMessage = "O campo Senha é obrigatório")]
		public string Password { get; set; }
		[Compare(nameof(Password), ErrorMessage = "O campo confirmacao de senha deve corresponder ao campo senha")]
		public string ConfirmPassword { get; set; }
	}
}
