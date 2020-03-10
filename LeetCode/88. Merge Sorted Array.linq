<Query Kind="Program" />

//https://leetcode.com/problems/merge-sorted-array/
//PSH 02/02/20 22:41:02 Sunday
/*
Well... it has passed. 
*/
void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public void Merge(int[] nums1, int m, int[] nums2, int n)
	{
		if(n == 0 || nums2 == null) {
			return;
		}
		
		Array.Copy(nums2, 0, nums1, m, nums2.Length);
		Array.Sort(nums1);
	}
}