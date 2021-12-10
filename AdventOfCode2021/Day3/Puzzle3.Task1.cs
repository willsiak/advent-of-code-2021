using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day3
{
    internal sealed partial class Puzzle3 : PuzzleWithFileInput
    {
        public Puzzle3(string inputPath) : base(inputPath) { }

        public void SolveTask1()
        {
            var mostCommonCharsByPosition = Values(Lines)
                .GroupBy(it => it.Position)
                .Select(MostToLeastCommonCharsIn)
                .ToArray();

            var gammaRate = CharArrayToIntBinary(
                mostCommonCharsByPosition.Select(commonChars => commonChars.First().character).ToArray()
            );
            var epsilonRate = CharArrayToIntBinary(
                mostCommonCharsByPosition.Select(commonChars => commonChars.Last().character).ToArray()
            );

            Console.WriteLine("Gamma Rate: " + gammaRate);
            Console.WriteLine("Epsilon Rate: " + epsilonRate);
            Console.WriteLine("---");
        }

        private IEnumerable<ValueAtPosition> Values(string[] lines) =>
            Enumerable.Range(0, lines.First().Length)
                .SelectMany(
                    position => lines.Select(line => new ValueAtPosition(position, line[position]))
                );

        private IEnumerable<(char character, int count)> MostToLeastCommonCharsIn(IEnumerable<ValueAtPosition> group) =>
            MostToLeastCommonCharsIn(group.Select(it => it.Value));

        private IEnumerable<(char character, int count)> MostToLeastCommonCharsIn(IEnumerable<char> group) =>
            group.GroupBy(it => it)
                .OrderByDescending(it => it.Count())
                .Select(it => (it.Key, it.Count()));

        private int CharArrayToIntBinary(IEnumerable<char> binaryNumber) =>
            Convert.ToInt32(new string(binaryNumber.ToArray()), 2);
    }
}
