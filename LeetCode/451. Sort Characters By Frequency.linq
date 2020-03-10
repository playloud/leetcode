<Query Kind="Program" />

void Main()
{
	(new Solution()).FrequencySort("tree").Dump();
	
	(new Solution()).FrequencySort("aabbbcccccddddddddd").Dump();
}

// Define other methods and classes here
public class Solution
{
	public string FrequencySort(string s)
	{
		
		char[] arr = s.ToCharArray();
		Dictionary<char, Counter> dic = new Dictionary<char, Counter>();
		
		for (int i = 0; i < arr.Length; i++)
		{
			if(dic.ContainsKey(arr[i]))
			{
				dic[arr[i]].count++;
			}
			else
			{
				dic.Add(arr[i], new Counter(){c=arr[i],count=1});
			}
			
		}
		StringBuilder sbuf = new StringBuilder();
		
		var query = dic.Values.OrderByDescending(a=> a.count);
		
		foreach (Counter cnt in query)
		{
			for (int i = 0; i < cnt.count; i++)
			{
				sbuf.Append(cnt.c);
			}
		}
		
		
		return sbuf.ToString();
	}
	
	public class Counter
	{
		public char c { get; set; }
		public int count { get; set; }
	}
}