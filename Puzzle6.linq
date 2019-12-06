<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

	// Part 1
	new
	{
		Test1 = GetTotalDirectOrbits(ReadInput($@"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L".Split('\n'))) == 42,
	}.Dump();


	var input = File.ReadAllLines("Puzzle6input.txt");
	var nodes = ReadInput(input);
	GetTotalDirectOrbits(nodes).Dump();

	// Part 2
	new
	{
		Test1 = GetOrbitalTransfersToSanta(ReadInput($@"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN".Split('\n'))) == 4,
	}.Dump();
	GetOrbitalTransfersToSanta(nodes).Dump();

}


int GetTotalDirectOrbits(Dictionary<string, Node> nodes)
{
	var COM = nodes["COM"];
	var all = new List<Node>() { COM }.SelectMany(FlattenList);
	return all.Select(n => n.GetTotalDirectAndInderectOrbits).Sum();
}

int GetOrbitalTransfersToSanta(Dictionary<string, Node> nodes)
{
	var target = nodes["SAN"];
	var start = nodes["YOU"];
	Queue<Node> frontier = new Queue<Node>();
	HashSet<Node> visited = new HashSet<Node>() { start };
	// we aren't a planet so exclude us
	start.TransfersSoFar=-1;
	AddSurrounding(start, frontier, visited);
	while (frontier.Count > 0)
	{
		var n = frontier.Dequeue();
		visited.Add(n);
		/*
		new
		{
			n = n,
			//visited = visited,
			//frontier = frontier,
		}.Dump();//*/
		if (n == target)
			// santa isn't a planet so exclude him
			return n.TransfersSoFar - 1;
		AddSurrounding(n, frontier, visited);
	}
	return -1;
}

void AddSurrounding(Node curr, Queue<Node> frontier, HashSet<Node> visited)
{
	var transfers = curr.TransfersSoFar + 1;
	AddToFrontier(curr.Parent, frontier, visited, transfers);
	foreach (var n in curr.Children)
	{
		AddToFrontier(n, frontier, visited, transfers);
	}
}

void AddToFrontier(Node n, Queue<Node> frontier, HashSet<Node> visited, int transfers)
{
	if (n != null && !visited.Contains(n))
	{
		n.TransfersSoFar += transfers;
		frontier.Enqueue(n);
	}
}

List<Node> FlattenList(Node n)
{
	var retval = new List<Node>() { n };
	retval.AddRange(n.Children.SelectMany(FlattenList));
	return retval;
}

private Dictionary<string, Node> ReadInput(string[] input)
{
	Dictionary<string, Node> nodes = new Dictionary<string, Node>();
	foreach (var s in input)
	{
		var splitty = s.Trim().Split(')');
		var orbiting = splitty[0];
		var orbiter = splitty[1];
		var Other = GetOrCreateNode(nodes, orbiting);
		var mass = nodes[orbiting];
		var child = GetOrCreateNode(nodes, orbiter);
		mass.Children.Add(child);
		child.Parent = mass;
	}
	return nodes;
}

Node GetOrCreateNode(Dictionary<string, Node> nodes, string mass)
{
	if (!nodes.TryGetValue(mass, out var retval))
	{
		nodes[mass] = retval = new Node()
		{
			Name = mass,
		};
	}
	return retval;
}

class Node
{
	public String Name;
	public Node Parent = null;
	public List<Node> Children = new List<Node>();
	public int GetTotalDirectAndInderectOrbits
	{
		get
		{
			var n = this;
			int i = 0;
			while (n.Parent != null)
			{
				n = n.Parent;
				++i;
			}
			return i;
		}
	}
	public int TransfersSoFar = 0;
}