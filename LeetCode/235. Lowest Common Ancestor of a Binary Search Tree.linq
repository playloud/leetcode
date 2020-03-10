<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class TreeNode {
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
public class Solution
{
	public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
	{
		int min, max;
		
		// using BFS
		Stack<TreeNode> stack = new Stack<TreeNode>();
		
		min = Math.Min(p.val, q.val);
		max = Math.Max(p.val, q.val);
		
		TreeNode cursor = null;
		stack.Push(root);
		
		Stack<TreeNode> tempStack = new Stack<TreeNode>();

		while (stack.Count > 0)
		{
			cursor = stack.Pop();
			if (min <= cursor.val && cursor.val <= max)
			{
				return cursor;
			}

			if (cursor.left != null)
				tempStack.Push(cursor.left);
			if (cursor.right != null)
				tempStack.Push(cursor.right);

			if (stack.Count == 0)
			{
				stack = tempStack;
				tempStack = new Stack<TreeNode>();
			}
		}
		return null;
	}
}