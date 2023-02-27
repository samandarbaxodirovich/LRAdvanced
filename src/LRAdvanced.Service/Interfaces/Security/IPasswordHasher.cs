using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.Service.Interfaces.Security
{
    public interface IPasswordHasher
    {
        public (string PasswordHash, string Salt) Hash(string password);
        public bool Verify(string password, string salt, string passwordHash);
        public string GenerateSalt();
    }
}
