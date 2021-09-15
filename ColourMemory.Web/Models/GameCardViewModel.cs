using ColourMemory.Core.Models;

namespace ColourMemory.Web.Models
{
    public class GameCardViewModel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public GameCardColour Colour { get; set; }
        public bool IsCurrentlyChosen { get; set; }

        public GameCardViewModel()
        {
        }

        public GameCardViewModel(int row, int column, GameCardColour colour, bool isCurrentlyChosen)
        {
            Row = row;
            Column = column;
            Colour = colour;
            IsCurrentlyChosen = isCurrentlyChosen;
        }
    }
}
