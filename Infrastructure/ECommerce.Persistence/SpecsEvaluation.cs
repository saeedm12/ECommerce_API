using ECommerce.Domain;
using ECommerce.Domain.Contracts.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public static class SpecsEvaluation
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> BaseQuery, ISpecs<TEntity, TKey> specs)
            where TEntity : BaseEntity<TKey>
        {
            var Query = BaseQuery;


            if (specs.Criteria is not null)
            {
                Query = Query.Where(specs.Criteria);
            }

            if(specs.OrderBy is not null)
            {
                Query = Query.OrderBy(specs.OrderBy);
            }

            if(specs.OrderByDesc is not null)
            {
                Query=Query.OrderByDescending(specs.OrderByDesc);
            }


            if (specs.Includes is not null && specs.Includes.Any())
            {
                Query = specs.Includes.Aggregate(Query,(CurrentQuery,Expression)=>CurrentQuery.Include(Expression));    
            }
            

            return Query;
        }
            

    }
}
