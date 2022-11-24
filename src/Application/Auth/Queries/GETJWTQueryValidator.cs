using FluentValidation;

namespace Tibas.Application.Auth.Queries;
public class GETJWTQueryValidator : AbstractValidator<GETJWTQuery>
{
    public GETJWTQueryValidator()
    {
        RuleFor(v => v.LoginName).NotEmpty();

        RuleFor(v => v.Password).NotEmpty();
    }
}
