using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Db;
using THNDotNetCore.MiniKpay.Features.User;

namespace THNDotNetCore.MiniKpay.Services
{
    public class UserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        #region User
        public List<UserModel>? GetUsers()
        {
            var lst = _db.Users.AsNoTracking().ToList();
            if (lst is null)
            {
                return null;
            }
            return lst;
        }

        public UserModel GetUserById(int id)
        {
            var user = _db.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(user is null)
            {
                return null;
            }
            return user;
        }

        public int CreateUser(UserModel user)
        {
            _db.Users.Add(user);  
            var result = _db.SaveChanges();
            return result;
        }

        public int UpdateUser(int id, UserModel userModel)
        {
            var user = _db.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(user is null)
            {
                return 0;
            }
            user.Name = userModel.Name;
            user.MobileNumber = userModel.MobileNumber;
            user.Balance = userModel.Balance;
            user.Pin = userModel.Pin;

            _db.Entry(user).State = EntityState.Modified;
            var result = _db.SaveChanges();
            return result;
        }

        public int DeleteUser(int id)
        {
            var user = _db.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                return 0;
            }

            _db.Entry(user).State = EntityState.Deleted;
            var result = _db.SaveChanges();
            return result;
        }
        #endregion User

    }
}
