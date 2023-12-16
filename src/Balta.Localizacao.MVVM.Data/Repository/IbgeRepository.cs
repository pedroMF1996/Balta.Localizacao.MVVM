using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Interfaces;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.Domain.Specification;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _localizacaoDbContex.Ibges.ExecuteUpdateAsync(
                x=>x
                    .SetProperty(x=>x.Id,x=>ibgeModel.Id)
                    .SetProperty(x=>x.City,x=> ibgeModel.City)
                    .SetProperty(x=>x.State,x=>ibgeModel.State)
                );
        }

        public async Task<IEnumerable<IbgeModel>> ObterIbgesModel(ISpecification<IbgeModel>filter)
        {
     
            return await AplicandoSpecification(filter)
                                            .AsNoTracking()
                                            .ToListAsync();
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
