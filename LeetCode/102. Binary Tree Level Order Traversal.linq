<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(3);
	root.left = new TreeNode(9);
	root.right = new TreeNode(20);
	root.right.left = new TreeNode(15);
	root.right.right = new TreeNode(7);
	root.right.right.right = new TreeNode(234);
	
	(new Solution()).LevelOrder(root).Dump();
	
	
}

// Define other methods and classes here
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Solution
{
	public IList<IList<int>> LevelOrder(TreeNode root)
	{
		IList<IList<int>> result = new List<IList<int>>();
		
		Queue<TreeNode> q1 = new Queue<TreeNode>();
		Queue<TreeNode> q2 = new Queue<TreeNode>();
		
		Queue<TreeNode> curQue = null;
		Queue<TreeNode> nextQue = null;

		q1.Enqueue(root);
		
		while (q1.Count > 0 || q2.Count > 0)
		{
			// decide queue
			if (q1.Count > 0)
			{
				curQue = q1;
				nextQue = q2;
			}
			else
			{
				curQue = q2;
				nextQue = q1;
			}
			
			List<int> founds = new List<int>();
			while (curQue.Count > 0)
			{
				TreeNode n = curQue.Dequeue();
				if (n != null)
				{
					founds.Add(n.val);
					
					if(n.left != null)
						nextQue.Enqueue(n.left);
					if(n.right != null)
						nextQue.Enqueue(n.right);
				}
			}
			if(founds.Count > 0)
				result.Add(founds);
		}
		return result;
	}
}