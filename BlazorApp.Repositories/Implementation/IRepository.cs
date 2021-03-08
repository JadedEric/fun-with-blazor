using BlazorApp.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Repositories.Implementation
{
    public interface IRepository<T> where T: Entity
    {
        DbSet<T> Entity { get; }

        Task<int> Delete(int id);

        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task<int> Post(T entity);

        Task<int> Put(T entity);
    }
}
