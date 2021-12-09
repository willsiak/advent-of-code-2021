namespace AdventOfCode2021.Day2
{
    internal interface Position
    {
        int Horizontal { get; }
        int Depth { get; }
        Position Move(Movement movement);
    }
}
