using System;

namespace AdventOfCode2021
{
    public static class Extensions
    {
        public static TOut Let<TIn, TOut>(this TIn value, Func<TIn, TOut> transform) =>
            transform(value);
    }
}
