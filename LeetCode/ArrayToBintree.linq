<Query Kind="Program" />

void Main()
{
	int[] test = {1,4,6,7,9,11,13,18,29};
	Node root = ArrayToBinTree(test);
	root.Dump();
	
}

// Define other methods and classes here
public class Node 
{
	public Node left = null;
	public Node right = null;
	
	int value;
	
	public Node(int value) {
		this.value = value;
	}

	public override string ToString()
	{
		return string.Format("{0}-({1} {2})", value, left.value, right.value);
	}
}

public Node ArrayToBinTree(int[] arr)
{
	Dictionary<int, Node> nodes = new Dictionary<int, UserQuery.Node>();
	Node root = null;
	
	for (int i = 0; i < arr.Length; i++)
	{
		nodes.Add(i, (new Node(arr[i])));
	}
	
	for (int i = 0; i < arr.Length; i++)
	{
		Node n = nodes[i];
		
		//left
		int leftIndex = 2*i +1;
		int rightIndex = 2*i+2;
		if(nodes.ContainsKey(leftIndex)) 
		{
			n.left = nodes[leftIndex];
		}
		
		//right
		if(nodes.ContainsKey(rightIndex))
		{
			n.right = nodes[rightIndex];
		}
	}
	
	
	
	
	return nodes[0];
}