using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.Data.Data
{
    public interface IIbgeRepository : IRepository<IbgeModel>
    {
        Task AdicionarIbge(IbgeModel ibgeModel);
        Task EditarIbgeModel(IbgeModel ibgeModel);
        Task RemoverIbgeModel(IbgeModel ibgeModel);
        Task<IEnumerable<IbgeModel>> ObterIbgesModel(ISpecification filter);
    }
}
