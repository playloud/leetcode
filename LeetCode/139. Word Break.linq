<Query Kind="Program" />

void Main()
{

	string str = "acaaaaabbbdbcccdcdaadcdccacbcccabbbbcdaaaaaadb";
	string[] src = { "abbcbda", "cbdaaa", "b", "dadaaad", "dccbbbc", "dccadd", "ccbdbc", "bbca", "bacbcdd", "a", "bacb", "cbc", "adc", "c", "cbdbcad", "cdbab", "db", "abbcdbd", "bcb", "bbdab", "aa", "bcadb", "bacbcb", "ca", "dbdabdb", "ccd", "acbb", "bdc", "acbccd", "d", "cccdcda", "dcbd", "cbccacd", "ac", "cca", "aaddc", "dccac", "ccdc", "bbbbcda", "ba", "adbcadb", "dca", "abd", "bdbb", "ddadbad", "badb", "ab", "aaaaa", "acba", "abbb"};
	
	List<string> dict = new List<string>();
	dict.AddRange(src);
	
//	string str = "leetcodee";
//	List<string> dict = new List<string>();
//	dict.Add("leet");
//	dict.Add("code");
	
	(new Solution()).WordBreak(str, dict).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool WordBreak(string s, IList<string> wordDict)
	{
		bool result = false;
		HashSet<string> dict = new HashSet<string>();
		
		foreach (string str in wordDict)
			dict.Add(str);
		
		Check(s, dict, ref result);
		return result;
	}
	
	public void Check(string str, HashSet<string> dict, ref bool result)
	{
		//Console.WriteLine(":"+str);
		string subStr = null;
		int length = str.Length;
		for (int i = 0; i < str.Length; i++)
		{
			subStr = str.Substring(0, i + 1);
			//Console.WriteLine(subStr);
			if (dict.Contains(subStr))
			{
				if (str.Length == (i + 1))
				{
					result = true;
					return;
				}
				string remain = str.Substring(i+1);
				Check(remain, dict, ref result);
			}
		}
	}
}