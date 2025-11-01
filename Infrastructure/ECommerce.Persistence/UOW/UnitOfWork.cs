using ECommerce.Domain;
using ECommerce.Domain.Contracts.Repositories;
using ECommerce.Domain.Contracts.UOW;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.UOW
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly StoreDbContext context;
        private readonly Dictionary<string,object> _Repos = [];

        public UnitOfWork(StoreDbContext context)
        {
            this.context = context;
        }

        public IGenericRepo<TEntity, TKey> GetRepo<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
           var TypeName = typeof(TEntity).Name;

            if (_Repos.ContainsKey(TypeName)) return (IGenericRepo<TEntity,TKey>) _Repos[TypeName];


            else
            {
                var Repo = new GenericRepo<TEntity, TKey>(context);
                _Repos.Add(TypeName, Repo);
                return Repo;
            }

         
        }

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
       
    }
}
