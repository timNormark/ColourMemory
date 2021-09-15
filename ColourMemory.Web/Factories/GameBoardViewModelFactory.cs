using System.Linq;
using ColourMemory.Core.Models;
using ColourMemory.Web.Models;

namespace ColourMemory.Web.Factories
{
    public static class GameBoardViewModelFactory
    {
        public static GameBoardViewModel Create(GameBoardModel b) =>
            new(b.NumberOfRows, b.NumberOfColumns, b.Score, b.RoundCompleted, b.Cards.Select(c => GameCardViewModelFactory.Create(c)).ToList());
    }
}
