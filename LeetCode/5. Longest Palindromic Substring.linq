<Query Kind="Program" />

//https://leetcode.com/problems/longest-palindromic-substring/
//PSH 02/20/20 22:17:07 Thursday passed 17%
/*
things to check
	- boundary check
	- 
*/
void Main()
{
	//string input = "babad";
	string input = "aba";
	(new Solution()).LongestPalindrome(input).Dump();
}

public class Solution
{
	
	static int longest = 0;
	
	public Solution() 
	{
		longest = 0;
	}
	
	public string LongestPalindrome(string s)
	{
		if(s == null)
			return null;
		if(s == "")
			return s;
		if(s.Length == 1)
			return s;
		
		Dictionary<int, string> founds = new Dictionary<int, string>();
		char[] arr = s.ToArray();
		
		if (s.Length == 2)
		{
			longest = 1;
			founds.Add(1, s.Substring(0,1));
		}
		
		for (int i = 0; i < s.Length; i++)
		{
			checkOddPalin(i, arr, founds);
		}
		
		for (int i = 0; i < s.Length; i++)
		{
			checkEvenPalin(i, s, founds);
		}
		
		//founds.Dump();
		
		if(longest > 0) {
			return founds[longest];
		}
		
		return null;
	}

	int checkOddPalin(int startIndex, char[] arr, Dictionary<int, string> founds)
	{
		for (int i = startIndex + 1, j = startIndex-1; i < arr.Length+1 && j >=-1; i++, j--)
		{
			if(i<arr.Length && j>=0 && arr[i] == arr[j]) 
			{
				// keep doing it
			} 
			else 
			{
				i--;
				j++;
				int length = (i - j + 1);
				if (length > 0 && !founds.ContainsKey(length) && length > longest)
				{
					longest = length;
					founds.Add(length, new string(arr, j, length));
				}
				break;
			}
		}
		return 0;
	}

	int checkEvenPalin(int startIndex, string src, Dictionary<int, string> founds)
	{
		char[] arr = src.ToArray();
		for (int i = startIndex + 1, j = startIndex; i < arr.Length +1 && j >= -1; i++, j--)
		{
			if (i<arr.Length && j>=0 && arr[i] == arr[j])
			{
				// keep doing it
			}
			else
			{
				i--;
				j++;
				int length = (i - j + 1);
				if (length > 0 && !founds.ContainsKey(length) && length > longest){
					longest = length;
					founds.Add(length, new string(arr, j, length));
				}
				break;
			}
		}
		return 0;
	}
}

// Define other methods and classes here
