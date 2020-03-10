<Query Kind="Program" />

void Main()
{

	int[] arr = {1,1,2};
	int[] arr2 = {0,0,1,1,1,2,2,3,3,4};
	(new Solution()).RemoveDuplicates(arr).Dump();
	arr.Dump();
	(new Solution()).RemoveDuplicates(arr2).Dump();
	arr2.Dump();
}

// Define other methods and classes here
public class Solution
{
	public int RemoveDuplicates(int[] nums)
	{
		
		if(nums == null || nums.Length == 0)
			return 0;
		
		int j=0;
		int keyValue = nums[0];
		
		for (int i = 0; i < nums.Length; i++)
		{
			if(keyValue == nums[i])
			{
				nums[j] = keyValue;
			}
			else
			{
				keyValue = nums[i];
				j++;
				nums[j] = keyValue;
			}
		}
		return ++j;
	}

}