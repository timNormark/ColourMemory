using System.Threading.Tasks;
using ColourMemory.Core.Models;

namespace ColourMemory.Core.Services.MakeMoveService
{
    public interface IMakeMoveService
    {
        public Task<GameBoardModel> MakeMove(GameBoardModel gameBoardModel, int chosenRow, int chosenCol);
    }
}
