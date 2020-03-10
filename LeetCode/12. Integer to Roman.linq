<Query Kind="Program" />

//https://leetcode.com/problems/integer-to-roman/
//Runtime: 104 ms, faster than 39.45% of C# online submissions for Integer to Roman.
//PSH 03/08/20 15:52:16 Sunday
void Main()
{
	(new Solution()).IntToRoman(3450).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string IntToRoman(int num)
	{
		StringBuilder sbuf = new StringBuilder();
		StringBuilder temp = new StringBuilder();
		
		string numStr = num.ToString();
		char[] arr = numStr.ToCharArray();
		
		Stack<int> stack = new Stack<int>();
		foreach (char c in arr)
		{
			stack.Push(int.Parse(c+""));
		}

		// one
		if (stack.Count > 0)
		{
			temp.Clear();
			int one = stack.Pop();
			if (one != 0)
			{
				if (one < 4)
				{
					for (int i = 0; i < one; i++)
					{
						temp.Append("I");
					}
				}
				else if(one == 4)
				{
					temp.Append("IV");
				}
				else if (one == 5)
				{
					temp.Append("V");
				}
				else if (one > 5 && one <= 8)
				{
					temp.Append("V");
					for (int i = 0; i < one - 5; i++)
					{
						temp.Append("I");
					}
				}
				else if (one == 9)
				{
					temp.Append("IX");
				}
				
				//sbuf.Append(temp.ToString(), 0, temp.Length);
				//AppendFront(sbuf, temp.ToString());
				sbuf.Insert(0,temp.ToString());
			}
		}
		
		// tenth
		if (stack.Count > 0)
		{
			temp.Clear();
			int tenth = stack.Pop();
			if (tenth != 0)
			{
				if (tenth < 4)
				{
					for (int i = 0; i < tenth; i++)
					{
						temp.Append("X");
					}
				}
				else if (tenth == 4)
				{
					temp.Append("XL");
				}
				else if (tenth == 5)
				{
					temp.Append("L");
				}
				else if (tenth > 5 && tenth <= 8)
				{
					temp.Append("L");
					for (int i = 0; i < tenth - 5; i++)
					{
						temp.Append("X");
					}
				}
				else if (tenth == 9)
				{
					temp.Append("XC");
				}
				sbuf.Insert(0,temp.ToString());
			}
		}


		// hundred
		if (stack.Count > 0)
		{
			temp.Clear();
			int hundred = stack.Pop();
			if (hundred != 0)
			{
				if (hundred < 4)
				{
					for (int i = 0; i < hundred; i++)
					{
						temp.Append("C");
					}
				}
				else if (hundred == 4)
				{
					temp.Append("CD");
				}
				else if (hundred == 5)
				{
					temp.Append("D");
				}
				else if (hundred > 5 && hundred <= 8)
				{
					temp.Append("D");
					for (int i = 0; i < hundred - 5; i++)
					{
						temp.Append("C");
					}
				}
				else if (hundred == 9)
				{
					temp.Append("CM");
				}
				//sbuf.Append(temp.ToString(), 0, temp.Length);
				sbuf.Insert(0,temp.ToString());
			}
		}

		// thousand
		if (stack.Count > 0)
		{
			temp.Clear();
			int thousand = stack.Pop();
			if (thousand != 0)
			{
				if (thousand < 4)
				{
					for (int i = 0; i < thousand; i++)
					{
						temp.Append("M");
					}
				}
				//sbuf.Append(temp.ToString(), 0, temp.Length);
				sbuf.Insert(0,temp.ToString());
			}
		}

		return sbuf.ToString();
	}
	
	
}