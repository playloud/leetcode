<Query Kind="Program" />

// PSH 12/17/17 : passed
void Main()
{
	TreeNode root = new TreeNode(10);
	root.left = new TreeNode(12);
	root.right = new TreeNode(23);
	root.right.left = new TreeNode(7);
	root.right.right = new TreeNode(15);
	root.right.right.left = new TreeNode(2);
	root.right.right.right = new TreeNode(9);


	TreeNode root2 = new TreeNode(20);
	root2.left = new TreeNode(2);
	root2.right = new TreeNode(3);
	root2.left.left = new TreeNode(7);
	root2.left.right = new TreeNode(15);
	root2.left.right.left = new TreeNode(2);
	root2.left.right.right = new TreeNode(9);
	
	(new Solution()).MergeTrees(root, root2).Dump();
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
	public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
	{
		TreeNode resultNode = null;
		if(t1 != null || t2 != null)
		{
			resultNode = new TreeNode(0);
			TraverseAndMerge(t1, t2, resultNode);
		}
		
		return resultNode;
	}
	
	public void TraverseAndMerge(TreeNode n1, TreeNode n2, TreeNode merged)
	{
		if(n1 == null && n2 == null)
			return;

		merged.val = ((n1 == null)?0:n1.val) + ((n2 == null)?0:n2.val);
		
		// LEFT
		if( (n1!=null &&  n1.left != null) || (n2 != null && n2.left != null))
		{
			merged.left = new TreeNode(0);
			TraverseAndMerge((n1==null?null:(n1.left == null?null:n1.left)), (n2==null?null:(n2.left == null?null:n2.left)), merged.left);
		}

		// RIGHT
		if( (n1!=null &&  n1.right != null) || (n2 != null && n2.right != null))
		{
			merged.right = new TreeNode(0);
			TraverseAndMerge((n1==null?null:(n1.right == null?null:n1.right)), (n2==null?null:(n2.right == null?null:n2.right)), merged.right);
		}
	}
}