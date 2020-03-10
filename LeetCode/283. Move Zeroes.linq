<Query Kind="Program" />

//PSH 01/27/20 17:44:23 Monday
//https://leetcode.com/problems/move-zeroes/
void Main()
{
	//int[] input = {0,1,0,3,12};	
	int[] input = {1,23,4,5,0,3,5,0,3,12};	
	(new Solution()).MoveZeroes(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public void MoveZeroes(int[] nums)
	{
		
		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[i] == 0 && i < nums.Length-1)
			{
				for (int j = i + 1; j < nums.Length; j++)
				{
					if(nums[j] != 0) 
					{
						//swap
						nums[i] = nums[j];
						nums[j] = 0;
						break;
					}

				}
			}
		}

	}
}