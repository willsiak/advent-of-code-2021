using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    internal sealed class Board
    {
        public Board(int[][] numbers)
        {
            Rows = numbers;
        }

        public int[][] Rows { get; }
        private int Width => Rows.First().Length;

        public bool WinsWith(int[] drawnNumbers)
        {
            return HasFullRow(drawnNumbers) || HasFullColumn(drawnNumbers);
        }

        private bool HasFullRow(int[] drawnNumbers) =>
            Rows.Any(row => row.All(drawnNumbers.Contains));

        private bool HasFullColumn(int[] drawnNumbers) =>
            Enumerable.Range(0, Width).Any(colIndex => Column(colIndex).All(drawnNumbers.Contains));

        private int[] Column(int index) =>
            Rows.Select(row => row[index]).ToArray();
    }
}
