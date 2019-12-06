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

	input = File.ReadAllText(@"Puzzle5input.txt").Split(new char[] { ',' }).Select(num => int.Parse(num)).ToArray();
	//put 1 as input
	RunProgram(input).Dump();
	//*/

	// Part 2
	input = File.ReadAllText(@"Puzzle5input.txt").Split(new char[] { ',' }).Select(num => int.Parse(num)).ToArray();
	/*
	new
	{
		//input =8?1:0
		TestInput = HasLastOutput(RunProgram(new int[] { 0, 0, 8, 9, 10, 9, 4, 9, 99, 8, 8 }), 1),
		TestInputf = HasLastOutput(RunProgram(new int[] { 0, 0, 8, 9, 10, 9, 4, 9, 99, -1, 8 }), 0),
		//input <8?1:0
		TestInput1 = HasLastOutput(RunProgram(new int[] { 0, 0, 7, 9, 10, 9, 4, 9, 99, -1, 8 }), 1),
		TestInput1f = HasLastOutput(RunProgram(new int[] { 0, 0, 7, 9, 10, 9, 4, 9, 99, 8, 8 }), 0),
		//input =8?1:0
		TestInput2 = HasLastOutput(RunProgram(new int[] { 0, 0, 1108, 8, 8, 3, 4, 3, 99 }), 1),
		TestInput2f = HasLastOutput(RunProgram(new int[] { 0, 0, 1108, -1, 8, 3, 4, 3, 99 }), 0),
		//input <8?1:0
		TestInput3 = HasLastOutput(RunProgram(new int[] { 0, 0, 1107, 7, 8, 3, 4, 3, 99 }), 1),
		TestInput3f1 = HasLastOutput(RunProgram(new int[] { 0, 0, 1107, 9, 8, 3, 4, 3, 99 }), 0),
		//input =0?0:1
		TestInput4 = HasLastOutput(RunProgram(new int[] { 0, 0, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, 0, 0, 1, 9 }), 0),
		TestInput4f = HasLastOutput(RunProgram(new int[] { 0, 0, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }), 1),
		//input =0?0:1
		TestInput5 = HasLastOutput(RunProgram(new int[] { 0, 0, 1105, 0, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }), 0),
		TestInput5f = HasLastOutput(RunProgram(new int[] { 0, 0, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }), 1),
		//put <8?999 =8?1000 >8? 1001
		TestInput7l = HasLastOutput(RunProgram(new int[] { 0,0,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
1106,0,36,98,0,7,1002,21,125,20,4,20,1105,1,46,104,
999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }), 999),
		TestInput7e = HasLastOutput(RunProgram(new int[] { 0,0,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
1106,0,36,98,0,8,1002,21,125,20,4,20,1105,1,46,104,
999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }), 1000),
		TestInput7g = HasLastOutput(RunProgram(new int[] { 0,0,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
1106,0,36,98,0,9,1002,21,125,20,4,20,1105,1,46,104,
999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }), 1001),

	}.Dump();//*/
	//put 5 as input
	RunProgram(input).Dump();

}

bool HasLastOutput(int[] v1, int lastOutput)
{
	return FinalOutput == lastOutput;
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
	Zero = 0,
	One = 1,
	Two = 2,
	Three = 3,
	Four = 4,
	Five = 5,
	Six = 6,
	Seven = 7,
	Eight = 8,
	Exit = 99,
}

enum ParameterModes
{
	Position = 0,
	Immediate = 1,
}

Dictionary<OpCode, int> Oplengths = new Dictionary<OpCode, int>(){
	{OpCode.Zero, 1},
	{OpCode.One, 4},
	{OpCode.Two, 4},
	{OpCode.Three, 2},
	{OpCode.Four, 2},
	{OpCode.Five, 3},
	{OpCode.Six, 3},
	{OpCode.Seven, 4},
	{OpCode.Eight, 4},
	{OpCode.Exit, 1},
};

// Define other methods and classes here
int[] RunProgram(int[] memory)
{
	int cursorPos = 0;
	while (cursorPos < memory.Length)
	{
		var preCursorPos=cursorPos;
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
		bool hasValueIndx = cursorPos + 3 < memory.Length && memory[cursorPos + 3] < memory.Length;
		int valueIndx = hasValueIndx ? memory[cursorPos + 3] : 0;

		var val1 = param1Mode == ParameterModes.Position && hasFirst && first < memory.Length && first > 0 ? memory[first] : first;
		var val2 = param2Mode == ParameterModes.Position && hasSecond && second < memory.Length && second > 0 ? memory[second] : second;
		var instructionModified = false;
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
			WriteToConsole(param1Mode == ParameterModes.Position ? memory[first] : first);
		}
		else if (opCode == OpCode.Five && hasFirst && hasSecond)
		{
			if (val1 != 0)
			{
				cursorPos = val2;
				instructionModified = true;
			}
		}
		else if (opCode == OpCode.Six && hasFirst && hasSecond)
		{
			if (val1 == 0)
			{
				cursorPos = val2;
				instructionModified = true;
			}
		}
		else if (opCode == OpCode.Seven && hasFirst && hasSecond && hasValueIndx)
		{
			memory[valueIndx] = val1 < val2 ? 1 : 0;
		}
		else if (opCode == OpCode.Eight && hasFirst && hasSecond && hasValueIndx)
		{
			memory[valueIndx] = val1 == val2 ? 1 : 0;
		}
		else if (opCode == OpCode.Zero)
		{ }
		else
			throw new Exception($@"Unexpected opCode {opCode}");
		//*
		new
		{
			opCode = opCode,
			param1Mode = param1Mode,
			param2Mode = param2Mode,
			param3Mode = param3Mode,
			cursorPos = cursorPos,
			preCursorPos = preCursorPos,
			OpSkip=Oplengths[opCode],
			first = first,
			second = second,
			valueIndx = valueIndx,
			val1 = val1,
			val2 = val2,
			memoryValueIndx = hasValueIndx ? memory[valueIndx].ToString() : "nope",
			memorycursorPos = cursorPos <memory.Length?memory[cursorPos].ToString():$"Op code is {opCode}",
			memory225 = memory[225],
			memory6 = memory[6],
			memory0 = memory[0],
			memory238 = memory[238],
			memory104 = memory[104],
			memory = memory,
		}.Dump();
		//*/
		if (!instructionModified)
			cursorPos += Oplengths[opCode];
	}
	return memory;
}

int FinalOutput = 0;
void WriteToConsole(int v)
{
	FinalOutput = v;
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