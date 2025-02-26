using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using THNDotNetCore.EncDecWebApi.Services;

namespace THNDotNetCore.EncDecWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
	private readonly EncDecService _encDecService;

    public BlogController(EncDecService encDecService)
    {
        _encDecService = encDecService;
    }

    [HttpPost("Login")]
    public IActionResult Login(BlogLoginRequestModel requestModel)
    {
	try
	{
		var result = UserData.Users.FirstOrDefault(x => x.Username == requestModel.UserName && x.password == requestModel.Password);
			if (result is null)
			{ 
				return Unauthorized();
			}

			var user = new BlogLoginModel
			{
				SessionExpired = DateTime.Now.AddMinutes(1),
				SessionId = Guid.NewGuid().ToString(),
				Username = result.Username
			};

			var Json = JsonConvert.SerializeObject(user);
			var token = _encDecService.Encrypt(Json);

			var model = new BlogLoginResponseModel
			{
				AccessToken = token,
			};
		return Ok(model);
	}
	catch (Exception ex)
	{
		return StatusCode(500, ex.ToString());
	}
    }

	[HttpPost("UserList")]
	public IActionResult UserList(UserListRequestModel request) 
	{
		try
		{
			var json = _encDecService.Decrypt(request.AccessToken);
			var user = JsonConvert.DeserializeObject<BlogLoginModel>(json);
			if(user!.SessionExpired < DateTime.Now)
			{
				return Unauthorized("Session Expired") ;
			}
			return Ok(UserData.Users);
		}
		catch (Exception ex)
		{
			return NotFound(ex.Message);
		}
	}
}

public static class UserData
{
	public static List<UserDTO> Users = new List<UserDTO>
	{
		new UserDTO{ Username = "admin", password = "admin" },
		new UserDTO{ Username = "admin1", password = "admin1" },
		new UserDTO{ Username = "user", password = "user" }
	};
}

public class UserListRequestModel
{
	public string AccessToken { get; set; }
}

public class BlogLoginModel
{
	public string Username { get; set; }
	public string SessionId { get; set; }
	public DateTime SessionExpired { get; set; }
}

public class BlogLoginRequestModel
{
	public string UserName { get; set; }
	public string Password { get; set; }	
}

public class BlogLoginResponseModel
{
	public string AccessToken { get; set; }
}

public class UserDTO
{
	public string Username { get; set; }
	public string password { get; set; }
}