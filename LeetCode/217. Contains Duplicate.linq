<Query Kind="Program" />

//https://leetcode.com/problems/contains-duplicate/
void Main()
{
	int[] nums = {1,2,3,1};
	
	Solution sol = new Solution();
	sol.ContainsDuplicate(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool ContainsDuplicate(int[] nums)
	{
		HashSet<int> hs = new HashSet<int>();
		
		for (int i = 0; i < nums.Length; i++)
		{
			if(hs.Contains(nums[i])) {
				return true;
			} else {
				hs.Add(nums[i]);
			}
		}
		
		return false;
	}
}