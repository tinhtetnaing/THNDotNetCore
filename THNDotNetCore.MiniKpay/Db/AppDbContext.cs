using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Models;

namespace THNDotNetCore.MiniKpay.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UsersModel> Users { get; set; }
    }
}
