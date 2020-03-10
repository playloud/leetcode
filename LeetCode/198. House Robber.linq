<Query Kind="Program" />

void Main()
{
	int[] nums= {1,2,3,1};
	(new Solution()).Rob(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int Rob(int[] nums)
	{
		Array.Sort(nums);
		
		int result = 0;
		
		int current = -2;
		int next1 = 0;
		int next2 = 0;
		
		for (int i = 0; i < nums.Length; i++)
		{
			next1 = current + 2;
			next2 = current + 3;
			
			if(next1 < nums.Length && next2 < nums.Length)
			{
				if(nums[next1] < nums[next2])
				{
					result += nums[next2];
					current = next2;
				}
				else 
				{
					result += nums[next1];
					current = next1;
				}
			}
			else if(next1 < nums.Length)
			{
				result += nums[next1];
				current = next1;
			}
		}
		
		return result;
		
	}
}