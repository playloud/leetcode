<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int FindKthLargest(int[] nums, int k)
	{
		if(nums != null && nums.Length > 0)
		{
			Array.Sort(nums);
			return nums.Reverse().Skip(k).Take(1).First();
		}
		return -1;
		
	}
}