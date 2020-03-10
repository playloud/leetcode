<Query Kind="Program" />

void Main()
{
	int[] nums = {3, 4, 2};
	(new Solution()).DeleteAndEarn(nums).Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public int DeleteAndEarn(int[] nums)
	{
		int[] arr = nums.OrderByDescending(a=>a).ToArray();
		int maxScore = 0;
		UpdateMax(0, arr, ref maxScore);
		return maxScore;
	}
	
	public void UpdateMax(int score, int[] arr, ref int max)
	{
		if (arr != null && arr.Length > 0)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				int newScore = arr[i]+score;
				int[] newArr = GetNewArr(arr[i], arr);
				
				if(newScore >= max)
					max = newScore;
				
				UpdateMax(newScore, newArr, ref max);
			}
		}
	}
	
	public int[] GetNewArr(int deleteSeed,int[] arr)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < arr.Length; i++)
		{
			if(arr[i] == (deleteSeed-1) || arr[i] == (deleteSeed+1))
				continue;
			list.Add(arr[i]);
		}
		return list.ToArray();
	}
}