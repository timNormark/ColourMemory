using System.Linq;
using System.Threading.Tasks;
using ColourMemory.Core.Models;

namespace ColourMemory.Core.Services.MakeMoveService
{
    public class MakeMoveService : IMakeMoveService
    {
        public async Task<GameBoardModel> MakeMove(GameBoardModel gameBoardModel, int chosenRow, int chosenCol)
        {
            var chosenCard = gameBoardModel.Cards.FirstOrDefault(c => c.Row == chosenRow && c.Column == chosenCol);
            if (chosenCard == null)
                return gameBoardModel;

            chosenCard.IsCurrentlyChosen = true;

            var chosenCards = gameBoardModel.Cards.Where(c => c.IsCurrentlyChosen);
            if (chosenCards.Count() > 1)
            {
                if(chosenCards.Select(c => c.Colour).Distinct().Count() < 2)
                {
                    gameBoardModel.Score += 1;
                }
                gameBoardModel.RoundCompleted = true;
            }

            return gameBoardModel;
        }
    }
}
