using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tibas.Application.Auth.Queries;
using Tibas.Application.Common.Interfaces;
using Tibas.Application.Common.Models;
using Tibas.Domain.Exceptions;

namespace Tibas.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDto> LoginAsync(string userName, string password)
    {
        var user = await _userManager.FindByEmailAsync(userName);

        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            throw new AuthorizationException("Username or password are incorrect.");
         
        return new UserDto()
        {
            Id = user.Id,
            Name = userName
        };
    }

    public async Task<string> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }
}
