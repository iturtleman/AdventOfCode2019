<Query Kind="Program" />

void Main()
{

	// Part 1
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	var input = File.ReadAllText(@"Puzzle2input.txt").Split(new char[] { ',' }).Select(num => int.Parse(num)).ToArray();
	/*
	new
	{
		TestInput = CompareArrays(RunProgram(new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }), new int[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 }),
		TestInput1 = CompareArrays(RunProgram(new int[] { 1, 0, 0, 0, 99 }), new int[] { 2, 0, 0, 0, 99 }),
		TestInput2 = CompareArrays(RunProgram(new int[] { 2, 3, 0, 3, 99 }), new int[] { 2, 3, 0, 6, 99 }),
		TestInput3 = CompareArrays(RunProgram(new int[] { 2, 4, 4, 5, 99, 0 }), new int[] { 2, 4, 4, 5, 99, 9801 }),
		TestInput4 = CompareArrays(RunProgram(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }), new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 }),
		TestInput5 = CompareArrays(RunProgram(new int[] { 1002, 4, 3, 4, 33, 99 }), new int[] { 1002, 4, 3, 4, 99, 99 }),
		TestInput6 = CompareArrays(RunProgram(new int[] { 1101, 100, -1, 4, 0, 99 }), new int[] { 1101, 100, -1, 4, 99, 99 }),
		//put 0 as input
		TestInput7 = CompareArrays(RunProgram(new int[] { 3, 0, 4, 0, 99 }), new int[] { 0, 0, 4, 0, 99 }),

	}.Dump();
	input[1] = 12;
	input[2] = 2;
	RunProgram(input).Dump();
	//*/

	input = File.ReadAllText(@"Puzzle5input.txt").Split(new char[] { ',' }).Select(num => int.Parse(num)).ToArray();
	//put 1 as input
	RunProgram(input).Dump();

	// Part 2

	int expected = 19690720;
	//CalculateVerbAndNoun(expected, File.ReadAllText(@"Puzzle2input.txt"));

}

bool CompareArrays(int[] v1, int[] v2)
{
	for (int i = 0; i < v1.Length; ++i)
	{
		if (v1[i] != v2[i])
		{
			new { i = i, v1 = v1, v2 = v2, }.Dump();
			return false;
		}
	}
	return true;
}

enum OpCode
{
	One = 1,
	Two = 2,
	Three = 3,
	Four = 4,
	Exit = 99,
}

enum ParameterModes
{
	Position = 0,
	Immediate = 1,
}

Dictionary<OpCode, int> Oplengths = new Dictionary<OpCode, int>(){
	{OpCode.One, 4},
	{OpCode.Two, 4},
	{OpCode.Three, 2},
	{OpCode.Four, 2},
	{OpCode.Exit, 1},
};

// Define other methods and classes here
int[] RunProgram(int[] memory)
{
	int cursorPos = 0;
	while (cursorPos < memory.Length)
	{
		/*
ABCDE
 1002

DE - two-digit opcode,      02 == opcode 2
 C - mode of 1st parameter,  0 == position mode
 B - mode of 2nd parameter,  1 == immediate mode
 A - mode of 3rd parameter,  0 == position mode,
                                  omitted due to being a leading zero
		*/
		int FullOpCode = memory[cursorPos];

		//keep last two digits
		var opCode = (OpCode)(FullOpCode % 100);
		var param1Mode = (ParameterModes)(FullOpCode / 100 % 10);
		var param2Mode = (ParameterModes)(FullOpCode / 1000 % 10);
		var param3Mode = (ParameterModes)(FullOpCode / 10000 % 10);

		if (opCode == OpCode.Exit)
		{
			return memory;
		}
		bool hasFirst = cursorPos + 1 < memory.Length;
		int first = hasFirst ? memory[cursorPos + 1] : 0;
		bool hasSecond = cursorPos + 2 < memory.Length;
		int second = hasSecond ? memory[cursorPos + 2] : 0;
		bool hasValueIndx = cursorPos + 3 < memory.Length;
		int valueIndx = hasValueIndx ? memory[cursorPos + 3] : 0;

		var val1 = param1Mode == ParameterModes.Position && hasFirst && first < memory.Length ? memory[first] : first;
		var val2 = param2Mode == ParameterModes.Position && hasSecond && second < memory.Length ? memory[second] : second;

		if (opCode == OpCode.One && hasFirst && hasSecond && hasValueIndx)
		{
			memory[valueIndx] = val1 + val2;
		}
		else if (opCode == OpCode.Two && hasFirst && hasSecond && hasValueIndx)
		{
			memory[valueIndx] = val1 * val2;
		}
		else if (opCode == OpCode.Three && hasFirst)
		{
			int val;
			while (true)
			{
				try
				{
					val = Int32.Parse(Console.ReadLine());
					break;
				}
				catch (Exception)
				{
					//this must be an int but keep trying until it is
				}
			}
			memory[first] = val;
		}
		else if (opCode == OpCode.Four && hasFirst)
		{
			WriteToConsole(param1Mode == ParameterModes.Position?memory[first]:first);
		}
		else
			throw new Exception($@"Unexpected opCode {opCode}");
		/*
		new
		{
			opCode = opCode,
			param1Mode = param1Mode,
			param2Mode = param2Mode,
			param3Mode = param3Mode,
			cursorPos = cursorPos,
			first = first,
			second = second,
			valueIndx = valueIndx,
			val1 = val1,
			val2 = val2,
			memory225 = memory[225],
			memory6 = memory[6],
			memory0 = memory[0],
			memory238 = memory[238],
			memory104 = memory[104],
			memory = memory,
		}.Dump();
		//*/
		cursorPos += Oplengths[opCode];
	}
	return memory;
}

void WriteToConsole(int v)
{
	Console.WriteLine($@"OpOutput:{v}");
}

void CalculateVerbAndNoun(int expected, string fileContents)
{
	int maxNum = 99;
	for (int noun = 0; noun < maxNum; ++noun)
	{
		for (int verb = 0; verb < maxNum; ++verb)
		{
			var input = fileContents.Split(new char[] { ',' }).Select(num => int.Parse(num)).ToArray();

			input[1] = noun;
			input[2] = verb;
			if (RunProgram(input)[0] == expected)
			{

				new { noun = noun, verb = verb, stuff = 100 * noun + verb, }.Dump();
				return;
			}

		}
	}
}