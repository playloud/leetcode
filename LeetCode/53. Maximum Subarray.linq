<Query Kind="Program" />

void Main()
{
	int[] src = {-2,1,-3,4,-1,2,1,-5,4};
	(new Solution()).MaxSubArray(src).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxSubArray(int[] nums)
	{
		int max = int.MinValue;
		
		int[,] m = new int[nums.Length,nums.Length];
		
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i; j < nums.Length; j++)
			{
				if(i==j)
				{
					m[i,j] = nums[i];
					max = Math.Max(max, m[i,j]);
				}
				else
				{
					m[i,j] = m[i,j-1]+nums[j];
					max = Math.Max(max, m[i,j]);
				}
				
			}
		}
		
		return max;
	}
}