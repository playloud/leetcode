<Query Kind="Program" />

void Main()
{
//	int[] test = {3, 6, 1, 0};
//	int[] test = {3, 6, 1, 0};
	int[] test = {1,2,3,4,16};
	(new Solution()).DominantIndex(test).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int DominantIndex(int[] nums)
	{
		if(nums == null || nums.Length < 2)
			return -1;
		
		var tempList = new List<int>();
		tempList.AddRange(nums);
		tempList.Sort();
		
		int lastElement = tempList.Last();
		int secondLast = tempList[nums.Length -2];
		
		if(lastElement >= (2*secondLast))
		{
			for (int i = 0; i < nums.Length; i++)
			{
				if(nums[i] == lastElement)
					return i;
			}
		}
		
		return -1;

	}
}