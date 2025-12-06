// MoneyTrack.API/Data/MoneyTrackContext.cs
using API.model;
using Microsoft.EntityFrameworkCore;
using MoneyTrack.API.Models;

namespace MoneyTrack.API.Data
{
    public class MoneyTrackContext : DbContext
    {
        public MoneyTrackContext(DbContextOptions<MoneyTrackContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
