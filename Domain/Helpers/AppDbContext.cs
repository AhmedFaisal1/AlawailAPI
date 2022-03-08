using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Helpers
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAccount> StudentAccounts { get; set; }
        public DbSet<StudentToll> StudentTolls { get; set; }
        // public DbSet<Income> Incomes { get; set; }
        // public DbSet<Outcome> Outcomes { get; set; }
        
                
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
         
            base.OnModelCreating(builder);
        }
    }
}