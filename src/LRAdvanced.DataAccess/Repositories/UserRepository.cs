using LRAdvanced.DataAccess.DbContexts;
using LRAdvanced.DataAccess.Interfaces;
using LRAdvanced.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> CreateAsync(User user)
        {
            using (var context = new MyDbContext())
            {
                await context.Users.AddAsync(user);
                if (await context.SaveChangesAsync() != 0)
                    return true;
                else return false;
            }
        }
        public async Task<List<User>> GetAllAsync()
        {
            using(var context = new MyDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            using (var context = new MyDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x=>x.Email == email);
                if(user != null) return user;
                else return null!;
            }
        }
        public async Task<User> GetByIdAsync(long id)
        {
            using (var context = new MyDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user != null) return user;
                else return null!;
            }
        }
        public async Task<bool> UpdateAsync(long id, User entity)
        {
            using(var context = new MyDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if(user != null)
                {
                    user.Email = entity.Email;
                    user.PasswordHash = entity.PasswordHash;
                    user.Salt = entity.Salt;
                    context.Users.Update(user);
                    if(await context.SaveChangesAsync() != 0)
                        return true;
                    else return false;
                }
                else return false;
            }
        }
    }
}
