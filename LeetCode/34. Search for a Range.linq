<Query Kind="Program" />

void Main()
{
	int[] test = {5, 7, 7, 8, 8, 8,8,9,9,9, 10};
	(new Solution()).SearchRange(test, 7).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] SearchRange(int[] nums, int target)
	{
		int[] result = new int[2];
		result[0] = -1;
		result[1] = -1;
		
		MyDQ(0, nums.Length-1, target, nums, result);
		
		
		
		return result;
	}
	
	public void MyDQ(int startIndex, int endIndex, int target, int[] src, int[] result)
	{
		if(src == null || src.Length == 0)
			return;
		
		if(src[startIndex] == target)
		{
			// check minumum
			if(result[0] == -1)
				result[0] = startIndex;
			else if(result[0] > startIndex)
				result[0] = startIndex;
		}
		
		if(src[endIndex] == target)
		{
			// check maximum
			if(result[1] == -1)
				result[1] = endIndex;
			else if(result[1] < endIndex)
				result[1] = endIndex;
		}

		if (startIndex == endIndex)
			return;
		
		int s1,s2, e1, e2;
		s1 = startIndex;
		e1 = (startIndex + endIndex)/2;
		MyDQ(s1,e1,target,src, result);
		s2 = e1+1;
		e2 = endIndex;
		MyDQ(s2,e2,target,src, result);
	}
	
	
	
}