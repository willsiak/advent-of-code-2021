using System.Linq;

namespace AdventOfCode2021.Day1
{
    internal static class DepthChanges
    {
        public static DepthChange[] ByComparingWindows(int[] depths, int windowSize = 1) =>
            Enumerable.Range(0, depths.Length - windowSize)
                .Select(
                    index => CompareDepths(
                        currentDepth: depths.Window(index, windowSize).Sum(),
                        nextDepth: depths.Window(index + 1, windowSize).Sum()
                    )
                ).ToArray();

        private static DepthChange CompareDepths(int currentDepth, int nextDepth) =>
            currentDepth < nextDepth
                ? DepthChange.Increased
                : currentDepth > nextDepth
                    ? DepthChange.Decreased
                    : DepthChange.Unchanged;
    }

    internal enum DepthChange
    {
        Decreased = -1,
        Unchanged = 0,
        Increased = 1
    }

    internal static class Extensions
    {
        internal static int[] Window(this int[] depths, int startingIndex, int windowSize) =>
            Enumerable.Range(startingIndex, windowSize)
                .Select(it => depths[it])
                .ToArray();
    }
}
