using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Interfaces;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.Domain.Specification;
using Microsoft.EntityFrameworkCore;

namespace Balta.Localizacao.MVVM.Data.Repositorios
{
    public class IbgeRepository : IIbgeRepository
    {
        private readonly LocalizacaoDbContex _localizacaoDbContex;

        public IbgeRepository(LocalizacaoDbContex localizacaoDbContex)
        {
            _localizacaoDbContex = localizacaoDbContex;
        }

        public IUnitOfWork UnitOfWork => _localizacaoDbContex;

        public async Task AdicionarIbge(IbgeModel ibgeModel)
        {
            await _localizacaoDbContex.Ibges.AddAsync(ibgeModel);
        }

        public async Task EditarIbgeModel(IbgeModel ibgeModel)
        {
            _localizacaoDbContex.Ibges.Update(ibgeModel);
        }

        public async Task<IbgeModel> ObterIbgeModelPorId(string Id)
        {
            return await _localizacaoDbContex.Ibges.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<IbgeModel>> ObterIbgesModel(ISpecification<IbgeModel>filter)
        {
     
            return await AplicandoSpecification(filter)
                                            .AsNoTracking()
                                            .ToListAsync();
        }

        public async Task<IEnumerable<IbgeModel>> ObterIbgesModel()
        {
            return await _localizacaoDbContex.Ibges.AsNoTracking().ToListAsync();
        }

        public async Task RemoverIbgeModel(IbgeModel ibgeModel)
        {

             _localizacaoDbContex.Ibges.RemoveRange(ibgeModel);
        }

        private IQueryable<IbgeModel> AplicandoSpecification(ISpecification<IbgeModel> spec)
        {
            return SpecificationEvaluator<IbgeModel>.GetQuery(_localizacaoDbContex.Set<IbgeModel>().AsQueryable(), spec);
        }
    }
}
