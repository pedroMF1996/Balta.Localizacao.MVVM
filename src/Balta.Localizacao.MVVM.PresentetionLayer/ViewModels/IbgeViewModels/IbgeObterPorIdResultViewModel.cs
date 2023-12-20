using Balta.Localizacao.MVVM.Core.Presentaion;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels
{
    public class IbgeObterPorIdResultViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
