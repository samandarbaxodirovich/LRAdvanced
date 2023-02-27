using LRAdvanced.DataAccess.Interfaces.Common;
using LRAdvanced.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.DataAccess.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
