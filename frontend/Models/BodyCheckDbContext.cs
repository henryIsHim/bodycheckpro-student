using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BodyCheckMVCWebAPIClient.Models
{
    public class BodyCheckDbContext : DbContext
    {
        public BodyCheckDbContext(DbContextOptions<BodyCheckDbContext> options) : base(options) { }
        public DbSet<BodyCheckViewModel> BodyChecks { get; set; }  // BodyChecks is Db's Table Name
    }
}