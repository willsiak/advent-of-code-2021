using System;

namespace AdventOfCode2021.Day2
{
    internal sealed class Position
    {
        public int Horizontal { get; }
        public int Depth { get; }

        public Position(int horizontal, int depth)
        {
            Horizontal = horizontal;
            Depth = depth;
        }

        public Position Move(Movement movement) =>
            movement.Direction switch
            {
                Direction.Forward => new Position(Horizontal + movement.Amount, Depth),
                Direction.Down => new Position(Horizontal, Depth + movement.Amount),
                Direction.Up => new Position(Horizontal, Depth - movement.Amount),
                _ => throw new ArgumentOutOfRangeException("Could not understand directions")
            };
    }
}
