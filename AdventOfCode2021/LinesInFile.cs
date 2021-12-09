using System;
using System.IO;
using System.Linq;

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

        public int[] AsIntegers() =>
            Lines.Select(it => Convert.ToInt32(it))
                .ToArray();
    }
}
