using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColourMemory.Core.Models;

namespace ColourMemory.Core.Services.NewGameService
{
    public class NewGameService : INewGameService
    {
        private readonly ColourMemorySettings _colourMemorySettings;
        private readonly Random _random = new();
        private readonly GameCardColour[] _colours = (GameCardColour[])Enum.GetValues(typeof(GameCardColour));

        public NewGameService(ColourMemorySettings colourMemorySettings)
        {
            _colourMemorySettings = colourMemorySettings;
        }

        public async Task<GameBoardModel> StartNewGame()
        {
            return new GameBoardModel
            {
                NumberOfColumns = _colourMemorySettings.NumberOfColumns,
                NumberOfRows = _colourMemorySettings.NumberOfRows,
                Cards = GenerateGameCards(_colourMemorySettings.NumberOfRows, _colourMemorySettings.NumberOfColumns)
            };
        }

        private List<GameCardModel> GenerateGameCards(int numberOfRows, int numberOfColumns)
        {
            var gameCards = new List<GameCardModel>();
            int numberOfPairs = (numberOfRows * numberOfColumns) / 2;

            List<(int row, int column)> coordinatesList = GenerateAllCordinates(numberOfRows, numberOfColumns);
            Stack<(int row, int column)> coordinates = ListToShuffledStack(coordinatesList);

            for(int i = 0; i < numberOfPairs; i++)
            {
                var colour = GetRandomColour();

                var coordinate = coordinates.Pop();
                gameCards.Add(BuildGameCard(colour, coordinate));

                coordinate = coordinates.Pop();
                gameCards.Add(BuildGameCard(colour, coordinate));
            }
            return gameCards;
        }

        private List<(int row, int column)> GenerateAllCordinates(int numberOfRows, int numberOfColumns)
        {
            var coordinates = new List<(int row, int column)>();
            for(int i = 0; i < numberOfRows; i++)
            {
                for(int j = 0; j < numberOfColumns; j++)
                {
                    coordinates.Add((i, j));
                }
            }
            return coordinates;
        }

        private Stack<(int row, int column)> ListToShuffledStack(List<(int row, int column)> list)
        {
            list = list.OrderBy(_ => Guid.NewGuid()).ToList();
            Stack<(int row, int column)> stack = new();
            list.ForEach(c => stack.Push(c));
            return stack;
        }

        private GameCardColour GetRandomColour()
        {
            return _colours[_random.Next(_colours.Length)];
        }

        private GameCardModel BuildGameCard(GameCardColour colour, (int row, int column) coordinate)
        {
            return new GameCardModel
            {
                Colour = colour,
                Row = coordinate.row,
                Column = coordinate.column
            };
        }
    }
}
