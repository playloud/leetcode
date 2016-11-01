using System;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeSolutions
{
	public class ThreeSumCloeset_Solution
	{
		public ThreeSumCloeset_Solution()
		{

			int[] temp = { 2,3, 6,7,8, 23};
			int target = 100;

			Console.WriteLine(GetNearest(temp, target));

		}

		public int ThreeSumClosest(int[] nums, int target)
		{
			//Array.Sort(nums);

			//int a, b, c, prevSum, prevDiff;

			//while (true)
			//{

			//}

			return 0;
		}

		public int GetNearest(int[] nums, int target)
		{
			int startIndex, endIndex, curIndex;

			startIndex = 0;
			endIndex = nums.Length - 1;


			while (true)
			{
				curIndex = (endIndex + startIndex) / 2;

				if (curIndex == startIndex || curIndex == endIndex)
					return FindNearest(target, nums[startIndex], nums[endIndex]);

				if((startIndex+1) == curIndex && curIndex == (endIndex-1))
					return FindNearest(target, nums[startIndex],  nums[curIndex], nums[endIndex]);

				if (target < nums[curIndex])
				{
					endIndex = curIndex;
				}
				else if (target > nums[curIndex])
				{
					startIndex = curIndex;
				}
				else if (target == nums[curIndex])
				{
					return target;
				}
			}
		}

		int FindNearest(int target, int v1, int v2)
		{
			int difference1 = Math.Abs(target - v1);
			int difference2 = Math.Abs(target - v2);

			if (difference1 <= difference2)
				return v1;

			if (difference2 <= difference1)
				return v2;

			return target;
		}

		int FindNearest(int target, int v1, int v2, int v3)
		{
			int[] arr = {v1, v2, v3 };
			var query = arr.Select((v, i) => new { diff = Math.Abs(target - v), i}).OrderBy(a => a.diff).First();
			return arr[query.i];
		}
	}
}
