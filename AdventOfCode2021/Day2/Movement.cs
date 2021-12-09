using System;

namespace AdventOfCode2021.Day2
{
    internal sealed class Movement
    {
        public Movement(string fromString)
        {
            _lazyValue = new(
                () => fromString
                    .Let(FromString)
            );
        }

        private static (Direction, int) FromString(string fromString) =>
            fromString.Split(" ")
                .Let(
                    it => (
                        Enum.Parse<Direction>(it[0], true),
                        Convert.ToInt32(it[1])
                    )
                );

        private readonly Lazy<(Direction, int)> _lazyValue;
        private (Direction, int) Value => _lazyValue.Value;
        public Direction Direction => Value.Item1;
        public int Amount => Value.Item2;
    }

    internal enum Direction
    {
        Forward = 0,
        Down = 1,
        Up = 2
    }
}
