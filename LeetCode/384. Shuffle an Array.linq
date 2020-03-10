<Query Kind="Program" />

//384. Shuffle an Array
//https://leetcode.com/problems/shuffle-an-array/
void Main()
{
	int[] nums = { 1, 2, 3, 4, 5};
	(new Solution(nums)).Shuffle().Dump();
}

// Define other methods and classes here
public class Solution
{
	int[] nums = null;
	Random rand = new Random();

	public Solution(int[] nums)
	{
		this.nums = nums;
	}

	/** Resets the array to its original configuration and return it. */
	public int[] Reset()
	{
		return nums;
	}

	/** Returns a random shuffling of the array. */
	public int[] Shuffle()
	{
		List<int> list = nums.ToList();
		List<int> toReturn = new List<int>();
		
		while(toReturn.Count < nums.Length) 
		{

			int index = rand.Next(0, list.Count);
			toReturn.Add(list.ElementAt(index));
			list.RemoveAt(index);
		}
		
		return toReturn.ToArray();
	}
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */