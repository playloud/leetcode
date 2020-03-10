<Query Kind="Program" />

/**
Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sums to target. Each number in candidates may only be used once in the combination.
MUST NOT CONTAIN DUP LISTS
*/
// PSH 09/15/18 : accepted 1.58% -_-
void Main()
{
    Solution sol = new Solution();
    int[] input = { 10,1,2,7,6,1,5 };
    int target = 8;

    sol.CombinationSum2(input, target).Dump();

    int[] input2 = {2,5,2,1,2 };
    int target2 = 5;

    sol.CombinationSum2(input2, target2).Dump();
}

// Define other methods and classes here
public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> temp = new List<int>();
        
        Array.Sort(candidates);
        
        HashSet<string> resultHash = new HashSet<string>();
        
        if (candidates != null && candidates.Length > 0)
            FindUniqueSets(temp, result, 0, candidates, target, resultHash);
        
        return result;
    }

    public void FindUniqueSets(List<int> current, List<IList<int>> global, int startIndex, int[] src, int target, HashSet<string> resultHash)
    {
        
        for (int i = startIndex; i < src.Length; i++)
        {
            current.Add(src[i]);
            if (current.Sum() == target)
            {
                // found result => save it!
                List<int> foundResult = new List<int>();
                foundResult.AddRange(current);
                
                if(!resultHash.Contains(GetHash(foundResult)))
                {
                    resultHash.Add(GetHash(foundResult));
                    global.Add(foundResult);
                }
            }
            else if (current.Sum() < target)
            {
                if(i < src.Length-1)
                    FindUniqueSets(current, global, i+1, src, target, resultHash);
            }

            if (current.Count > 0)
                current.RemoveAt(current.Count - 1);
        }
    }
    
    public string GetHash(List<int> input)
    {
        input.Sort();
        return string.Join("_",input);
    }
}



