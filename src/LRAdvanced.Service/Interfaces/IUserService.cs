using LRAdvanced.Domain.Entities;
using LRAdvanced.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.Service.Interfaces
{
    public interface IUserService
    {
        public Task<bool> IsValid(string email, string password);
        public Task<bool> CreateUser(RegisterDto user);
    }
}
