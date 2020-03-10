<Query Kind="Program" />

void Main()
{
	int[] nums = { -1,2,-1,2,1,-1,2,1 };
	(new Solution()).PermuteUnique(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> PermuteUnique(int[] nums)
	{
		List<IList<int>> result = new List<System.Collections.Generic.IList<int>>();
		bool[] map = new bool[nums.Length];
		HashSet<string> checker = new HashSet<string>();
		StringBuilder buf = new StringBuilder();
		MyP(nums, map, 0, null, buf, checker, result);
		return result;
	}

	public void MyP(int[] src, bool[] map, int level, List<int> history, StringBuilder buf, HashSet<string> checker, List<IList<int>> result)
	{

		if (history == null)
			history = new List<int>();

		for (int i = 0; i < src.Length; i++)
		{
			if (map[i] == true)
				continue;

			map[i] = true;
			
			// occupy
			history.Add(src[i]);
			buf.Append(src[i]);

			if (history.Count == src.Length && !checker.Contains(buf.ToString()))
			{
				//history.Dump();
				IList<int> temp = new List<int>();
				history.ForEach(a => temp.Add(a));
				result.Add(temp);
				checker.Add(buf.ToString());
			}

			MyP(src, map, ++level, history, buf,checker, result);

			map[i] = false;
			history.RemoveAt(history.Count - 1);
			buf.Remove(buf.Length-1,1);
		}
		//Console.WriteLine();
	}
}