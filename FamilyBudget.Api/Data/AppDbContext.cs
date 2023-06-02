using FamilyBudget.Api.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudget.Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        //public DbSet<User> Users { get; set; } this will come form Identity
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { 
        }
    }
}
