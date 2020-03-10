<Query Kind="Program" />

void Main()
{
	TitleToNumber("AB").Dump();
}

// Define other methods and classes here
public int TitleToNumber(string s)
{
	int result = 0;

	if (s != null && s.Length > 0)
	{
		var arr = s.ToCharArray().Reverse().ToList();
		int temp = 0;
		
		foreach (char c in arr)
		{
			result += (int)(((c-'A') +1) *(Math.Pow(26, temp)));
			temp++;
		}
	}
	
	return result;
}