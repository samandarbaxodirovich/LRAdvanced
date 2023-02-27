using LRAdvanced.Service.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.Service.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public (string PasswordHash, string Salt) Hash(string password)
        {
            string salt = GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
            return (PasswordHash: hash, Salt: salt);
        }

        public bool Verify(string password, string salt, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, passwordHash);
        }
        public string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
