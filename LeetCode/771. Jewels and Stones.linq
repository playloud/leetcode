<Query Kind="Program" />

void Main()
{
	string J = "aA";
	string S = "aAaabbbb";
	
	(new Solution()).NumJewelsInStones(J,S).Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public int NumJewelsInStones(string J, string S)
	{
		char[] jArr = J.ToCharArray();
		char[] src = S.ToCharArray();
		
		int result = 0;

		jArr.ToList().ForEach(a => {
			result += src.Count(c=>a ==c);
		});
		
		return result;
	}
}