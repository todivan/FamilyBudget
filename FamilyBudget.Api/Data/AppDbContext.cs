using FamilyBudget.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudget.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { 
        }
    }
}
