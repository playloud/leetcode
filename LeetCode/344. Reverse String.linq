<Query Kind="Program" />

//https://leetcode.com/problems/reverse-string/
//PSH 01/29/20 00:00:20 Wednesday
void Main()
{
	//char[] input = {'h','e','l','l','o'};
	char[] input = {'h','e'};
	(new Solution()).ReverseString(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public void ReverseString(char[] s)
	{
		for (int i = 0; i < s.Length/2; i++)
		{
			int j = (s.Length - 1) - i;
			char c = s[i];
			s[i] = s[j];
			s[j] = c;
		}
	}
}