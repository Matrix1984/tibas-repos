using Tibas.Application.Auth.Queries;
using Tibas.Application.Common.Models;

namespace Tibas.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<UserDto> LoginAsync(string userName, string password);
    Task<string> GetUserNameAsync(string userId);   
    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);  
}
