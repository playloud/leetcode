<Query Kind="Program" />

// PSH 09/23/18 : passed, 22.07% 
void Main()
{
    List<Interval> input = new List<UserQuery.Interval>();
    input.Add(new Interval(1, 3));
    input.Add(new Interval(2, 6));
    input.Add(new Interval(8, 10));
    input.Add(new Interval(15, 18));
    
    Solution sol = new Solution();
    sol.Merge(input).Dump();
}

// Define other methods and classes here
public class Interval
{
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
}
public class Solution
{
    public IList<Interval> Merge(IList<Interval> intervals)
    {
        List<Interval> results = new List<Interval>();
        
        Dictionary<int, Interval> dic = new Dictionary<int, Interval>();
        
        // build hashtable
        for (int i = 0; i < intervals.Count; i++)
        {
            int key = intervals[i].start;
            
            if(dic.ContainsKey(key))
            {
                Interval found = (Interval)dic[key];
                Interval merged = MergeTwo(found, intervals[i]);
                dic.Remove(found.start);
                dic.Add(merged.start, merged);
            }
            else
            {
                dic.Add(intervals[i].start, intervals[i]);
            }
        }
        
        bool cond = true;
        while(cond)
        {
            cond = false;
            foreach (int key in dic.Keys)
            {
                Interval curObj = dic[key];
                
                // now find objects
                int min = curObj.start;
                int max = curObj.end;
                var query = dic.Keys.Where(a=> a != key && min <= a && a <= max);
                
                // if there is mergable objects, then 
                if(query.Any())
                {
                    Interval target = dic[query.Take(1).First()];
                    Interval merged = MergeTwo(curObj, target);
                    
                    dic.Remove(curObj.start);
                    dic.Remove(target.start);
                    dic.Add(merged.start, merged);
                    cond = true;
                    break;
                }
            }
            
        }
        results.AddRange(dic.Values);
        return results;
    }
    
    public Interval MergeTwo(Interval a, Interval b)
    {
        Interval merged = new Interval();
        
        merged.start = Math.Min(a.start, b.start);
        merged.end = Math.Max(a.end, b.end);
        
        return merged;
    }
    
    public bool IsMergable(Interval a, Interval b)
    {
        if(a.start <= b.start && b.start <= a.end)
            return true;
        
        if(b.start <= a.start && a.start <= b.end)
            return true;
        
        return false;
    }
    
}