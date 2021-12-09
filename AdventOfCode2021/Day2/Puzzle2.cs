using System;
using System.Linq;

namespace AdventOfCode2021.Day2
{
    internal class Puzzle2
    {
        private readonly Lazy<Movement[]> _lazyDirections;
        private Movement[] Directions => _lazyDirections.Value;

        public Puzzle2(string inputPath)
        {
            _lazyDirections = new(
                () => new LinesInFile(inputPath).Lines
                    .Select(it => new Movement(it)).ToArray()
            );
        }

        internal void SolveTask1()
        {
            var finalPosition = Directions.Aggregate(
                new Position(0, 0),
                (position, nextMovement) => position.Move(nextMovement)
            );

            Console.WriteLine("Horizontal position: " + finalPosition.Horizontal);
            Console.WriteLine("Depth: " + finalPosition.Depth);
        }
    }
}
