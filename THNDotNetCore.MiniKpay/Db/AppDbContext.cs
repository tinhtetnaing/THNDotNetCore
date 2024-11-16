using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using THNDotNetCore.MiniKpay.Features.Transfer;
using THNDotNetCore.MiniKpay.Features.User;

namespace THNDotNetCore.MiniKpay.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TransferModel> Transfer { get; set; }  
    }
}
