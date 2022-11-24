using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibas.Application.GitHub.Queries;

namespace Tibas.Application.Common.Interfaces;
public interface IGitHubRepoHttpService
{
    Task<GitHubRepoVM> SearchReposByName(string name);
}
