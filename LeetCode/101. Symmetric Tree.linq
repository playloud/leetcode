<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

//https://leetcode.com/problems/symmetric-tree/
//PSH 02/02/20 17:59:19 Sunday, passed
void Main()
{
	//[1,2,2,3,4,4,3]
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(2);
	
	root.left.left = new TreeNode(3);
	root.left.right = new TreeNode(4);

	root.right.left = new TreeNode(4);
	root.right.right = new TreeNode(3);
	
	(new Solution()).IsSymmetric(root).Dump();

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
	public bool IsSymmetric(TreeNode root)
	{
		List<TreeNode> line = new List<TreeNode>();
		line.Add(root);
		
		while(line.Count > 0) {
		
			bool isAllNull = true;
			
			if(!checkSymmetrical(line.ToArray())) {
				return false;
			}
			
			List<TreeNode> temp = new List<TreeNode>();
			foreach (TreeNode n in line)
			{
				if(n != null)
				{
					temp.Add(n.left);
					temp.Add(n.right);
					
					if(n.left != null || n.right !=null)
						isAllNull = false;
					
				} else {
					temp.Add(null);
					temp.Add(null);
				}
			}
			
			if(isAllNull)
				break;
			
			line = temp;
		}
		
		return true;
	}
	
	public bool checkSymmetrical(TreeNode[] arr) {
	
		if(arr.Length == 1)
			return true;
	
		for (int i = 0; i < arr.Length/2; i++)
		{
			int j = arr.Length - i -1;
			
			if(arr[i] != null && arr[j] !=null &&  (arr[i].val != arr[j].val) )
				return false;
			
			if(arr[i] != null && arr[j] ==null)
				return false;

			if (arr[j] != null && arr[i] == null)
				return false;
			
		}
		
		return true;
	}
}