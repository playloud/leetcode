<Query Kind="Program" />

void Main()
{
	(new Solution()).CountPrimes(345663456).Dump();
	 
}

// Define other methods and classes here
public class Solution
{
	public int CountPrimes(int n)
	{	
		int count = 0;
		for (int i = 1; i <= n; i++)
		{
			if(IsPrime(i))
			{
				count++;
				//Console.WriteLine(i);
			}
		}
		
		return count;
	}
	
	public bool IsPrime(int n)
	{
		if(n==1)
			return false;
			
		if(n==2 || n==3 || n==5||n==7||n==11)
			return true;
			
		
		if (n % 2 == 0)
			return false;

		if (n % 3 == 0)
			return false;

		if (n % 5 == 0)
			return false;

		if (n % 7 == 0)
			return false;

		if (n % 11 == 0)
			return false;
		
		int i = 5;
		int w = 2;
		while (i * i <= n)
		{
			if (n % i == 0)
	           	return false;
			i += w;
			w = 6 - w;
		}
		return true;
	}
	
	
}