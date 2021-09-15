namespace ColourMemory.Core.Models
{
    public class GameCardModel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public GameCardColour Colour { get; set; }
        public bool IsCurrentlyChosen { get; set; }

        public GameCardModel()
        {

        }

        public GameCardModel(int row, int column, GameCardColour colour, bool isCurrentlyChosen)
        {
            Row = row;
            Column = column;
            Colour = colour;
            IsCurrentlyChosen = isCurrentlyChosen;
        }
    }
}
