<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

	// Part 1
	new
	{
		Test1 = IsValidPassword(122345) == true,
		Test2 = IsValidPassword(111123) == true,
		Test3 = IsValidPassword(135679) == false,//because double digits
		Test4 = IsValidPassword(111111) == true,
		Test5 = IsValidPassword(223450) == false,
		Test6 = IsValidPassword(123789) == false,
	}.Dump();


	var input = File.ReadAllText("Puzzle4input.txt").Split('-').Select(r => int.Parse(r)).ToList();
	NumValidPasswordsInRange(input[0], input[1]).Dump();

	// Part 2
	new
	{
		Test1 = IsValidPasswordV2(122345) == true,
		Test2 = IsValidPasswordV2(111123) == false,
		Test3 = IsValidPasswordV2(135679) == false,//because double digits
		Test4 = IsValidPasswordV2(111111) == false,
		Test5 = IsValidPasswordV2(223450) == false,
		Test6 = IsValidPasswordV2(123789) == false,
		Test7 = IsValidPasswordV2(112233) == true,
		Test9 = IsValidPasswordV2(123444) == false,
		Test10 = IsValidPasswordV2(111122) == true,
		Test11 = IsValidPasswordV2(123455) == true,
	}.Dump();
	NumValidPasswordsInRangeV2(input[0], input[1]).Dump();
}

int NumValidPasswordsInRange(int low, int high)
{
	return Enumerable.Range(low, high - low)
		.Where(IsValidPassword)
		.Count();
}
int NumValidPasswordsInRangeV2(int low, int high)
{
	return Enumerable.Range(low, high - low)
		.Where(IsValidPasswordV2).Dump()
		.Count();
}

bool IsValidPasswordV2(int arg)
{
	return IsValidPassword(arg) && HasOnlyTwoSequentialDigits(arg);
}

bool IsValidPassword(int password)
{
	var digits = password.ToString("D6").Select(c => int.Parse(c.ToString())).ToArray();
	var retval = digits.Length <= 6;
	var hasDouble = false;
	if (retval)
		for (int i = 0; i < digits.Length; i++)
		{
			//must increase
			if (i > 0 && digits[i - 1] > digits[i])
				return false;
			//must have double
			if (i > 0 && digits[i - 1] == digits[i])
			{
				hasDouble = true;
			}
		}
	return retval && hasDouble;
}

Regex MultiDigitRegex = new Regex(@"(\d)\1+", RegexOptions.Compiled);
bool HasOnlyTwoSequentialDigits(int password)
{
	return (MultiDigitRegex.Matches(password.ToString("D6")) as MatchCollection)
		.Cast<Match>()
		.Where(match => match.Value.Length == 2)
		.Count() > 0;
}