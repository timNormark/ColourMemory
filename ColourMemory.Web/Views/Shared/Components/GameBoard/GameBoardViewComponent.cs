using System.Threading.Tasks;
using ColourMemory.Core.Services.NewGameService;
using ColourMemory.Web.Factories;
using ColourMemory.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColourMemory.Web.Views.Shared.Components.GameBoard
{
    public class GameBoardViewComponent : ViewComponent
    {
        private readonly INewGameService _newGameService;

        public GameBoardViewComponent(INewGameService newGameService)
        {
            _newGameService = newGameService;
        }

        public async Task<IViewComponentResult> InvokeAsync(GameBoardViewModel gameBoard)
        {
            if(gameBoard == null)
            {
                var newGameBoardResult = await _newGameService.StartNewGame();
                gameBoard = GameBoardViewModelFactory.Create(newGameBoardResult);
            }

            return View(gameBoard);
        }
    }
}
