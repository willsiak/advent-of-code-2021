using System;
using System.Linq;

namespace AdventOfCode2021.Day1
{
    internal class Puzzle1 : PuzzleWithFileInput
    {
        public Puzzle1(string inputPath) : base(inputPath) { }

        private int[] Depths => Lines.AsIntegers();

        internal void SolveTask1() =>
            IncreasesIn(DepthChanges.ByComparingWindows(Depths, windowSize: 1));

        internal void SolveTask2() =>
            IncreasesIn(DepthChanges.ByComparingWindows(Depths, windowSize: 3));

        private void IncreasesIn(DepthChange[] depthChanges)
        {
            var increases = depthChanges.Where(it => it == DepthChange.Increased);
            Console.WriteLine("Total number of increases: " + increases.Count());
        }
    }
}
