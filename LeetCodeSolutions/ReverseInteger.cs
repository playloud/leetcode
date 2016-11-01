using System;
using System.Linq;

namespace LeetCodeSolutions
{
	public class ReverseInteger
	{

		public void Test()
		{
			Console.WriteLine(Reverse(-123)); 
			Console.WriteLine(Reverse(-2147483648));
			Console.WriteLine(Reverse(1534236469));


		}

		public int Reverse(int x)
		{
			if (x < int.MinValue || x > int.MaxValue)
				return 0;

			bool IsMinus = x < 0;

			if (IsMinus)
				x = -1 * x;

			string temp = new string(x.ToString().Reverse().ToArray());

			int result = 0;
			if (!int.TryParse(temp, out result))
				return 0;

			if (IsMinus)
				result = -1 * result;

			return result;
		}
	}
}
