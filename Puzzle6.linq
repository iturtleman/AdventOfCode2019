<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

	// Part 1
	new
	{
		Test1 = GetTotalDirectOrbits($@"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L") == 42,
	}.Dump();


	var input = File.ReadAllText("Puzzle6input.txt");
	GetTotalDirectOrbits(input).Dump();

	// Part 2
	
}

int GetTotalDirectOrbits(string v)
{
	throw new NotImplementedException();
}
