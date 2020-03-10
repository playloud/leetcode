<Query Kind="Program" />

void Main()
{
	int[] test01 = {1,2,3,4,5,6,7};
	//int[] test01 = {1,2};
	int k = 3;
	Solution sol = new Solution();
	sol.Rotate(test01, k);
	test01.Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public void Rotate(int[] nums, int k)
	{
		
		if(nums.Length <=1) {
			return;
		}
		
		int nextIndex = k;
		int nextElement = nums[0];
		int count = 0;
		
		int[] result = new int[nums.Length];
		
		for (int i = 0; i < nums.Length; i++)
		{
			nextIndex = i + k;
			if(nextIndex >= nums.Length) 
			{
				nextIndex = nextIndex % nums.Length;	
			}
			
			result[nextIndex] = nums[i];
			
		}
		Array.Copy(result, nums,nums.Length);
		
	}
}