using Microsoft.EntityFrameworkCore;
using Pratik_Identity.Model;
using System.Collections.Generic;

namespace Pratik_Identity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
