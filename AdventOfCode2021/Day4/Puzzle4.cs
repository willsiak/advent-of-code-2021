using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    internal sealed class Puzzle4 : PuzzleWithFileInput
    {
        private readonly Lazy<List<int>> _lazyNumbers;
        private List<int> Numbers => _lazyNumbers.Value;

        public Puzzle4(string boardsPath, string numbersPath) : base(boardsPath)
        {
            _lazyNumbers = new(() => new LinesInFile(numbersPath).Lines.AsIntegers().ToList());
        }

        public void SolveTask1()
        {
            var boards = CreateBoardsFrom(Lines);
            for (int i = 1; i <= Numbers.Count; i++)
            {
                var currentNumbers = Numbers.ToList().GetRange(0, i);
                var winningBoards = boards
                    .Where(it => it.WinsWith(currentNumbers.ToArray()))
                    .ToArray();
                if (!winningBoards.Any()) continue;

                OutputBoard(winningBoards.Single(), currentNumbers);
                break;
            }
        }

        private List<Board> CreateBoardsFrom(string[] input)
        {
            var boards = new List<Board>();
            var currentInput = new List<string>();
            foreach (var line in input)
            {
                if (line.Length == 0)
                {
                    boards.Add(CreateBoardFrom(currentInput));
                    currentInput = new List<string>();
                    continue;
                }

                currentInput.Add(line);
            }

            return boards;
        }

        private Board CreateBoardFrom(IEnumerable<string> fromString) =>
            new(
                fromString.Select(
                    it => it.Split(" ")
                        .Where(number => number.Trim().Any())
                        .ToArray().AsIntegers()
                ).ToArray()
            );

        private void OutputBoard(Board board, List<int> drawnNumbers)
        {
            Console.WriteLine("Numbers drawn: " + string.Join(", ", drawnNumbers));
            Console.WriteLine("Winning board: ");
            foreach (var row in board.Rows)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            var unmarkedNumbers = board.Rows.SelectMany(row => row).Where(it => !drawnNumbers.Contains(it)).ToArray();
            Console.WriteLine("Unmarked numbers: " + string.Join(", ", unmarkedNumbers));
            Console.WriteLine("Sum of unmarked numbers: " + unmarkedNumbers.Sum());
        }
    }
}
