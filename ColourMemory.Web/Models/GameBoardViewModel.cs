using System.Collections.Generic;

namespace ColourMemory.Web.Models
{
    public class GameBoardViewModel
    {
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public int Score { get; set; }
        public bool RoundCompleted { get; set; }
        public List<GameCardViewModel> Cards { get; set; }

        public GameBoardViewModel()
        {

        }

        public GameBoardViewModel(int numberOfRows, int numberOfColumns, int score, bool roundCompleted, List<GameCardViewModel> cards)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            Score = score;
            RoundCompleted = roundCompleted;
            Cards = cards;
        }
    }
}
