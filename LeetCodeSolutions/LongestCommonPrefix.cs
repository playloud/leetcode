using System;
using System.Text;
using System.Linq;

namespace LeetCodeSolutions
{
	public class LongestCommonPrefix
	{
		public LongestCommonPrefix()
		{
		}

		public string Sol(string[] strs)
		{

			string shortOne = strs.OrderBy(a => a.Length).FirstOrDefault();
			StringBuilder sbuf = new StringBuilder();

			if (strs == null || strs.Length == 0)
				return string.Empty;

			for (int i = 0; i < shortOne.Length; i++)
			{
				char c = shortOne.ElementAt(i);
				for (int j = 0; j < strs.Length; j++)
				{
					if (strs[j].ElementAt(i) != c)
						return sbuf.ToString();
				}
				sbuf.Append(c);
			}
			return sbuf.ToString();
		}
	}
}
