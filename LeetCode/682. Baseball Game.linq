<Query Kind="Program" />

void Main()
{
	string[] input = { "5", "2", "C", "D", "+" };
	string[] input2 = { "5", "-2", "4", "C", "D", "9", "+", "+"};
	(new Solution()).CalPoints(input2).Dump();
}


// Define other methods and classes here
public class Solution
{
	public int CalPoints(string[] ops)
	{
		int?[] scores = new int?[ops.Length];
		int sum = 0;
		
		for (int i = 0; i < ops.Length; i++)
		{
			string src = ops[i];
			int val = 0;
			
			if(int.TryParse(src, out val))
			{
				scores[i] = val;
				sum += val;
			}
			else if(src == "C")
			{
				val = GetLastValidandInvalid(scores, i);
				scores[i] = null;
				sum -= val;
			}
			else if (src == "D")
			{
				val = GetLastValid(scores, i) * 2;
				scores[i] = val;
				sum += val;
			}
			else if(src == "+")
			{
				val = GetSumOfLastTwoValid(scores, i);
				scores[i] = val;
				sum += val;
			}
		}
		return sum;
	}
	
	public int GetLastValid(int?[] scors, int currentIndex)
	{
		for (int i = currentIndex-1; i >=0; i--)
		{
			if(scors[i] != null)
				return scors[i].Value;
		}
		return 0;
	}
	
	public int GetSumOfLastTwoValid(int?[] scors, int currentIndex)
	{
		int sum = 0;
		int? val1 = null;
		int? val2 = null;
		for (int i = currentIndex - 1; i >= 0; i--)
		{
			if (scors[i] != null)
			{
				if(val1 == null)
					val1 = scors[i];
				else if(val2 == null)
					val2 = scors[i];
			}
			
			if(val1 != null && val2 != null)
				break;
		}
		if(val1 != null && val2 != null)
			sum = val1.Value + val2.Value;
		return sum;
	}
	
	public int GetLastValidandInvalid(int?[] scors, int currentIndex)
	{
		int val = 0;
		for (int i = currentIndex - 1; i >= 0; i--)
		{
			if (scors[i] != null)
			{
				val = scors[i].Value;
				scors[i] = null;
				break;
			}
		}
		return val;
	}
	
}