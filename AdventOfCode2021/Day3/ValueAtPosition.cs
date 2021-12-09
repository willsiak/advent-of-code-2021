namespace AdventOfCode2021.Day3
{
    internal sealed class ValueAtPosition
    {
        public ValueAtPosition(int position, char value)
        {
            Position = position;
            Value = value;
        }

        public int Position { get; }
        public char Value { get; }
    }
}
