using System;
using System.Linq;
using System.Net.Http.Headers;

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

        internal void SolveTask1() => FollowDirectionsFrom(new StaticPosition(0, 0));
        
        internal void SolveTask2() => FollowDirectionsFrom(new DynamicPosition(0, 0, 0));

        private void FollowDirectionsFrom(Position startingPosition)
        {
            var finalPosition = Directions.Aggregate(
                startingPosition,
                (position, nextMovement) => position.Move(nextMovement)
            );
            
            Console.WriteLine("Horizontal position: " + finalPosition.Horizontal);
            Console.WriteLine("Depth: " + finalPosition.Depth);
            Console.WriteLine("---");
        }
    }
}
