<Query Kind="Program" />

void Main()
{
	(new Solution()).IsPalindrome(",.").Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsPalindrome(string s)
	{
		
		char[] arr = s.ToArray();
		int run = arr.Length /2;
		Queue<char> queue = new Queue<char>();
		Stack<char> stack = new Stack<char>();
		
		int qIndex = -1;
		int sIndex = arr.Length;
		int checkTime = 0;
		
		for (int i = 0; i < arr.Length; i++)
		{
			queue.Enqueue(arr[i]);
			stack.Push(arr[i]);
		}
		
		for (int i = 0; i < run; i++)
		{
			char c1 = ' ', c2 = ' ';
			
			while(queue.Count != 0) 
			{
				c1 = queue.Dequeue();
				qIndex++;
				if(isValidChar(c1))
					break;
			}

			while (stack.Count > 0)
			{
				c2 = stack.Pop();
				sIndex--;
				if (isValidChar(c2))
					break;
			}
			
			if(!isValidChar(c1) && !isValidChar(c2))
				return true;
			
			if (char.ToLower(c1) != char.ToLower(c2))
				return false;
			checkTime++;
		}
		return true;

	}
	
	public bool isValidChar(char c) 
	{
		if(('a' <= c && c <= 'z')  || ('A' <= c && c <= 'Z') || ('0' <= c && c <= '9'))
			return true;
		return false;
	}
}