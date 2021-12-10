using System;

namespace AdventOfCode2021
{
    internal abstract class PuzzleWithFileInput
    {
        private readonly LinesInFile _linesInFile;
        protected string[] Lines => _linesInFile.Lines;

        protected PuzzleWithFileInput(string inputPath)
        {
            _linesInFile = new LinesInFile(inputPath);
        }
    }
}
