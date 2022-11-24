using MediatR;
using Tibas.Application.Common.Interfaces;
using Tibas.Application.Common.Security;

namespace Tibas.Application.GitHub.Queries;

[Authorize]
public record GetHubReposQuery(string Name) : IRequest<GitHubRepoVM>;
public class GetHubReposQueryHandler
{
    private readonly IGitHubRepoHttpService _gitHubRepoHttpService;
    public GetHubReposQueryHandler(IGitHubRepoHttpService gitHubRepoHttpService)
    {
        _gitHubRepoHttpService = gitHubRepoHttpService;
    }

    public async Task<GitHubRepoVM> Handle(GetHubReposQuery request, CancellationToken cancellationToken)
    { 
        return await _gitHubRepoHttpService.SearchReposByName(request.Name);
    }
}
