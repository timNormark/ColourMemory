using ColourMemory.Core.Models;
using ColourMemory.Web.Models;

namespace ColourMemory.Web.Factories
{
    public static class GameCardViewModelFactory
    {
        public static GameCardViewModel Create(GameCardModel c) =>
            new(c.Row, c.Column, c.Colour, c.IsCurrentlyChosen);
    }
}
