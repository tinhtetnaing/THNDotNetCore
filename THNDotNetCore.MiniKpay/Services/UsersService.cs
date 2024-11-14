using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Db;
using THNDotNetCore.MiniKpay.Models;

namespace THNDotNetCore.MiniKpay.Services
{
    public class UsersService
    {
        private readonly AppDbContext _db;

        public UsersService(AppDbContext db)
        {
            _db = db;
        }

        public List<UsersModel>? GetUsers()
        {
            var lst = _db.Users.AsNoTracking().ToList();
            if (lst is null)
            {
                return null;
            }
            return lst;
        }

        public UsersModel GetUserById(int id)
        {
            var user = _db.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(user is null)
            {
                return null;
            }
            return user;
        }
    }
}
