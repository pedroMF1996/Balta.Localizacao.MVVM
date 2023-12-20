using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class BuscarPorStateSpecification: BaseSpecification<IbgeModel>
    {
        public BuscarPorStateSpecification(string state):base(x=>x.State.Contains(state))
        {

        }
    }
}
