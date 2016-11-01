using System;
using System.Text;

namespace LeetCodeSolutions
{
	public class StringToInteger
	{
		public StringToInteger()
		{

			Console.WriteLine(MyAtoi("  -0012a42"));
		}

		public int MyAtoi(string str)
		{

			int value = 0;

			long longValue = 0;

			if (long.TryParse(str, out longValue))
			{
				if (longValue > int.MaxValue)
					return int.MaxValue;
				if (longValue < int.MinValue)
					return int.MinValue;
			}


			if (int.TryParse(str, out value))
				return value;

			StringBuilder sbuf = new StringBuilder();
			char[] arr = str.Trim().ToLower().ToCharArray();
			for (int i = 0; i < arr.Length; i++)
			{
				if (IsAlphabet(arr[i]) || arr[i]==' ')
					break;
				sbuf.Append(arr[i]);
			}

			str = sbuf.ToString();

			if (long.TryParse(str, out longValue))
			{
				if (longValue > int.MaxValue)
					return int.MaxValue;
				if (longValue < int.MinValue)
					return int.MinValue;
			}

			if (int.TryParse(str, out value))
				return value;

			if (str.StartsWith("-"))
			{
				if (str.Length > int.MinValue.ToString().Length)
					return int.MinValue;
			}
			else 
			{
				if (str.Length > int.MaxValue.ToString().Length)
					return int.MaxValue;
			}

			return 0;
		}

		public bool IsAlphabet(char c)
		{
			if (c >= 'a' && c <= 'z')
				return true;
			return false;
		}
	}
}
