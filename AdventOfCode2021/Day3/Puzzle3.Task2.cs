using System;
using System.Linq;

namespace AdventOfCode2021.Day3
{
    internal sealed partial class Puzzle3
    {
        public void SolveTask2()
        {
            var oxygenRating = FilterLinesAtIndex(Lines, 0, ByMostCommonCharacterOr1).Single();
            Console.WriteLine("O2 rating (binary) is: " + oxygenRating);
            Console.WriteLine("O2 rating is: " + Convert.ToInt32(oxygenRating, 2));

            var co2Rating = FilterLinesAtIndex(Lines, 0, ByLeastCommonCharacterOr0).Single();
            Console.WriteLine("CO2 rating (binary) is: " + co2Rating);
            Console.WriteLine("CO2 rating is: " + Convert.ToInt32(co2Rating, 2));
        }

        private string[] FilterLinesAtIndex(
            string[] lines,
            int index,
            Func<(char character, int count)[], char> filterByChar)
        {
            var filterChar = filterByChar(MostToLeastCommonCharsIn(lines.Select(it => it[index])).ToArray());
            var filteredLines = lines.Where(it => it[index] == filterChar).ToArray();
            return filteredLines.Length > 1
                ? FilterLinesAtIndex(filteredLines, index + 1, filterByChar)
                : filteredLines;
        }

        private static char ByMostCommonCharacterOr1((char character, int count)[] commonChars) =>
            commonChars[0].count != commonChars[1].count
                ? commonChars[0].character
                : '1';

        private static char ByLeastCommonCharacterOr0((char character, int count)[] commonChars) =>
            commonChars[^1].count != commonChars[^2].count
                ? commonChars[^1].character
                : '0';
    }
}
