using Tibas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tibas.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Favourite> Favourites { get; } 

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
