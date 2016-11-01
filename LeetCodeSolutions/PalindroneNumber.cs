using System;
namespace LeetCodeSolutions
{
	public class PalindroneNumber
	{

		public void Test()
		{
			Console.WriteLine(IsPalindrome(-2147447412));
		}


		public bool IsPalindrome(int x)
		{
			if (x < int.MinValue || x > int.MaxValue)
				return false;

			if (x < 0)
				return false;

			int value = 0;

			if (!int.TryParse(x.ToString(), out value))
				return false;

			if (value < 0)
				value = value * -1;
			
			char[] arr = value.ToString().ToCharArray();
			int i = 0;
			int length = arr.Length;

			if (length == 1)
				return true;
			

			while (i <= length - i - 1)
			{
				if (arr[i] != arr[length - i - 1])
					return false;
				i++;
			}

			return true;
		}

	}
}
