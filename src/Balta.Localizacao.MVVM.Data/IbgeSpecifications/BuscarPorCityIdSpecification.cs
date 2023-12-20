using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class BuscarPorCityIdSpecification: BaseSpecification<IbgeModel>
    {
        public BuscarPorCityIdSpecification(string city, string id)
            :base(x=>x.City.Contains(city) && x.Id.Contains(id))
        {

        }
    }
}
