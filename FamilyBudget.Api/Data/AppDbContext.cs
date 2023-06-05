using FamilyBudget.Api.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudget.Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<BudgetShare> BusfetShare { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { 
        }
    }
}
