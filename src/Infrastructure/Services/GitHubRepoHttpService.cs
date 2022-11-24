using System.Net.Http.Json;
using Tibas.Application.Common.Interfaces;
using Tibas.Application.GitHub.Queries;

namespace Tibas.Infrastructure.Services;
public class GitHubRepoHttpService : IGitHubRepoHttpService
{
    private readonly HttpClient _httpClient;

    public GitHubRepoHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GitHubRepoVM> SearchReposByName(string name)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _httpClient.GetFromJsonAsync<GitHubRepoVM>(
                 $"/search/repositories?q={name}");
#pragma warning restore CS8603 // Possible null reference return.
    }
}
