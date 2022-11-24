namespace Tibas.Application.Favourites.Queries;
public class FavouritesVm
{
    public IList<FavouriteDto> Favourites { get; set; } = new List<FavouriteDto>();
}
