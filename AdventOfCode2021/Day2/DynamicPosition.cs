using System;

namespace AdventOfCode2021.Day2
{
    internal sealed class DynamicPosition : Position
    {
        public int Horizontal { get; }
        public int Depth { get; }
        private readonly int _aim;

        public DynamicPosition(int horizontal, int depth, int aim)
        {
            Horizontal = horizontal;
            Depth = depth;
            _aim = aim;
        }

        public Position Move(Movement movement) =>
            movement.Direction switch
            {
                Direction.Forward => MovedForward(movement.Amount),
                Direction.Down => WithUpdatedAim(movement.Amount),
                Direction.Up => WithUpdatedAim(-movement.Amount),
                _ => throw new ArgumentOutOfRangeException(nameof(movement.Direction))
            };

        private DynamicPosition MovedForward(int amount) =>
            new(
                horizontal: Horizontal + amount,
                depth: Depth + _aim * amount,
                aim: _aim
            );

        private DynamicPosition WithUpdatedAim(int amount) =>
            new(
                horizontal: Horizontal,
                depth: Depth,
                aim: _aim + amount
            );
    }
}
