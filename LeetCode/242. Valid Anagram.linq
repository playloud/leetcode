<Query Kind="Program" />

//242. Valid Anagram
//PSH 01/29/20 20:36:50 Wednesday
void Main()
{
	(new Solution()).IsAnagram("anagram","nagaram").Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsAnagram(string s, string t)
	{
		char[] arr01 = s.ToArray();
		char[] arr02 = t.ToArray();
		Array.Sort(arr01);
		Array.Sort(arr02);
		
		return arr01.SequenceEqual(arr02);
		
	}
}