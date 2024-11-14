using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Db;
using THNDotNetCore.MiniKpay.Services;

namespace THNDotNetCore.MiniKpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly UsersService _userService;

        public UsersController(AppDbContext db,UsersService userService)
        {
            _db = db;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var lst = _userService.GetUsers();
            return Ok(lst);
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }
    }
}
