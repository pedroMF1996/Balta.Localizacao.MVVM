using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels
{
    public sealed class LoginViewModel:BaseViewModel<IbgeModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
