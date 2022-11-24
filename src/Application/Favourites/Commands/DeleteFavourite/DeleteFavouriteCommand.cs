using MediatR;
using Microsoft.EntityFrameworkCore;
using Tibas.Application.Common.Exceptions;
using Tibas.Application.Common.Interfaces;
using Tibas.Domain.Entities;

namespace Tibas.Application.Favourites.Commands.DeleteFavourite;

public record DeleteFavouriteCommand(int Id, string userId) : IRequest;
public class DeleteFavouriteCommandHandler : IRequestHandler<DeleteFavouriteCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteFavouriteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteFavouriteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Favourites
            .Where(l => l.Id == request.Id && l.UserId == request.userId)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Favourite), request.Id);
        }

        _context.Favourites.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}
