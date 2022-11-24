using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tibas.Application.Auth.Queries;
using Tibas.WebUI.Controllers;

namespace WebUI.Controllers;

[AllowAnonymous]
public class AuthController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TokenResponseVM>> Login(GETJWTQuery query)
    {
        return await Mediator.Send(query);
    }
}
