using ECommerce.Domain.Contracts.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Contracts.Repositories
{
    public interface IGenericRepo<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task <IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey Id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecs<TEntity,TKey> specs);
        Task<TEntity> GetByIdWithSpecsAsync(ISpecs<TEntity,TKey> specs);

    }
}
