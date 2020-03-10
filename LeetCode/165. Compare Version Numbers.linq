<Query Kind="Program" />

//PSH 09/26/18 23:30:07, passed 94.89%
void Main()
{
    Solution sol = new Solution();
    sol.CompareVersion("0.0.1.1", "0.0.1").Dump();
}

// Define other methods and classes here
public class Solution
{
    public int CompareVersion(string version1, string version2)
    {
        
        Queue<int> qv1 = new Queue<int>();
        Queue<int> qv2 = new Queue<int>();

        char[] sepa = {'.'};
        string[] arr1 = version1.Split(sepa);
        string[] arr2 = version2.Split(sepa);

        foreach (string s in arr1)
            if(!string.IsNullOrEmpty(s))
                qv1.Enqueue(int.Parse(s));

        foreach (string s in arr2)
            if(!string.IsNullOrEmpty(s))
                qv2.Enqueue(int.Parse(s));
        
        while(qv1.Count >0 || qv2.Count > 0)
        {
            int v1 = 0;
            int v2 = 0;
            
            if(qv1.Count >0)
                v1 = qv1.Dequeue();

            if (qv2.Count > 0)
                v2 = qv2.Dequeue();
            
            if(v1 > v2)
                return 1;
            else if(v1 < v2)
                return -1;
            
        }

        return 0;

    }
}