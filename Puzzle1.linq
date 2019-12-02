<Query Kind="Program" />

void Main()
{
	
	// Part 1
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	var masses = File.ReadAllLines(@"Puzzle1input.txt").Select(mass => int.Parse(mass));
	new
	{
		Test12 = FuelCostFromMass(12) == 2,
		Test14 = FuelCostFromMass(14) == 2,
		Test1969 = FuelCostFromMass(1969) == 654,
		Test100756 = FuelCostFromMass(100756) == 33583,
	}.Dump();
	CalculateSum(masses).Dump();
	// Part 2
}

// Define other methods and classes here
int CalculateSum(IEnumerable<int> masses)
{
	return masses.Select(FuelCostFromMass).Sum();
}
int FuelCostFromMass(int mass)
{
	// / operator divides and floors naturally for int values
	return (mass / 3) - 2;
}