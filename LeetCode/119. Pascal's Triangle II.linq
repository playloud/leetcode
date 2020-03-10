<Query Kind="Program" />

void Main()
{
	(new Solution()).GetRow(10).Dump();
}

// working
// 24-JUL-2017
public class Solution
{
	public IList<int> GetRow(int rowIndex)
	{

		if (rowIndex == 0)
		{
			List<int> temp = new List<int>();
			temp.Add(1);
			return temp;
		}
		
		ArrayList current = new ArrayList();
		ArrayList prev = new ArrayList();
		
		prev.Add(1);
		
		for (int i = 0; i < rowIndex; i++)
		{
			
			current.Add(1);
			for (int j = 0; j < prev.Count - 1; j++)
			{
				current.Add((int)prev[j] + (int)prev[j+1]);
			}
			current.Add(1);
			
			if(i==rowIndex-1)
				return current.ToArray().Select(A=> (int)A).ToList();
			
			prev = current;
			current = new ArrayList();
		}
		return null;
	}
}