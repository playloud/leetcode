<Query Kind="Program" />

//108. Convert Sorted Array to Binary Search Tree
//PSH 02/02/20 20:50:16 Sunday
// this question doenst need to be filled up all nodes. simply put nodes leftward, rightward indice. 
// EASY, passed PSH 02/02/20 21:55:30 Sunday
/*
Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
*/
void Main()
{
	int[] input = {0,1,2,3,4,5};
	//int[] input = {-10,-3,0,5,9};
	(new Solution()).SortedArrayToBST(input).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
// Define other methods and classes here
public class Solution
{
	public TreeNode SortedArrayToBST(int[] nums)
	{
		if(nums == null || nums.Length == 0) {
			return null;
		}
		
		int med = nums.Length / 2;
		int v = nums[med];
		TreeNode root = new TreeNode(v);
		putNode(0, med - 1, nums, root);
		putNode(med + 1, nums.Length-1, nums, root);

		return root;
	}

	private void putNode(int start, int end, int[] arr, TreeNode root)
	{
		int med;
		
		if(start == end) {
			med = start;
		} else {
			med = (start+end)/2;
		}
		
		int v = arr[med];
		
		if (v < root.val) {
			root.left = new TreeNode(v);
			if(start <= (med-1)){
				putNode(start, med -1, arr, root.left);
			}
			if((med+1) <= end) {
				putNode(med+1, end, arr, root.left);
			}
			
			
		}

		if (root.val < v)
		{
			root.right = new TreeNode(v);

			if (start <= (med - 1))
			{
				putNode(start, med - 1, arr, root.right);
			}
			if ((med + 1) <= end)
			{
				putNode(med + 1, end, arr, root.right);
			}
		}
	}
}