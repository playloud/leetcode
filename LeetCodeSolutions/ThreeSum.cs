using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutions
{
	// 15. 3sum question
	public class ThreeSum
	{
		public ThreeSum()
		{
		}

		public void Test()
		{
			//int[] nums = { -1, 0, 1, 2, -1, -4 };
			int[] nums = { -13,5,13,12,-2,-11,-1,12,-3,0,-3,-7,-7,-5,-3,-15,-2,14,14,13,6,-11,-11,5,-15,-14,5,-5,-2,0,3,-8,-10,-7,11,-5,-10,-5,-7,-6,2,5,3,2,7,7,3,-10,-2,2,-12,-11,-1,14,10,-9,-15,-8,-7,-9,7,3,-2,5,11,-13,-15,8,-3,-7,-12,7,5,-2,-6,-3,-10,4,2,-5,14,-3,-1,-10,-3,-14,-4,-3,-7,-4,3,8,14,9,-2,10,11,-10,-4,-15,-9,-1,-1,3,4,1,8,1};

			int i = 0;
			Solution sol = new Solution();
			foreach (var r in sol.ThreeSum(nums))
			{
				Console.Write(i + " : ");
				foreach (var item in r)
				{
					Console.Write(item+" ");
				}
				Console.WriteLine();
				i++;
			}
		}

		/// <summary>
		/// Pick 3 numbers and make it zero. 
		/// same components alignment not allowed
		/// using linq is not a good idea, timeout exception occurs
		/// </summary>
		/// <param name="nums">Nums.</param>
		// causing time limit exception!
		public IList<IList<int>> Sol1(int[] nums)
		{
			IList<IList<int>> result = new List<IList<int>>();
			var toIndexValue = nums.Select((v, i) => new { v, i });

			var query =
			from a in toIndexValue
			from b in toIndexValue
			from c in toIndexValue
			where
				a.i != b.i &&
				 b.i != c.i &&
				 c.i != a.i &&
				 a.i < b.i &&
				 b.i < c.i &&
				 a.i < c.i &&

				 a.v + b.v + c.v == 0

			select new
			{
				A = a.v,
				B = b.v,
				C = c.v
			};

			if (query.Any())
			{
				foreach (var item in query)
				{
					List<int> temp = new List<int>();
					temp.Add(item.A);
					temp.Add(item.B);
					temp.Add(item.C);

					temp.Sort();

					IList<int> found = temp;

					if (!result.Where(a => a.SequenceEqual(found)).Any())
						result.Add(found);
				}
				return result;
			}
			return result;
		}


}

	public class Solution
	{
		/// <summary>
		/// By sorting, much simpler solution
		/// </summary>
		/// <param name="nums">Nums.</param>
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			IList<IList<int>> result = new List<IList<int>>();
			Array.Sort(nums);
			int[] sorted = nums;
			HashSet<string> hsCheck = new HashSet<string>();

			int[] t3 = new int[3];

			for (int i = 0; i < sorted.Length - 1; i++)
			{
				for (int j = i + 1; j < sorted.Length; j++)
				{
					int sum = sorted[i] + sorted[j];
					if (IsCotainsMinus(sorted, sum, i, j))
					{

						t3[0] = sorted[i];
						t3[1] = sorted[j];
						t3[2] = (sorted[i] + sorted[j]) * -1;

						Array.Sort(t3);

						string keyString01 = string.Format("{0}_{1}_{2}", t3[0], t3[1], t3[2]);

						if (!hsCheck.Contains(keyString01))
						{
							hsCheck.Add(keyString01);
							// found the value
							List<int> temp = new List<int>();
							temp.Add(sorted[i]);
							temp.Add(sorted[j]);
							temp.Add((sorted[i] + sorted[j]) * -1);
							result.Add(temp);
						}
					}
				}
			}

			return result;
		}

		bool IsCotainsMinus(int[] sorted, int sum, int i, int j)
		{

			int foundIndex = Array.BinarySearch(sorted, sum * -1);

			if (foundIndex < 0)
				return false;

			if (foundIndex != i && foundIndex != j)
				return true;

			for (int k = foundIndex; ; k++)
			{
				if (k >= sorted.Length)
					return false;

				if (sorted[k] > (sum * -1))
					break;

				if (k == i || k == j)
					continue;

				if (sorted[k] == (sum * -1))
					return true;
			}
			return false;
		}
	}


}
