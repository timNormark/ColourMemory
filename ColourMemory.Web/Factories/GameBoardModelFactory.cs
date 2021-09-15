using System.Linq;
using ColourMemory.Core.Models;
using ColourMemory.Web.Models;

namespace ColourMemory.Web.Factories
{
    public static class GameBoardModelFactory
    {
        public static GameBoardModel Create(GameBoardViewModel b) =>
            new(b.NumberOfRows, b.NumberOfColumns, b.Score, b.RoundCompleted, b.Cards.Select(c => GameCardModelFactory.Create(c)).ToList());
    }
}
