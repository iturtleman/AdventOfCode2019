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
	CalculateSum(masses, FuelCostFromMass).Dump();
	// Part 2
	new
	{
		Test12 = FuelCostFromMassIncludingFuelCost(12) == 2,
		Test14 = FuelCostFromMassIncludingFuelCost(14) == 2,
		Test1969 = FuelCostFromMassIncludingFuelCost(1969) == 966,
		Test100756 = FuelCostFromMassIncludingFuelCost(100756) == 50346,
	}.Dump();
	CalculateSum(masses, FuelCostFromMassIncludingFuelCost).Dump();
}

// Define other methods and classes here
int CalculateSum(IEnumerable<int> masses, Func<int,int> fn)
{
	return masses.Select(fn).Sum();
}
int FuelCostFromMass(int mass)
{
	// / operator divides and floors naturally for int values
	return (mass / 3) - 2;
}

int FuelCostFromMassIncludingFuelCost(int mass)
{
	int totalCost = 0;
	int unaccountedForMass = mass;
	int fuelCost;
	do
	{
		fuelCost = FuelCostFromMass(unaccountedForMass);
		if (fuelCost > 0)
			totalCost += fuelCost;
		unaccountedForMass=fuelCost;
	} while (fuelCost > 0);
	return totalCost;
}