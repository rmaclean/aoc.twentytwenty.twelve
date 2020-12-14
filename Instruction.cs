using System;
using System.Text.RegularExpressions;

public record Instruction
{
    public int Steps { get; init; }

    public Directions Direction { get; init; }

    private static Regex parser = new Regex("(?<direction>F|R|N|S|E|W|L)(?<steps>\\d+)");

    public Instruction() {}

    public Instruction(string line)
    {
        var matches = parser.Matches(line);
        switch (matches[0].Groups["direction"].Value)
        {
            case "F":
                {
                    Direction = Directions.Forward;
                    break;
                }
            case "L":
                {
                    Direction = Directions.Left;
                    break;
                }
            case "R":
                {
                    Direction = Directions.Right;
                    break;
                }
            case "N":
                {
                    Direction = Directions.North;
                    break;
                }
            case "S":
                {
                    Direction = Directions.South;
                    break;
                }
            case "E":
                {
                    Direction = Directions.East;
                    break;
                }
            case "W":
                {
                    Direction = Directions.West;
                    break;
                }
        }

        Steps = Convert.ToInt32(matches[0].Groups["steps"].Value);
    }
}

public enum Directions
{
    North,
    South,
    East,
    West,
    Right,
    Left,
    Forward,
}