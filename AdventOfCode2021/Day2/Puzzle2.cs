using System;
using System.Linq;
using System.Net.Http.Headers;

namespace AdventOfCode2021.Day2
{
    internal class Puzzle2 : PuzzleWithFileInput
    {
        public Puzzle2(string inputPath) : base(inputPath) { }

        private Movement[] Movements => Lines.Select(it => new Movement(it)).ToArray();

        internal void SolveTask1() => FollowDirectionsFrom(new StaticPosition(0, 0));
        
        internal void SolveTask2() => FollowDirectionsFrom(new DynamicPosition(0, 0, 0));

        private void FollowDirectionsFrom(Position startingPosition)
        {
            var finalPosition = Movements.Aggregate(
                startingPosition,
                (position, nextMovement) => position.Move(nextMovement)
            );
            
            Console.WriteLine("Horizontal position: " + finalPosition.Horizontal);
            Console.WriteLine("Depth: " + finalPosition.Depth);
            Console.WriteLine("---");
        }
    }
}
