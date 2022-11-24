using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tibas.Application.Auth.Queries;
using Tibas.Infrastructure.Identity;
using Tibas.WebUI.Controllers;

namespace WebUI.Controllers;

[AllowAnonymous]
public class AuthController : ApiControllerBase
{

    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult<TokenResponseVM>> Login(GETJWTQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost("Logout")]
    public async void Logout()
    {
        await HttpContext.SignOutAsync(); 
    }
}
