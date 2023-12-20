using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class BuscarPorCitySpecification: BaseSpecification<IbgeModel>
    {
        public BuscarPorCitySpecification(string city) :base(x=>x.City.Contains(city))
        {

        }
    }
}
