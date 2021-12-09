using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCode2021.Day3
{
    internal sealed class Puzzle3 : PuzzleWithStringInput
    {
        public Puzzle3(string inputPath) : base(inputPath) { }

        private IEnumerable<ValueAtPosition> Values() =>
            Enumerable.Range(0, Lines.First().Length)
                .SelectMany(
                    position => Lines.Select(line => new ValueAtPosition(position, line[position]))
                );

        public void SolveTask1()
        {
            var rates = Values()
                .GroupBy(it => it.Position)
                .Select(MostAndLeastCommonCharIn)
                .ToArray();

            var gammaRate = Convert.ToInt32(new string(rates.Select(it => it.mostCommon).ToArray()), 2);
            var epsilonRate = Convert.ToInt32(new string(rates.Select(it => it.leastCommon).ToArray()), 2);
            
            Console.WriteLine("Gamma Rate: " + gammaRate);
            Console.WriteLine("Epsilon Rate: " + epsilonRate);
        }

        private (char mostCommon, char leastCommon) MostAndLeastCommonCharIn(IGrouping<int, ValueAtPosition> group) =>
            group.GroupBy(it => it.Value)
                .OrderByDescending(it => it.Count())
                .ToArray()
                .Let(it => (it.First().Key, it.Last().Key));
    }
}
