using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tibas.Application.Common.Interfaces;
using Tibas.Domain.Exceptions;
using Tibas.Domain.ValueObjects;

namespace Tibas.Application.Auth.Queries;
public record GETJWTQuery(string LoginName, string Password) : IRequest<TokenResponseVM>;

public class GETJWTQueryHandler : IRequestHandler<GETJWTQuery, TokenResponseVM>
{
    private readonly JWTokenOptions _jwtOptions;

    private readonly IIdentityService _identityService;

    public GETJWTQueryHandler(IOptions<JWTokenOptions> options, IIdentityService identityService)
    {
        _jwtOptions = options.Value;
        _identityService = identityService;
    }

    public async Task<TokenResponseVM> Handle(GETJWTQuery request, CancellationToken cancellationToken)
    {
        UserDto userVM = null;

        try
        {
            userVM = await _identityService.LoginAsync(request.LoginName, request.Password); 
        }
        catch (AuthorizationException ex)
        {
            return new TokenResponseVM() { Token = null, Error=ex.Message, ErrorCode=403 };
        }

        var tokenString = new JwtSecurityTokenHandler().WriteToken(GetJWTTokenOptions(userVM));

        return new TokenResponseVM() { Token = tokenString }; 
    }

    private JwtSecurityToken GetJWTTokenOptions(UserDto userVM)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: GetClaims(),
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signinCredentials
        );

        List<Claim> GetClaims()
        {
            return new List<Claim>()
            {
                new Claim(type:ClaimTypes.NameIdentifier,value:userVM.Id),
                new Claim(type:"Email",value:userVM.Name)
            };
        }
    }
}
