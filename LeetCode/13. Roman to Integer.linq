<Query Kind="Program" />

//https://leetcode.com/problems/roman-to-integer/
//PSH 03/08/20 01:49:10 Sunday passed, 61.52%
//
void Main()
{
	(new Solution().RomanToInt("LXVIII")).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int RomanToInt(string s)
	{
		
		int result = 0;
		
		char[] arr = s.Trim().ToLower().ToArray();
		Stack<char> stack = new Stack<char>();
		foreach (char c in arr)
		{
			stack.Push(c);
		}
		
		
		int lastInput = 0;
		while(stack.Count > 0)
		{
			char c = stack.Pop();
			int curValue = RcharToInt(c);
			if(lastInput <= curValue)
			{
				result += curValue;
			}
			else 
			{
				result -= curValue;
			}
			
			lastInput = curValue;
			
		}
		
		
		return result;
		
		
	}
	
	
	public int RcharToInt(char c)
	{
		switch(c)
		{
			case 'i' :
				return 1;
			case 'v' : 
				return 5;
			case 'x':
				return 10;
			case 'l':
				return 50;
			case 'c':
				return 100;
			case 'd':
				return 500;
			case 'm':
				return 1000;
			default:
				return 0;

		}
		
	}
	
}