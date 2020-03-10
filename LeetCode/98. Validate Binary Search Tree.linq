<Query Kind="Program" />

//98. Validate Binary Search Tree
//PSH 02/02/20 01:41:38 Sunday
// accepted
void Main()
{
	// right case
//	TreeNode root = new TreeNode(2);
//	root.left = new TreeNode(1);
//	root.right = new TreeNode(3);

	// wrong case
//	TreeNode root = new TreeNode(2);
//	root.left = new TreeNode(3);
//	root.right = new TreeNode(3);
	
	//wrong case
	TreeNode root = new TreeNode(2);
	root.left = new TreeNode(2);


	(new Solution()).IsValidBST(root).Dump();
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
	static TreeNode wrongNode = null;
	
	public bool IsValidBST(TreeNode root)
	{
		if (root == null)
			return true;
			
		wrongNode = null;
		
		checkNode(root);
		
		if(wrongNode != null)
			return false;
		
		return true;
	}
	
	public void checkNode(TreeNode n)
	{
		int val = n.val;
		
		findBigInLeft(n.left, n.val);
		
		if(wrongNode != null)
			return;

		findSmallInRight(n.right, n.val);

		if (wrongNode != null)
			return;
			
		if(n.left != null)
			checkNode(n.left);

		if (n.right != null)
			checkNode(n.right);

	}
	
	public void findBigInLeft(TreeNode n, int val)
	{
		if(n == null)
			return;
			
		if(n.val >= val)
		{
			wrongNode = n;
			return;
		}
		
		if(n.left != null && n.left.val >= val)
		{
			wrongNode = n.left;
			return;
		}
		
		if(n.left != null)
		{
			findBigInLeft(n.left, val);
		}
		
		if(n.right!= null && n.right.val >= val)
		{
			wrongNode = n.right;
			return;
		}

		if (n.right != null)
		{
			findBigInLeft(n.right, val);
		}
	}
	
	public void findSmallInRight(TreeNode n, int val)
	{

		if (n == null)
			return;

		if (n.val <= val)
		{
			wrongNode = n;
			return;
		}

		if (n.left != null && n.left.val <= val)
		{
			wrongNode = n.left;
			return;
		}

		if (n.left != null)
		{
			findSmallInRight(n.left, val);
		}

		if (n.right != null && n.right.val <= val)
		{
			wrongNode = n.right;
		}

		if (n.right != null)
		{
			findSmallInRight(n.right, val);
		}
	}
}











public class Solution_failed
{
	public bool IsValidBST(TreeNode root)
	{
		if (root == null)
			return true;

		Queue<TreeNode> queue = new Queue<TreeNode>();

		queue.Enqueue(root);
		while (queue.Count > 0)
		{
			TreeNode n = queue.Dequeue();
			if (n.left != null)
			{
				if (n.val <= n.left.val)
					return false;
				queue.Enqueue(n.left);
			}

			if (n.right != null)
			{
				if (n.val >= n.right.val)
					return false;
				queue.Enqueue(n.right);
			}
		}


		return true;
	}
}

