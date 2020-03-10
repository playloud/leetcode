<Query Kind="Program" />

//198.House Robber
//https://leetcode.com/problems/house-robber/
void Main()
{

	//int[] input = {1,2,3,1};
	int[] input = {2,7,9,3,1};
	(new Solution()).Rob(input).Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public int Rob(int[] nums)
	{
		return Math.Max(GetMax(0, nums), GetMax(1,nums));
	}
	
	public int GetMax(int startIndex, int[] nums) 
	{
		int lSum = 0;
		
		int curIndex = startIndex;
		int next1 = 0;
		int next2 = 0;
		
		lSum = nums[curIndex];
		
		while(curIndex < nums.Length) 
		{
			
			next1 = curIndex+2;
			next2 = curIndex+3;
			
			if(next2 < nums.Length) {
				if(nums[next1] < nums[next2]) {
					lSum += nums[next2];
					curIndex = next2;
				}
				else
				{
					lSum += nums[next1];
					curIndex = next1;
				}
				
				
			} else if (next1 < nums.Length) {
				lSum += nums[next1];
				break;
			} else {
				// out
				break;
			}
		}
		
		return lSum;
		
	}
}