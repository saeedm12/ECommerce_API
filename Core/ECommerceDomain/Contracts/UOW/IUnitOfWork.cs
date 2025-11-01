using ECommerce.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Contracts.UOW
{
    public interface IUnitOfWork
    {
    IGenericRepo<TEntity,TKey> GetRepo<TEntity,TKey>() where TEntity :  BaseEntity<TKey>;
        
    Task<int> SaveChangesAsync();

    }
}
