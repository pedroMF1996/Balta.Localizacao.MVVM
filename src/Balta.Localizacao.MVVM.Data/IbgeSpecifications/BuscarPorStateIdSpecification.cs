using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class BuscarPorStateIdSpecification: BaseSpecification<IbgeModel>
    {
        public BuscarPorStateIdSpecification(string state, string id)
            :base(x=>x.State.Contains(state) && x.Id.Contains(id))
        {

        }
    }
}
