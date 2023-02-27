using LRAdvanced.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRAdvanced.DataAccess.DbContexts
{
    public class MyDbContext:DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host= trumpet.db.elephantsql.com; Port=5432; Database=cuhnoace; User Id = cuhnoace; Password= fDxvJyeMTbDIurb65qMXBXalfaXTiZJY;");
        }
    }
}
