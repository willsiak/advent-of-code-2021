using System;
using System.IO;

namespace AdventOfCode2021
{
    internal sealed class LinesInFile
    {
        private readonly Lazy<string[]> _lazyLines;
        public string[] Lines => _lazyLines.Value;

        public LinesInFile(string path)
        {
            _lazyLines = new(() => File.ReadAllLines(path));
        }
    }
}
