<Query Kind="Program" />

void Main()
{
	int[] nums = {1,2,3};
	(new Solution()).Permute(nums).Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> Permute(int[] nums)
	{
		List<IList<int>> result = new List<System.Collections.Generic.IList<int>>();
		bool[] map = new bool[nums.Length];
		
		MyP(nums, map, 0, null, result);
		
		return result;
	}
	
	public void MyP(int[] src, bool[] map, int level, List<int> history, List<IList<int>> result)
	{
		
		if(history == null)
			history = new List<int>();
		
		for (int i = 0; i < src.Length; i++)
		{
			if (map[i] == true)
				continue;

			map[i] = true;
			// occupy
			history.Add(src[i]);
			
			if(history.Count == src.Length)
			{
				//history.Dump();
				IList<int> temp = new List<int>();
				history.ForEach(a=> temp.Add(a));
				result.Add(temp);
			}
			
			MyP(src, map, ++level, history,  result);
			
			map[i] = false;
			history.RemoveAt(history.Count-1);
		}
		//Console.WriteLine();
	}


}