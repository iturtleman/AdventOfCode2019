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
K)L".Split('\n')) == 42,
	}.Dump();


	var input = File.ReadAllLines("Puzzle6input.txt");
	GetTotalDirectOrbits(input).Dump();

	// Part 2

}

int GetTotalDirectOrbits(string[] input)
{
	var COM = ReadInput(input);
	var all = new List<Node>() { COM }.SelectMany(FlattenList);
	
	return all.Select(n=>n.GetTotalDirectAndInderectOrbits).Sum();
}

List<Node> FlattenList(Node n)
{
	var retval = new List<Node>() { n };
	retval.AddRange(n.Children.SelectMany(FlattenList));
	return retval;
}

private Node ReadInput(string[] input)
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
	return nodes["COM"];
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
}