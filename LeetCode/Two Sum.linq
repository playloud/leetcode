<Query Kind="Program" />

void Main()
{
	int[] input = {2, 7, 11, 15};
	(new Solution()).TwoSum(input, 22).Dump();
}

// Define other methods and classes here
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
		List<int> result = new List<int>();
		
		int[] sorted = nums.OrderBy(a=>a).ToArray();
		int tnum1, tnum2;
		tnum1 = tnum2 = -1;
		bool found = false;
		
		for (int i = 0; i < sorted.Length; i++)
		{
			int index2 = Array.BinarySearch(sorted, target - sorted[i]);
			if(index2 != i && index2 > -1)
			{
				tnum1 = sorted[i];
				tnum2 = target - sorted[i];
				found = true;
			}
		}
		
		if(found)
			for (int i = 0; i < nums.Length; i++)
			{
				if(nums[i] == tnum1 || nums[i] == tnum2)
				{
					result.Add(i);
				}
			}
		else
		{
			result.Add(-1);	
			result.Add(-1);
		}
		
		return result.ToArray();
    }
}