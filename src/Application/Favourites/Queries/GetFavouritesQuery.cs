using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tibas.Application.Common.Interfaces;
using Tibas.Application.Common.Security;

namespace Tibas.Application.Favourites.Queries;

[Authorize]
public record GetFavouritesQuery(string userId) : IRequest<FavouritesVm>;

public class GetFavouriteQueryHandler : IRequestHandler<GetFavouritesQuery, FavouritesVm>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetFavouriteQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FavouritesVm> Handle(GetFavouritesQuery request, CancellationToken cancellationToken)
    {
        return new FavouritesVm
        {
            Favourites = await _context.Favourites
                .AsNoTracking()
                .ProjectTo<FavouriteDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
    }
}
