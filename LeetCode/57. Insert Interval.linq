<Query Kind="Program" />

void Main()
{
    List<Interval> input = new List<UserQuery.Interval>();
    input.Add(new Interval() { start = 1, end = 2 });
    input.Add(new Interval() { start = 3, end = 5 });
    input.Add(new Interval() { start = 6, end = 7 });
    input.Add(new Interval() { start = 8, end = 10 });
    input.Add(new Interval() { start = 12, end = 16 });

    Solution sol = new Solution();
    sol.Insert(input, new Interval() {start = 4, end = 8} ).Dump();;
    
}

// Define other methods and classes here
/**
* Definition for an interval.
* public class Interval {
*     public int start;
*     public int end;
*     public Interval() { start = 0; end = 0; }
*     public Interval(int s, int e) { start = s; end = e; }
* }
*/
public class Solution
{
    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
    {
        
        List<Interval> result = new List<Interval>();
        Dictionary<int, Interval> dicS = new Dictionary<int, UserQuery.Interval>();
        Dictionary<int, Interval> dicE = new Dictionary<int, UserQuery.Interval>();
        HashSet<Interval> alls = new HashSet<UserQuery.Interval>();
        
        foreach (Interval itv in intervals)
        {
            dicS.Add(itv.start, itv);
            dicE.Add(itv.end, itv);
            alls.Add(itv);
        }
        
        Interval curItv = null;
        
        curItv = newInterval;
        
        while(true)
        {
            // case 2
            //var queryS = dicS.Keys.Where(s=> curItv.start <= s && s<=curItv.end);
            var queryS = dicS.Where(s=> curItv.start <= s.Key && s.Key<=curItv.end && s.Value != curItv);
            
            // case 1
            //var queryE = dicE.Keys.Where(e=> curItv.start <= e && e<=curItv.end);
            var queryE = dicE.Where(e=> curItv.start <= e.Key && e.Key<=curItv.end && e.Value != curItv);
            
            // case 3 
            var queryAll = alls.Where(a=> a.start<= curItv.start && curItv.end <= a.end);
            
            if(queryS.Any())
            {
                Interval ss = queryS.FirstOrDefault().Value;
                Interval merged = Merge(ss, curItv);
                dicS.Remove(ss.start);
                dicE.Remove(ss.end);
                alls.Remove(ss);
                
                if(!dicS.ContainsKey(curItv.start))
                {
                    dicS.Add(curItv.start, merged);
                    dicE.Add(curItv.end, merged);
                    alls.Add(curItv);
                }
                
                dicS.Add(merged.start, merged);
                dicE.Add(merged.end, merged);
                alls.Add(merged);
                
                curItv = merged;
                continue;
            }

            if (queryE.Any())
            {
                Interval ee = queryE.FirstOrDefault().Value;
                Interval merged = Merge(ee, curItv);
                dicS.Remove(ee.start);
                dicE.Remove(ee.end);
                alls.Remove(ee);

                if (!dicS.ContainsKey(curItv.start))
                {
                    dicS.Remove(curItv.start);
                    dicE.Remove(curItv.end);
                    alls.Remove(curItv);
                }

                dicS.Add(merged.start, merged);
                dicE.Add(merged.end, merged);
                alls.Add(merged);

                curItv = merged;
                continue;
            }
            
            break;






        }
        
        return alls.ToList();
    }
    
    public Interval Merge(Interval a, Interval b)
    {
        Interval merged = new Interval();
        merged.start = Math.Min(a.start, b.start);
        merged.end = Math.Max(a.end, b.end);
        return merged;
    }
}

public class Interval
{
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
}