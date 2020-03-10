<Query Kind="Program" />

void Main()
{
	(new Solution()).GrayCode(12).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int> GrayCode(int n)
	{
		
		List<int> result = new List<int>();
		if(n == 0)
			result.Add(0);
		else
			GetNthGrayCode(n).ForEach(a=> result.Add(Convert.ToInt32(a, 2)));
		return result;
	}

	List<string> GetNthGrayCode(int n)
	{
		if (n == 1)
		{
			List<string> nums = new List<string>();
			nums.Add("0");
			nums.Add("1");
			return nums;
		}
		else
		{
			List<string> pre = GetNthGrayCode(n - 1);
			List<string> nums = new List<string>();
			pre.ForEach(a => nums.Add("0" + a));
			pre.Reverse();
			pre.ForEach(a => nums.Add("1" + a));
			return nums;
		}
		return null;
	}
}
