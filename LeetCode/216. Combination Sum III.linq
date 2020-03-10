<Query Kind="Program" />

/*
Find all possible combinations of k numbers that add up to a number n, 
given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

<<Note:>>
All numbers will be positive integers.
The solution set must not contain duplicate combinations.
*/
// PSH 09/15/18 : passed, 65.43%
void Main()
{
    Solution sol = new Solution();
    sol.CombinationSum3(3,7).Dump();
    sol.CombinationSum3(3,9).Dump();
    
}

// Define other methods and classes here
public class Solution
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        IList<IList<int>> result = new List<IList<int>>();
        int[] src = Enumerable.Range(1,9).ToArray();
        bool[] trails = Enumerable.Repeat(false, src.Length).ToArray();
        List<int> temp = new List<int>();
        BackTrack(temp, result, trails, n, src, k, 0);
        return result;
    }
    
    public void BackTrack(List<int> current, IList<IList<int>> global, bool[] trails, int total, int[] src, int listMaxLength, int startIndex)
    {
        for (int i = startIndex; i < src.Length; i++)
        {
            if(trails[i])
                continue;
            
            trails[i] = true;
            current.Add(src[i]);
            int val = src[i];
            
            if( (total - val) == 0 && current.Count == listMaxLength)
            {
                // found it, just copying it
                global.Add(current.ToList());
                
            }
            else if( total - val > 0 && current.Count < listMaxLength && i < src.Length-1)
            {
                BackTrack(current, global, trails, total - val, src, listMaxLength, i+1);
            }
            
            // remove last
            current.RemoveAt(current.Count - 1);
            trails[i] = false;
            
            
        }
        
    }
}