using Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RFM.Entities.Conrete;


namespace RFM.Data.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            var connectionString = appSettingsJson["ConnectionStrings:DefaultConnection"];
            optionsBuilder.UseSqlServer(connectionString);
        }
 
        public DbSet<User> Users { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Moviesvote> Moviesvote { get; set; }
        public DbSet<EmailAction> EmailAction { get; set; }

    }
}
