using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tibas.Application.Favourites.Queries;
using Tibas.Application.Favourites.Commands.CreateFavourite;
using Tibas.Application.Favourites.Commands.DeleteFavourite;
using Tibas.Application.Common.Interfaces;

namespace Tibas.WebUI.Controllers;

[Authorize]
public class FavouriteController : ApiControllerBase
{
    private readonly ICurrentUserService _currentUserService;
    public FavouriteController(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    [HttpPost]
    public async Task<ActionResult<FavouriteVm>> Create(CreateFavouriteCommand command)
    {
        return await Mediator.Send(command with { UserId = _currentUserService.UserId });
    }

    [HttpGet]
    public async Task<ActionResult<FavouritesVm>> ListFavourites()
    {
        return await Mediator.Send(new GetFavouritesQuery(_currentUserService.UserId));
    } 

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteFavouriteCommand(id, _currentUserService.UserId));

        return NoContent();
    }
}