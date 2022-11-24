using AutoMapper;
using MediatR;
using Tibas.Application.Auth.Queries;
using Tibas.Application.Common.Interfaces;
using Tibas.Application.Favourites.Queries;
using Tibas.Domain.Entities;

namespace Tibas.Application.Favourites.Commands.CreateFavourite;

public record CreateFavouriteCommand : IRequest<FavouriteVm>
{
    public long GitHubId { get; set; }

    public string GitHubName { get; set; }

    public string GitOwnerName { get; set; }

    public string Description { get; set; }

    public string UserId { get; set; }
}

public class CreateFavouriteCommandHandler : IRequestHandler<CreateFavouriteCommand, FavouriteVm>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public CreateFavouriteCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FavouriteVm> Handle(CreateFavouriteCommand request, CancellationToken cancellationToken)
    {
        var entity = new Favourite();

        entity.GitHubId = request.GitHubId;

        entity.GitHubName = request.GitHubName;

        entity.GitOwnerName = request.GitOwnerName;

        entity.Description = request.Description;

        entity.UserId = request.UserId;

        _context.Favourites.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<FavouriteVm>(entity);
    }
}
