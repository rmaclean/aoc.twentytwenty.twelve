using System;

public class Ship
{
    public int ShipXPosition { get; set; } = 0;
    public int ShipYPosition { get; set; } = 0;
    public int WaypointRelativeXPosition { get; set; } = 10;
    public int WaypointRelativeYPosition { get; set; } = 1;

    public override string ToString() => $"Ship is at {ShipXPosition} by {ShipYPosition} " +
        $"({Math.Abs(ShipXPosition) + Math.Abs(ShipYPosition)})";

    public void Apply(Instruction instruction)
    {
        switch (instruction.Direction)
        {
            case Directions.East:
                {
                    WaypointRelativeXPosition += instruction.Steps;
                    break;
                }
            case Directions.West:
                {
                    WaypointRelativeXPosition -= instruction.Steps;
                    break;
                }
            case Directions.North:
                {
                    WaypointRelativeYPosition += instruction.Steps;
                    break;
                }
            case Directions.South:
                {
                    WaypointRelativeYPosition -= instruction.Steps;
                    break;
                }
            case Directions.Forward:
                {
                    ShipXPosition += WaypointRelativeXPosition * instruction.Steps;
                    ShipYPosition += WaypointRelativeYPosition * instruction.Steps;
                    break;
                }
            case Directions.Left:
                {
                    var rad = instruction.Steps.Radians();
                    var newX = Convert.ToInt32(WaypointRelativeXPosition * Math.Cos(rad)) - Convert.ToInt32(WaypointRelativeYPosition * Math.Sin(rad));
                    var newY = Convert.ToInt32(WaypointRelativeXPosition * Math.Sin(rad)) + Convert.ToInt32(WaypointRelativeYPosition * Math.Cos(rad));
                    WaypointRelativeXPosition = newX;
                    WaypointRelativeYPosition = newY;
                    break;
                }
            case Directions.Right:
                {
                    var rad = (instruction.Steps * -1).Radians();
                    var newX = Convert.ToInt32(WaypointRelativeXPosition * Math.Cos(rad)) - Convert.ToInt32(WaypointRelativeYPosition * Math.Sin(rad));
                    var newY = Convert.ToInt32(WaypointRelativeXPosition * Math.Sin(rad)) + Convert.ToInt32(WaypointRelativeYPosition * Math.Cos(rad));
                    WaypointRelativeXPosition = newX;
                    WaypointRelativeYPosition = newY;
                    break;
                }
        }
    }
}

public static class Extensions
{
    public static double Radians(this int angle) => (Math.PI / 180) * angle;
}
