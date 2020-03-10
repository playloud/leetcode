<Query Kind="Program" />

//https://leetcode.com/problems/first-unique-character-in-a-string/
//PSH 01/29/20 00:22:27 Wednesday
void Main()
{
	string s = "loveleetcode";
	(new Solution()).FirstUniqChar(s).Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public int FirstUniqChar(string s)
	{
		Dictionary<char, int> dic = new Dictionary<char, int>();
		char[] arr = s.ToArray();
		
		for (int i = 0; i < arr.Length; i++)
		{
			char c = arr[i];
			if(dic.ContainsKey(c)) {
				dic[c] = -1;
			} else {
				dic.Add(c,i);
			}
		}
		if(dic.Values.Where(a=>a>-1).Any()) {
			return dic.Values.Where(a=> a > -1).OrderBy(a=>a).First();
		} 
		return -1;
	}	
}