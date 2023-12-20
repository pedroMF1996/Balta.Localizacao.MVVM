using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class BuscarPorStateSpecification: BaseSpecification<IbgeModel>
    {
        public BuscarPorStateSpecification(string state):base(x=>x.State.Contains(state))
        {

        }
    }
}
