using System.Threading.Tasks;
using ColourMemory.Core.Models;

namespace ColourMemory.Core.Services.ResetRoundService
{
    public interface IResetRoundService
    {
        public Task<GameBoardModel> ResetRound(GameBoardModel gameBoardModel);
    }
}
