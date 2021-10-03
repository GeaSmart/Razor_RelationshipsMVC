using Microsoft.EntityFrameworkCore;
using SmallExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallExample.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<User> User { get; set; }
    }
}
