<Query Kind="Program" />

//PSH 01/26/20 23:49:44 Sunday
//https://leetcode.com/problems/plus-one/
void Main()
{
	int[] test = {9, 9, 8};
	(new Solution()).PlusOne(test).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] PlusOne(int[] digits)
	{
		bool hasOverFlow = false;
		
		for (int i = digits.Length-1; i>=0; i--)
		{
			int d = digits[i];
			
			if(i == digits.Length -1 || hasOverFlow)
				d++;
			
			if(d > 9) 
			{
				if(i == 0) 
				{
					digits[i] = 0;
					int[] newOne = new int[digits.Length+1];
					newOne[0] = 1;
					Array.Copy(digits, 0, newOne, 1, digits.Length);
					return newOne;
				}
				else
				{
					digits[i] = 0;
					hasOverFlow = true;
				}				
			} else 
			{
				digits[i] = d;
				hasOverFlow = false;
			}
		}
		
		return digits;
	}
}

public class Solution_BAD
{
	public int[] PlusOne(int[] digits)
	{
		StringBuilder sbuf = new StringBuilder();
		foreach (int e in digits)
		{
			sbuf.Append(e);
		}

		int temp = int.Parse(sbuf.ToString());
		temp++;
		string temp2 = temp.ToString();
		List<int> result = new List<int>();

		foreach (char e in temp2.ToArray())
		{
			result.Add(int.Parse(e + ""));
		}

		return result.ToArray();
	}
}