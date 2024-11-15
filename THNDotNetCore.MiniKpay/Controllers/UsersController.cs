using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Db;
using THNDotNetCore.MiniKpay.Models;
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
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var lst = _userService.GetUsers();
            return Ok(lst);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UserModel user)
        {
            var result = _userService.CreateUser(user);
            if(result == 0)
            {
                return BadRequest("User Create Failed.");
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, UserModel user)
        {
            var result = _userService.UpdateUser(id, user);
            if (result == 0)
            {
                return BadRequest("User Update Failed.");
            }
            return Ok(user);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result == 0)
            {
                return BadRequest("User Delete Failed.");
            }
            return Ok("User Delete success");
        }
    }
}
