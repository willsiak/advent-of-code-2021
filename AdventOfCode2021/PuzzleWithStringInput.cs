using System;

namespace AdventOfCode2021
{
    internal abstract class PuzzleWithStringInput
    {
        private readonly LinesInFile _linesInFile;
        protected string[] Lines => _linesInFile.Lines;

        protected PuzzleWithStringInput(string inputPath)
        {
            _linesInFile = new LinesInFile(inputPath);
        }
    }
}
