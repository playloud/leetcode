<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);
	
	root.left.right = new TreeNode(5);
	root.right.left = new TreeNode(6);
	
	(new Solution()).RightSideView(root).Dump();
	
}

// Define other methods and classes here

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Solution
{
	public IList<int> RightSideView(TreeNode root)
	{
		List<int> result = new List<int>();
		
		Queue<TreeNode> mainQueue = new Queue<TreeNode>();
		Queue<TreeNode> tempQueue = new Queue<TreeNode>();
		
		bool direction = true;
		
		// Root can be null!!!
		if(root != null)
			mainQueue.Enqueue(root);
			
		while(mainQueue.Count > 0)
		{
			TreeNode n = mainQueue.Dequeue();

			if (n.left != null)
				tempQueue.Enqueue(n.left);
			if (n.right != null)
				tempQueue.Enqueue(n.right);

			if(mainQueue.Count == 0)
			{
				result.Add(n.val);
				mainQueue = tempQueue;
				tempQueue = new Queue<TreeNode>();
			}
		}
		
		return result;
		
	}
}eivj3Ws3