using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tibas.Application.GitHub.Queries;

namespace Tibas.WebUI.Controllers;

[Authorize]
public class GitHubController : ApiControllerBase
{
    [HttpGet("{searchName}")]
    public async Task<GitHubRepoVM> Get(string searchName)
    {
        return await Mediator.Send(new GetHubReposQuery(searchName));
    }
}
