using System;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeSolutions
{
	// leet code passed!! 
	public class LetterCombinations_17
	{
		public LetterCombinations_17()
		{


		}

		public void Test()
		{
			IList<string> result = LetterCombinations("23");

			foreach(string str in result)
				Console.WriteLine(str);
		}


		public IList<string> LetterCombinations(string digits)
		{
			IList<string> result = new List<string>();

			char[] arr = digits.ToCharArray();
			char[][] source = new char[digits.Length][];

			// build source
			for (int i = 0; i < digits.Length; i++)
			{
				source[i] = GetDigit(arr[i]);
			}

			// start calc
			if(digits.Length > 0)
				Calc(0, digits.Length - 1, "", source, result);

			return result;
		}

		public void Calc(int level, int maxLevel, string head, char[][] src, IList<string> result)
		{
			int next = level+1;



			char[] curGroup = src[level];
			for (int i = 0; i < curGroup.Length; i++)
			{
				string temp = head + curGroup[i];

				if(level == maxLevel)
					result.Add(temp);

				if(next <= maxLevel)
					Calc(next, maxLevel, temp, src, result);
			}

		}

		public char[] GetDigit(char num)
		{
			if(num == '2')
				return new char[]{ 'a','b', 'c' };

			if (num == '3')
				return new char[] { 'd', 'e', 'f' };

			if (num == '4')
				return new char[] { 'g', 'h', 'i' };

			if (num == '5')
				return new char[] { 'j', 'k', 'l' };

			if (num == '6')
				return new char[] { 'm', 'n', 'o' };

			if (num == '7')
				return new char[] { 'p', 'q', 'r','s' };

			if (num == '8')
				return new char[] {'t', 'u','v' };

			if (num == '9')
				return new char[] {'w', 'x','y','z' };

			return new char[] { };
		}

	}
}
