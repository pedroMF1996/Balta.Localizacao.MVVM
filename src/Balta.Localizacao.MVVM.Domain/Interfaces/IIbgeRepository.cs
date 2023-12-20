using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.Domain.Specification;

namespace Balta.Localizacao.MVVM.Domain.Interfaces
{
    public interface IIbgeRepository : IRepository<IbgeModel>
    {
        Task AdicionarIbge(IbgeModel ibgeModel);
        Task EditarIbgeModel(IbgeModel ibgeModel);
        Task RemoverIbgeModel(IbgeModel ibgeModel);
        Task<IEnumerable<IbgeModel>> ObterIbgesModel(ISpecification<IbgeModel> filter);
        Task<IEnumerable<IbgeModel>> ObterIbgesModel();
    }
}
