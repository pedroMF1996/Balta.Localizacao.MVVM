using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels
{
    public sealed class IbgeAdicionarViewModel : BaseViewModel<IbgeModel>
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
