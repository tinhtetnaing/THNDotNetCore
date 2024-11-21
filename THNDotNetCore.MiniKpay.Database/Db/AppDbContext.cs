using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using THNDotNetCore.MiniKpay.Database.Models;

namespace THNDotNetCore.Database.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TransferModel> Transfer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source = DESKTOP-EPUBLLL; Initial Catalog= MiniKpay; User ID= sa; Password = sa@123; TrustServerCertificate = true";
                optionsBuilder.UseSqlServer(connectionString);  
            }
        }
    }
}
