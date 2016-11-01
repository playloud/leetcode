using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
	public class ZigZagStrings
	{
		public ZigZagStrings()
		{


		}

		public void Test()
		{
			//Covert("this is a string", 3);
			Console.WriteLine(Convert("PAYPALISHIRING", 3)); 

		}

		public string Convert(string s, int numRows)
		{
			StringBuilder sbuf = new StringBuilder();

			char[] arr = s.ToCharArray();

			int iter = 0;

			List<char>[] rows = new List<char>[numRows];

			for (int i = 0; i < numRows; i++)
			{
				rows[i] = new List<char>();
			}


			while (iter < arr.Length)
			{
				for (int i = 0; i < numRows; i++)
				{
					if(iter<arr.Length)
						rows[i].Add(arr[iter]);
					//Console.Write(i+" ");
					iter++;
				}

				if (numRows > 2)
				{
					for (int i = numRows - 2; i > 0; i--)
					{
						if (iter < arr.Length)
							rows[i].Add(arr[iter]);
						//Console.Write(i + " ");
						iter++;
					}
				}
			}

			for (int i = 0; i < numRows; i++)
			{
				sbuf.Append(new string(rows[i].ToArray()));
			}

			return sbuf.ToString();
		}
	}


}
