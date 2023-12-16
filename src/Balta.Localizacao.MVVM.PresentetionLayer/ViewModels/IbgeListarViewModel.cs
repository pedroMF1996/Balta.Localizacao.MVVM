using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels
{
    public sealed class IbgeListarViewModel:BaseViewModel<IbgeModel>
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string IbgeId { get; set; }
    }
}
