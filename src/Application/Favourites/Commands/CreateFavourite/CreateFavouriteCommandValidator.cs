using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Tibas.Application.Common.Interfaces;

namespace Tibas.Application.Favourites.Commands.CreateFavourite;
public class CreateFavouriteCommandValidator : AbstractValidator<CreateFavouriteCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateFavouriteCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.GitHubId)
            .GreaterThan(0).WithMessage("GitHubId is required.")
            .MustAsync(BeUniqueGitHubId).WithMessage("The specified GitHubId already exists in favorites.");

        RuleFor(v => v.GitHubName)
         .NotEmpty().WithMessage("GitHubName is required.")
         .MaximumLength(200).WithMessage("GitHubName must not exceed 200 characters.");

        RuleFor(v => v.GitOwnerName)
             .NotEmpty().WithMessage("GitOwnerName is required.")
             .MaximumLength(200).WithMessage("GitOwnerName must not exceed 200 characters.");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(v => v.UserId)
        .NotEmpty().WithMessage("UserId is required.");
    }

    public async Task<bool> BeUniqueGitHubId(long gitHubId, CancellationToken cancellationToken)
    {
        return await _context.Favourites
            .AllAsync(l => l.GitHubId != gitHubId, cancellationToken);
    }
}