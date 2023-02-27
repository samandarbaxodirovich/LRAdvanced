using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.DataAccess.Interfaces.Common
{
    public interface IGenericRepository<T>
    {
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateAsync(long id, T entity);
        Task<T> GetByIdAsync(long id);
        Task<List<T>> GetAllAsync();
    }
}
