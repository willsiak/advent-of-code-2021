using System;
using System.Linq;

namespace AdventOfCode2021.Day1
{
    internal class Puzzle1
    {
        private readonly Lazy<int[]> _lazyDepths;
        private int[] Depths => _lazyDepths.Value;

        public Puzzle1(string inputPath)
        {
            _lazyDepths = new(() => new LinesInFile(inputPath).AsIntegers());
        }

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
