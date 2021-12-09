using System;

namespace AdventOfCode2021.Day2
{
    internal sealed class StaticPosition : Position
    {
        public int Horizontal { get; }
        public int Depth { get; }

        public StaticPosition(int horizontal, int depth)
        {
            Horizontal = horizontal;
            Depth = depth;
        }

        public Position Move(Movement movement) =>
            movement.Direction switch
            {
                Direction.Forward => new StaticPosition(Horizontal + movement.Amount, Depth),
                Direction.Down => new StaticPosition(Horizontal, Depth + movement.Amount),
                Direction.Up => new StaticPosition(Horizontal, Depth - movement.Amount),
                _ => throw new ArgumentOutOfRangeException(nameof(movement.Direction))
            };
    }
}
