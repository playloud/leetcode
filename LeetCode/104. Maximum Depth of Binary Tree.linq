<Query Kind="Program" />

//104. Maximum Depth of Binary Tree
//PSH 02/01/20 23:59:50 Saturday
void Main()
{
	TreeNode root = new TreeNode(0);
	
	(new Solution()).MaxDepth(root).Dump();
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
	public int MaxDepth(TreeNode root)
	{
		if(root == null)
			return 0;
		
		return getMaxDepth(root, 1);
	}
	
	public int getMaxDepth(TreeNode node, int currentDepth)
	{
		if(node == null)
			return (currentDepth-1);
		
		return Math.Max(getMaxDepth(node.left, (currentDepth+1)), getMaxDepth(node.right, (currentDepth+1)));
	}
}