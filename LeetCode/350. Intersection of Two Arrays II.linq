<Query Kind="Program" />

//https://leetcode.com/problems/intersection-of-two-arrays-ii/submissions/
void Main()
{
//	int[] nums1 = { 4, 9, 5 }; 
//	int[] nums2 = { 9, 4, 9, 8, 4};

	int[] nums1 = { 2,2 };
	int[] nums2 = { 1,2,2,1 };

	(new Solution()).Intersect(nums1, nums2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] Intersect(int[] nums1, int[] nums2)
	{
		
		List<int> result = new List<int>();
		
		int[] bigArray = null;
		int[] smallArray = null;
		Array.Sort(nums1);
		Array.Sort(nums2);
		
		if(nums1.Length > nums2.Length) 
		{
			bigArray = nums1;
			smallArray = nums2;
		} else {
			bigArray = nums2;
			smallArray = nums1;
		}
		
		int startPos = 0;
		
		for (int i = 0; i < smallArray.Length; i++)
		{
			for (int j = startPos; j < bigArray.Length; j++)
			{
				int small = smallArray[i];
				int big = bigArray[j];
				if (smallArray[i] == bigArray[j])
				{
					result.Add(smallArray[i]);
					startPos = j+1;
					break;
				} 
				else if (smallArray[i] < bigArray[j]) 
				{
					startPos = j;
					break;
				}
				else 
				{
					startPos = j;
				}
			}
		}
		
		
		return result.ToArray();
		
	}
}