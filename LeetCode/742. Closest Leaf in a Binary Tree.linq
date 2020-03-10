<Query Kind="Program" />

void Main()
{
		TreeNode root = new TreeNode(10);
		root.left = new TreeNode(12);
		root.right = new TreeNode(23);
		root.right.left = new TreeNode(7);
		root.right.right = new TreeNode(15);
		root.right.right.left = new TreeNode(2);
		root.right.right.right = new TreeNode(9);
		
		(new Solution()).FindClosestLeaf(root, 7);
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
	public int FindClosestLeaf(TreeNode root, int k)
	{
		Hashtable allLeafNodeHistory = new Hashtable();
		var historyOfAll = new List<TreeNode>();
		
		
		Dictionary<TreeNode, int> distanceNode = new Dictionary<TreeNode, int>();
		
		// find target node and history
		TreeNode nodeK = null;
		var historyOfK = new List<TreeNode>();
		
		SearchKNode(root, k, historyOfK, ref nodeK);
		
		// find all leaf nodes
		SearchLeatDFS(root, historyOfAll, allLeafNodeHistory);

		// check the same 
		if(allLeafNodeHistory.ContainsKey(nodeK))
			return nodeK.val;
		
		


		return 0;
	
	}	
	
	public bool SearchKNode(TreeNode n, int target, List<TreeNode> history, ref TreeNode nodeK)
	{
		history.Add(n);
		if(n.val == target)
		{
			nodeK = n;
			return true;
		}
		
		if(n.left != null)
		{
			if(!SearchKNode(n.left, target, history, ref nodeK))
				history.RemoveAt(history.Count-1);
			else
			{
				return true;
			}
		}
		
		if(n.right != null)
		{
			if(!SearchKNode(n.left, target, history, ref nodeK))
				history.RemoveAt(history.Count - 1);
			else 
			{
				return true;
			}
		}
		return false;
		
	}
	
	
	public void SearchLeatDFS(TreeNode n, List<TreeNode> history, Hashtable table)
	{
		history.Add(n);
		
		
		if(n.left == null && n.right == null)
		{
			table.Add(n, history);
		}

		if (n.left != null)
		{
			SearchLeatDFS(n.left, history, table);
		}

		if (n.right != null)
		{
			SearchLeatDFS(n.right, history, table);
		}
	}
}