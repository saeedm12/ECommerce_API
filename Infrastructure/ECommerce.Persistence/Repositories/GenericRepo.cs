using ECommerce.Domain;
using ECommerce.Domain.Contracts.Repositories;
using ECommerce.Domain.Contracts.Specifications;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class GenericRepo<TEntity, TKey> : IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext context;

        public GenericRepo(StoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await context.Set<TEntity>().ToListAsync();


        public async Task<TEntity> GetByIdAsync(TKey Id) => await context.Set<TEntity>().FindAsync(Id);
      

        public void Add(TEntity entity) => context.Set<TEntity>().Add(entity);  
       

        public void Update(TEntity entity)=> context.Set<TEntity>().Update(entity);
        

        public void Delete(TEntity entity) => context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecs<TEntity, TKey> specs)
        {
        var Query =await SpecsEvaluation.CreateQuery(context.Set<TEntity>(),specs).ToListAsync();
         return Query;
        }

        public async Task<TEntity> GetByIdWithSpecsAsync(ISpecs<TEntity, TKey> specs)
        {
            var Query = await SpecsEvaluation.CreateQuery(context.Set<TEntity>(), specs).FirstOrDefaultAsync();
            return Query;
        }
    }
}
