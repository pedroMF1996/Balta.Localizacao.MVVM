﻿using Balta.Localizacao.MVVM.Data.SpecificationBase;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.Data.IbgeSpecifications
{
    public class BuscarPorCityStateIdSpecification : BaseSpecification<IbgeModel>
    {
        public BuscarPorCityStateIdSpecification(string?city,string?state,string?id,int size,int skip) : 
            base(x => x.City.Contains(city) && x.State.Contains(state) && x.Id.Contains(id) 
            )
        {
            ApplyPaging(skip, size);
        }

      
    }
}
