
using Balta.Localizacao.MVVM.Domain.Specification;
using Microsoft.EntityFrameworkCore;
namespace Balta.Localizacao.MVVM.Data.SpecificationBase
{

    public class SpecificationEvaluator<TModel> where TModel : class
    {
        public static IQueryable<TModel> GetQuery(IQueryable<TModel> inputQuery, ISpecification<TModel> specification)
        {
            var query = inputQuery;

            query = Criterio(specification, query);

            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            query = OrderBy(specification, query);

            query = OrderByDesc(specification, query);

            query = Pagination(specification, query);

            return query;
        }

        private static IQueryable<TModel> Pagination(ISpecification<TModel> specification, IQueryable<TModel> query)
        {
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                             .Take(specification.Take);
            }

            return query;
        }

        private static IQueryable<TModel> OrderByDesc(ISpecification<TModel> specification, IQueryable<TModel> query)
        {
            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            return query;
        }

        private static IQueryable<TModel> OrderBy(ISpecification<TModel> specification, IQueryable<TModel> query)
        {
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            return query;
        }

        private static IQueryable<TModel> Criterio(ISpecification<TModel> specification, IQueryable<TModel> query)
        {
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            return query;
        }
    }
}
