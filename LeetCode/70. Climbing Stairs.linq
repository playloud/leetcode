<Query Kind="Program" />

// passed. 
// DP, using cache
void Main()
{
	(new Solution()).ClimbStairs(44).Dump();
}

// Define other methods and classes here
public class Solution
{
	Dictionary<int, int> dic = new Dictionary<int, int>();
	
	public int ClimbStairs(int n)
	{
		if(n==0)
			return 0;
		if(n == 1)
			return 1;
		if(n == 2)
			return 2;
		
		int val1, val2;
		val1 = 0;
		val2 = 0;
		
		if(dic.ContainsKey(n-1))
			val1 = dic[n-1];
		else
			val1 = ClimbStairs(n-1);

		if (dic.ContainsKey(n - 2))
			val2 = dic[n - 2];
		else
			val2 = ClimbStairs(n-2);
		
		dic.Add(n, (val1+val2));

		return (val1+val2);
	}
}