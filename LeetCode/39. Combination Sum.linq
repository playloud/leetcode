<Query Kind="Program" />

//PSH 09/15/18 14:06:36 : passed 
void Main()
{
    Solution sol = new Solution();
    int[] input = {2,3,6,7};
    int target = 7;
    
    sol.CombinationSum(input, target).Dump();

    int[] input2 = { 2, 3, 5 };
    int target2 = 8;
    
    sol.CombinationSum(input2, target2).Dump();

}

// Define other methods and classes here
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> temp = new List<int>();
        
        if(candidates != null && candidates.Length > 0)
            FindDupSets(temp, result, 0, candidates, target);
        
        return result;
    }
    
    public void FindDupSets(List<int> current, List<IList<int>> global, int startIndex, int[] src, int target)
    {
        
        for (int i = startIndex ; i < src.Length; i++)
        {
            current.Add(src[i]);
            if(current.Sum() == target)
            {
                List<int> foundResult = new List<int>();
                foundResult.AddRange(current);
                global.Add(foundResult);
            }
            else if(current.Sum() < target)
            {
                FindDupSets(current, global, i, src, target);
            }
            
            if(current.Count > 0)
                current.RemoveAt(current.Count-1);
        }
        
    }
}