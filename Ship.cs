using System;

public class Ship
{
    public Directions Direction { get; set; } = Directions.East;
    public int XPosition { get; set; } = 0;
    public int YPosition { get; set; } = 0;

    private Directions[] Orientations = new [] { Directions.East, Directions.North, Directions.West, Directions.South };

    public override string ToString() => $"Ship facing {Direction} at {XPosition} by {YPosition} "+
        $"({Math.Abs(XPosition) + Math.Abs(YPosition)})";

    public void Apply(Instruction instruction)
    {
        switch (instruction.Direction)
        {
            case Directions.East:
            {
                XPosition += instruction.Steps;
                break;
            }
            case Directions.West:
            {
                XPosition -= instruction.Steps;
                break;
            }
            case Directions.North:
            {
                YPosition += instruction.Steps;
                break;
            }
            case Directions.South:
            {
                YPosition -= instruction.Steps;
                break;
            }
            case Directions.Forward:
            {
                Apply(new Instruction { Direction = Direction, Steps = instruction.Steps });
                break;
            }
            case Directions.Left:
            {
                var changesNeeded = instruction.Steps / 90;
                var currentIndex = Array.IndexOf(Orientations, Direction);
                var stepsNeeded = changesNeeded + currentIndex;
                if (stepsNeeded >= 4)
                {
                    stepsNeeded -= 4;
                }

                Direction = Orientations[stepsNeeded];
                break;
            }
            case Directions.Right:
            {
                var changesNeeded = instruction.Steps / 90;
                var currentIndex = Array.IndexOf(Orientations, Direction);
                var stepsNeeded = currentIndex - changesNeeded;
                if (stepsNeeded < 0)
                {
                    stepsNeeded += 4;
                }

                Direction = Orientations[stepsNeeded];
                break;
            }
        }
    }
}
