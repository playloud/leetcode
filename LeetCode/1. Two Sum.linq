<Query Kind="Program" />

/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.

Key is using hashtable. Narrowing down the result with the soltion of the life. 

*/
// PSH 09/15/18 : passed, 99.68%
void Main()
{
    int[] input = {2, 7, 11, 15};
    int target = 18;
    Solution sol = new Solution();
    sol.TwoSum(input, target).Dump();
    
}

// Define other methods and classes here
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // key : num, value : index
        Dictionary<int, int> dic = new Dictionary<int, int>();
        
        List<int> result = new List<int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if(dic.ContainsKey((target - num)))
            {
                result.Add( dic[target - num]);
                result.Add(i);
                return result.ToArray();
            }
            else
            {
                if(!dic.ContainsKey(num))
                    dic.Add(num, i);
            }
        }
        
        return result.ToArray();
    }
}