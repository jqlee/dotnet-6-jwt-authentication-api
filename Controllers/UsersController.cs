namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [Permission("600")]
    [HttpGet("test")]
    public IActionResult GetTest()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

	public override OkObjectResult Ok([ActionResultObjectValue] object value) {
    
  return Ok(value);
		return base.Ok(value);
	}

 // public OkObjectResult Ok<T>(IEnumerable<T> list) where T : IOwnedEntity {
    
 //   return base.OK(list);
	//}
}

public class Permission {
  string code;
  public Permission(string code){
      this.code = code;
  }


  public static bool IsPass<T>(string httpMethod, IList<T> list){

    return true;
	}
}

public interface IOwnedEntity {
  int OwnerId { get; set; }
}
