<Query Kind="Program" />

void Main()
{
	int[] input = {1,1,2};
	
	(new Solution()).RemoveDuplicates(input).Dump();
}

/*

Given a sorted array, remove the duplicates in-place such that each element appear only once and return the new length.
Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

*/
// Define other methods and classes here
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        
		if(nums == null || nums.Length == 0)
			return 0;
		if(nums.Length == 1)
			return 1;
		
		int result = 1;
		
		
		int prevValue = nums[0];
		
		for (int i = 1; i < nums.Length; i++)
		{
			if(prevValue != nums[i])
				result++;
			prevValue = nums[i];
		}
		
		return result;
		
		
    }
}