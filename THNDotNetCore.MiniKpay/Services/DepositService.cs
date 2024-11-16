using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Db;
using THNDotNetCore.MiniKpay.Features.User;

namespace THNDotNetCore.MiniKpay.Services
{
    public class DepositService
    {
        private readonly AppDbContext _db;

        public DepositService(AppDbContext db)
        {
            _db = db;
        }

        #region Deposit
        public UserModel? GetUserByMobileNo(string mobileNo)
        {
            var user = _db.Users.AsNoTracking().FirstOrDefault(x => x.MobileNumber == mobileNo);
            if (user is null)
            {
                return null;
            }
            return user;
        }
        #endregion Deposit
    }
}
