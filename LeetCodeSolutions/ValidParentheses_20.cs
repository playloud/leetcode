using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LeetCodeSolutions
{
	public class ValidParentheses_20
	{
		/// <summary>
		/// Passed at Nov 29 2016
		/// </summary>
		public ValidParentheses_20()
		{

			//string str = "";

			//Console.WriteLine(str);
			//Console.WriteLine(IsValid(str));
			while (true)
			{
				Console.WriteLine(IsValid(Console.ReadLine()));
			}
		}


		public bool IsValid(string s)
		{
			char[] arr = s.ToCharArray();
			Stack<char> stack = new Stack<char>();

			foreach (var c in arr)
			{

				if (c == '{' || c == '[' || c == '(')
				{
					stack.Push(c);
				}
				else if (c == '}')
				{
					if (stack.Count == 0 || stack.Pop() != '{')
						return false;
				}
				else if (c == ']')
				{
					if (stack.Count == 0 || stack.Pop() != '[')
						return false;
				}
				else if (c == ')')
				{
					if (stack.Count == 0 || stack.Pop() != '(')
						return false;
				}
			}

			if (stack.Count > 0)
				return false;

			return true;
		}

	}
}
