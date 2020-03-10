<Query Kind="Program" />

void Main()
{
//	TreeNode root = new TreeNode(10);
//	root.left = new TreeNode(12);
//	root.right = new TreeNode(23);
//	root.right.left = new TreeNode(7);
//	root.right.right = new TreeNode(15);
//	root.right.right.left = new TreeNode(2);
//	root.right.right.right = new TreeNode(9);
//	(new Solution()).LowestCommonAncestor(root, root.right.left, root.right.right.right).Dump();

	TreeNode root = new TreeNode(1);
	root.right = new TreeNode(2);
	(new Solution()).LowestCommonAncestor(root, root.right, root).Dump();


	
	
}

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
		var historyOfP = new List<TreeNode>();
		var historyOfQ = new List<TreeNode>();
		
		SearchDFS(root, historyOfP, p);
		SearchDFS(root, historyOfQ, q);
		
		historyOfP.ForEach(a=> Console.Write(a.val+" "));
		Console.WriteLine();
		historyOfQ.ForEach(a=> Console.Write(a.val+" "));
		
		
		TreeNode prev = null;
		
		// must until minimum Number of both of two!!
		for (int i = 0; i < Math.Min(historyOfP.Count, historyOfQ.Count); i++)
		{
			if(historyOfP[i] != historyOfQ[i])
				return prev;
			prev = historyOfP[i];
		}
		
		return prev;
	}
	
	public bool SearchDFS(TreeNode n, List<TreeNode> history, TreeNode target)
	{
		history.Add(n);
		
		if(target == n)
			return true;
		
		if(n.left != null)
		{
			if(!SearchDFS(n.left, history, target))
				history.RemoveAt(history.Count-1);
			else
				return true;
		}
		
		if(n.right != null)
		{
			if(!SearchDFS(n.right, history, target))
				history.RemoveAt(history.Count - 1);
			else
				return true;
		}
		
		return false;
	}
}