using System;
using System.IO;
using System.Linq;

var ship = new Ship();
var instructions = (await File.ReadAllLinesAsync("data.txt"))
    .Select(line => new Instruction(line));

Console.WriteLine(ship);

foreach (var instruction in instructions)
{
    ship.Apply(instruction);
    Console.WriteLine(ship);
}
