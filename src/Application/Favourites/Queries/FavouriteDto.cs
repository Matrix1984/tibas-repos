using AutoMapper;
using Tibas.Application.Common.Mappings;
using Tibas.Domain.Entities;

namespace Tibas.Application.Favourites.Queries;

public class FavouriteDto : IMapFrom<Favourite>
{
    public int Id { get; set; }

    public long GitHubId { get; set; }

    public string GitHubName { get; set; }

    public string GitOwnerName { get; set; }

    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Favourite, FavouriteDto>();
    }
}
