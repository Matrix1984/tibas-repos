using MediatR;
using Tibas.Application.Common.Interfaces;
using Tibas.Application.Common.Security;
using Tibas.Application.Favourites.Commands.CreateFavourite;
using Tibas.Application.Favourites.Queries;

namespace Tibas.Application.GitHub.Queries;

[Authorize]
public record GetHubReposQuery(string Name) : IRequest<GitHubRepoVM>;
public class GetHubReposQueryHandler : IRequestHandler<GetHubReposQuery, GitHubRepoVM>
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
