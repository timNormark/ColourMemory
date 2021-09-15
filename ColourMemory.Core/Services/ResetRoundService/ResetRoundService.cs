using System.Linq;
using System.Threading.Tasks;
using ColourMemory.Core.Models;

namespace ColourMemory.Core.Services.ResetRoundService
{
    public class ResetRoundService : IResetRoundService
    {
        public async Task<GameBoardModel> ResetRound(GameBoardModel gameBoardModel)
        {
            var chosenCards = gameBoardModel.Cards.Where(c => c.IsCurrentlyChosen);
            if (chosenCards.Select(c => c.Colour).Distinct().Count() < 2)
            {
                gameBoardModel.Cards = gameBoardModel.Cards.Where(c => !c.IsCurrentlyChosen).ToList();
            }
            else
            {
                gameBoardModel.Cards.ForEach(c => c.IsCurrentlyChosen = false);
            }
            gameBoardModel.RoundCompleted = false;
            return gameBoardModel;
        }
    }
}
