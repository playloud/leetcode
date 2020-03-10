<Query Kind="Program" />

void Main()
{
	(new Solution()).Subsets(new int[] {1,2,3,4}).Dump();
	//(new Solution()).Subsets(new int[] {1}).Dump();
}

public class Solution
{
	public IList<IList<int>> Subsets(int[] nums)
	{
		bool[] maps = new bool[nums.Length];
		for (int i = 0; i < maps.Length; i++)
			maps[i] = false;
		
		IList<IList<int>> results = new List<IList<int>>();
		List<int> current = new List<int>();
		int startIndex = 0;
		
		GetSubset(maps, nums, startIndex, current, results);
		
		results.Add(new List<int>());
		
		return results;
	}
	
	// maintaining startIndex: for considering direction
	// 
	public void GetSubset(bool[] maps, int[] nums, int startIndex, List<int> current, IList<IList<int>> globalList)
	{
		// main loop
		for (int i = startIndex; i < maps.Length; i++)
		{
			if (maps[i] == false)
			{
				maps[i] = true;
				current.Add(nums[i]);
				
				// add snapshop, 
				List<int> temp = new List<int>();
				temp.AddRange(current);
				globalList.Add(temp);
				
				GetSubset(maps, nums, i+1, current, globalList);
				
				maps[i] = false;
				current.Remove(nums[i]);
			}
		}
	}
	
}