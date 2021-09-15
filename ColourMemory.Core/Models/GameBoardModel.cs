using System.Collections.Generic;

namespace ColourMemory.Core.Models
{
    public class GameBoardModel
    {
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public int Score { get; set; }
        public bool RoundCompleted { get; set; }
        public List<GameCardModel> Cards { get; set; }

        public GameBoardModel()
        {

        }

        public GameBoardModel(int numberOfRows, int numberOfColumns, int score, bool roundCompleted, List<GameCardModel> cards)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            Score = score;
            RoundCompleted = roundCompleted;
            Cards = cards;
        }
    }
}
