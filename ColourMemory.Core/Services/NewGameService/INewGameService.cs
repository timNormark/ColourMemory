using System.Threading.Tasks;
using ColourMemory.Core.Models;

namespace ColourMemory.Core.Services.NewGameService
{
    public interface INewGameService
    {
        public Task<GameBoardModel> StartNewGame();
    }
}
