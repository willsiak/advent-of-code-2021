using System;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Extensions
    {
        public static TOut Let<TIn, TOut>(this TIn value, Func<TIn, TOut> transform) =>
            transform(value);

        public static int[] AsIntegers(this string[] @this) =>
            @this.Select(it => Convert.ToInt32(it)).ToArray();
    }
}
