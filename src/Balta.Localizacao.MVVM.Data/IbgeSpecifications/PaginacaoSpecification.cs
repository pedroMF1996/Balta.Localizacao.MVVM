using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class PaginacaoSpecification: BaseSpecification<IbgeModel>
    {
        public PaginacaoSpecification(int skip, int size)
        { 
            ApplyPaging(skip, size);
            
        }
    }
}
