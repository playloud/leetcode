<Query Kind="Program" />

void Main()
{
	//	char[] letters = {'a','b','c','d','f','h','j','k','l'};
	//	char target = 'm';
	//	(new Solution()).NextGreatestLetter(letters, target).Dump();


	char[] letters = { 'c', 'f', 'j' };
	//char[] letters = {'e','e','e','e','e','e','n','n','n','n'};
	char target = 'a';
	(new Solution()).NextGreatestLetter(letters, target).Dump();

//	char[] letters = { 'a', 'b', 'c', 'd', 'f', 'h', 'j', 'k', 'l' };
//	char target = 'm';
//	(new Solution()).NextGreatestLetter(letters, target).Dump();
//
//	char[] letters = { 'a', 'b', 'c', 'd', 'f', 'h', 'j', 'k', 'l' };
//	char target = 'm';
//	(new Solution()).NextGreatestLetter(letters, target).Dump();
//
//	char[] letters = { 'a', 'b', 'c', 'd', 'f', 'h', 'j', 'k', 'l' };
//	char target = 'm';
//	(new Solution()).NextGreatestLetter(letters, target).Dump();

}

// Define other methods and classes here
public class Solution
{
	public char NextGreatestLetter(char[] letters, char target)
	{
		int result = Array.BinarySearch(letters, target);
		
		if(result >=0)
		{
			result++;
			if(result == letters.Length)
				return letters[0];
			
			//return letters[result];
			return CheckSameChar(letters,target,result);
		}
		else if (result <0)
		{
			if(result == -1)
			{
				return letters[0];
				//return CheckSameChar(letters,target,result);
			}
			
			result = result * -1;
			if(result > letters.Length)
			{
				return letters[0];
			}


			//return letters[--result];
			return CheckSameChar(letters,target,--result);

		}
		return letters[0];
	}
	
	public char CheckSameChar(char[] letters, char target, int index)
	{
		for (int i = index; i < letters.Length; i++)
		{
			if(letters[i] != target)
				return letters[i];
		}
		return letters[0];
	}
	
	
}