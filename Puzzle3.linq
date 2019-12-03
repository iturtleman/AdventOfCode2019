<Query Kind="Program" />

void Main()
{

	// Part 1
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	var input = File.ReadAllLines(@"Puzzle3input.txt").ToList();
	new
	{
		TestInput = GetClosestIntersection(new List<string>() { @"R8,U5,L5,D3", "U7,R6,D4,L4" }).ManhatanDistance == 6,
		TestInput1 = GetClosestIntersection(new List<string>() { @"R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83" }).ManhatanDistance == 159,
		TestInput2 = GetClosestIntersection(new List<string>() { @"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" }).ManhatanDistance == 135,
	}.Dump();
	GetClosestIntersection(input).ManhatanDistance.Dump();
	// Part 2
	new
	{
		TestInput = GetLeastLatentIntersection(new List<string>() { @"R8,U5,L5,D3", "U7,R6,D4,L4" }).FirstReachedBySteps == 30,
		TestInput1 = GetLeastLatentIntersection(new List<string>() { @"R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83" }).FirstReachedBySteps == 610,
		TestInput2 = GetLeastLatentIntersection(new List<string>() { @"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" }).FirstReachedBySteps == 410,
	}.Dump();
	GetLeastLatentIntersection(input).ManhatanDistance.Dump();
}


WireIntersect GetClosestIntersection(List<string> wires)
{
	var intersections = GetAllIntersections(wires);
	var min = intersections.Dump().Min(i => i.ManhatanDistance);
	return intersections.Single(i => i.ManhatanDistance == min);
}

WireIntersect GetLeastLatentIntersection(List<string> wires)
{
	var intersections = GetAllIntersections(wires);
	var min = intersections.Dump().Min(i => i.FirstReachedBySteps);
	return intersections.Single(i => i.FirstReachedBySteps == min);
}

private List<WireIntersect> GetAllIntersections(List<string> wires)
{
	var wire1 = ReadWireDirections(wires[0]);
	var wire2 = ReadWireDirections(wires[1]);

	//x by y lists
	var intersectionPoints = new Dictionary<int, Dictionary<int, WireIntersect>>();
	var max1 = AddWireTrack(intersectionPoints, wire1, WireNumber.Wire1);
	var max2 = AddWireTrack(intersectionPoints, wire2, WireNumber.Wire2);

	return intersectionPoints.SelectMany(kvp => kvp.Value.Select(v => v.Value)).Where(v => (int)v.WireNum == 3).ToList();
}

public class Point2D
{
	public int X;
	public int Y;
}
private Point2D AddWireTrack(Dictionary<int, Dictionary<int, WireIntersect>> intersectionPoints, Wire wire, WireNumber wireNum)
{
	int x = 0, y = 0, totalSteps = 0;
	foreach (var w in wire.Moves)
	{
		int remaining = w.Amount;
		while (remaining-- > 0)
		{
			totalSteps++;
			switch (w.Direction)
			{
				case Direction.DOWN:
					y--;
					break;
				case Direction.UP:
					y++;
					break;
				case Direction.LEFT:
					x--;
					break;
				case Direction.RIGHT:
					x++;
					break;

			}

			if (!intersectionPoints.ContainsKey(x))
				intersectionPoints[x] = new Dictionary<int, WireIntersect>();
			if (!intersectionPoints[x].ContainsKey(y))
				intersectionPoints[x][y] = new WireIntersect()
				{
					X = x,
					Y = y,
					FirstReachedBySteps = totalSteps,
					FirstReachedBy = wireNum,
				};
			var val = intersectionPoints[x][y];
			if (val.FirstReachedBy != wireNum && val.SecondReachedBy == WireNumber.None)
			{
				val.SecondReachedBy = wireNum;
				//because we only get here the first time and we are going through the wire sequentially this is the path of least resistance
				val.FirstReachedBySteps += totalSteps;
			}
			val.WireNum |= wireNum;
		}
	}
	return new Point2D()
	{
		X = x,
		Y = y
	};
}
class WireIntersect
{
	public WireNumber WireNum = WireNumber.None;
	public int X;
	public int Y;
	public WireNumber FirstReachedBy;
	public WireNumber SecondReachedBy;
	public int FirstReachedBySteps;
	public int ManhatanDistance { get { return Math.Abs(X) + Math.Abs(Y); } }
}
[Flags]
enum WireNumber
{
	None = 0,
	Wire1 = 1,
	Wire2 = 2,
}
Regex DirectionParser = new Regex(@"(?<Direction>[UDLR])(?<Amount>\d+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
Wire ReadWireDirections(string directions)
{
	var retval = new Wire();
	foreach (var dir in directions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
	{
		var val = DirectionParser.Match(dir);
		retval.Moves.Add(new Movement()
		{
			Direction = StringToDirection(val.Groups["Direction"].Value),
			Amount = Int32.Parse(val.Groups["Amount"].Value)
		});
	}
	return retval;
}

private Direction StringToDirection(string value)
{
	if (value == "U")
		return Direction.UP;
	if (value == "D")
		return Direction.DOWN;
	if (value == "L")
		return Direction.LEFT;
	if (value == "R")
		return Direction.RIGHT;
	throw new Exception($@"Shit {value} is not a valid direction");
}

class Wire
{
	public List<Movement> Moves = new List<Movement>();
}
class Movement
{
	public Direction Direction;
	public int Amount;
}

enum Direction
{
	UP,
	DOWN,
	LEFT,
	RIGHT,
}