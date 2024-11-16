using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Features.User;

namespace THNDotNetCore.MiniKpay.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
