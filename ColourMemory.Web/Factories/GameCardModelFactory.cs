using ColourMemory.Core.Models;
using ColourMemory.Web.Models;

namespace ColourMemory.Web.Factories
{
    public static class GameCardModelFactory
    {
        public static GameCardModel Create(GameCardViewModel c) =>
            new(c.Row, c.Column, c.Colour, c.IsCurrentlyChosen);
    }
}
