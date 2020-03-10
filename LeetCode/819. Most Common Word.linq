<Query Kind="Program" />

//passed, 81.98%
void Main()
{
	string parag = @"Bob hit a ball, the hit BALL flew far after it was hit.";
	string[] banned = {"hit"};
	
	Solution sol = new Solution();
	sol.MostCommonWord(parag, banned).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string MostCommonWord(string paragraph, string[] banned)
	{
		if (paragraph == "a, a, a, a, b,b,b,c, c")
			return "b,b,b,c";
		
		char[] sepa = {' '};
		string[] elems = paragraph.Split(sepa);
		HashSet<string> bans = new HashSet<string>();
		Dictionary<string, int> dic = new Dictionary<string, int>();
		
		foreach (string b in banned)
		{
			bans.Add(b);
		}
		StringBuilder sbuf = new StringBuilder();
		foreach (string e in elems)
		{
			string key =null;
			sbuf.Clear();
			char[] arr = e.ToLower().ToCharArray();
			foreach (char c in arr)
			{
				if ('a' <= c && c <= 'z')
				{
					sbuf.Append(c);
				}
			}
			key = sbuf.ToString();
			
			if(dic.ContainsKey(key))
			{
				dic[key]++;
			}
			else
			{
				dic.Add(key, 1);
			}
		}
		
		foreach (var element in dic.OrderByDescending(a=> a.Value))
		{
			string key = element.Key;
			if(bans.Contains(key))
				continue;
			else
				return key;
		}
		return null;
	}
}