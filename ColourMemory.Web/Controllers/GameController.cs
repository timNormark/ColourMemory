using System.Threading.Tasks;
using ColourMemory.Core.Services.MakeMoveService;
using ColourMemory.Core.Services.ResetRoundService;
using ColourMemory.Web.Factories;
using ColourMemory.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColourMemory.Web.Controllers
{
    [Route("game")]
    public class GameController : Controller
    {
        private readonly IMakeMoveService _makeMoveService;
        private readonly IResetRoundService _resetRoundService;

        public GameController(IMakeMoveService makeMoveService, IResetRoundService resetRoundService)
        {
            _makeMoveService = makeMoveService;
            _resetRoundService = resetRoundService;
        }

        [HttpPost, Route("make-move")]
        public async Task<IActionResult> MakeMove(GameBoardViewModel gameBoardViewModel, int row, int column)
        {
            ModelState.Clear();
            var gameBoardModel = GameBoardModelFactory.Create(gameBoardViewModel);
            gameBoardModel = await _makeMoveService.MakeMove(gameBoardModel, row, column);
            var newGameBoardViewModel = GameBoardViewModelFactory.Create(gameBoardModel);
            return ViewComponent("GameBoard", newGameBoardViewModel);
        }

        [HttpPost, Route("reset-round")]
        public async Task<IActionResult> ResetRound(GameBoardViewModel gameBoardViewModel)
        {
            ModelState.Clear();
            var gameBoardModel = GameBoardModelFactory.Create(gameBoardViewModel);
            gameBoardModel = await _resetRoundService.ResetRound(gameBoardModel);
            var newGameBoardViewModel = GameBoardViewModelFactory.Create(gameBoardModel);
            return ViewComponent("GameBoard", newGameBoardViewModel);
        }
    }
}
