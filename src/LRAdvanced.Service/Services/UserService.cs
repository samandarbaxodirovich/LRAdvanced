using LRAdvanced.DataAccess.Repositories;
using LRAdvanced.Domain.Entities;
using LRAdvanced.Service.Dtos;
using LRAdvanced.Service.Interfaces;
using LRAdvanced.Service.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.Service.Services
{
    public class UserService : IUserService
    {
        UserRepository _work = new UserRepository();
        PasswordHasher _hasher = new PasswordHasher();
        public async Task<bool> CreateUser(RegisterDto user)
        {
            var result = _hasher.Hash(user.Password);
            return await _work.CreateAsync
                (new User() { Email= user.Email,Salt = result.Salt,PasswordHash = result.PasswordHash });
        }
        public async Task<bool> IsValid(string email, string password)
        {
            var user = await _work.GetByEmailAsync(email);
            if (user != null)
                if (_hasher.Verify(password, user.Salt, user.PasswordHash))
                    return true;
            return false;
        }
    }
}
