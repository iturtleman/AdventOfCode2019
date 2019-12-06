<Query Kind="Program" />

void Main()
{

	// Part 1
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	var input = File.ReadAllText(@"Puzzle2input.txt").Split(new char[] { ',' }).Select(num => int.Parse(num)).ToArray();
	new
	{
		TestInput = CompareArrays(RunProgram(new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }), new int[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 }),
		TestInput1 = CompareArrays(RunProgram(new int[] { 1, 0, 0, 0, 99 }), new int[] { 2, 0, 0, 0, 99 }),
		TestInput2 = CompareArrays(RunProgram(new int[] { 2, 3, 0, 3, 99 }), new int[] { 2, 3, 0, 6, 99 }),
		TestInput3 = CompareArrays(RunProgram(new int[] { 2, 4, 4, 5, 99, 0 }), new int[] { 2, 4, 4, 5, 99, 9801 }),
		TestInput4 = CompareArrays(RunProgram(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }), new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 }),
	}.Dump();
	input[1] = 12;
	input[2] = 2;
	RunProgram(input).Dump();
	// Part 2

	int expected = 19690720;
	CalculateVerbAndNoun(expected, File.ReadAllText(@"Puzzle2input.txt"));



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
		var opCode = (OpCode)memory[cursorPos];
		if (opCode == OpCode.Exit)
		{
			return memory;
		}
		int first = memory[cursorPos + 1];
		int second = memory[cursorPos + 2];
		int valueIndx = memory[cursorPos + 3];

		if (opCode == OpCode.One)
		{
			memory[valueIndx] = memory[first] + memory[second];
		}
		else if (opCode == OpCode.Two)
		{
			memory[valueIndx] = memory[first] * memory[second];
		}
		else
			throw new Exception($@"Unexpected opCode {opCode}");
		/*
		new
		{
			cursorPos = cursorPos,
			first = first,
			second = second,
			valueIndx = valueIndx,
			val1 = memory[first],
			val2 = memory[second],
			output = memory[valueIndx],
			memory = memory,
		}.Dump();
		//*/
		cursorPos += Oplengths[opCode];
	}
	return memory;
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