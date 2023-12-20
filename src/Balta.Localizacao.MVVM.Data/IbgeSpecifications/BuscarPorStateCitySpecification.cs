using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class BuscarPorStateCitySpecification: BaseSpecification<IbgeModel>
    {
        public BuscarPorStateCitySpecification(string state, string city)
            :base(x=>x.State.Contains(state) && x.City.Contains(city))
        {

        }
    }
}
