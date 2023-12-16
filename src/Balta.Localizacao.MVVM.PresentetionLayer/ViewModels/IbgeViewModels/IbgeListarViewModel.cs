using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels
{
    public sealed class IbgeListarViewModel : BaseViewModel<IbgeModel>
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Id { get; set; }
    }
}
