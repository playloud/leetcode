<Query Kind="Program" />

void Main()
{
    Solution sol = new Solution();
    sol.FindCelebrity(3).Dump();
    
}

// Define other methods and classes here
/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Relation
{
    public bool Knows(int a, int b)
    {
        // passed
        //        if(a==0 && b==1) return true;
        //        if (a == 1 && b == 0) return false;

//        if (a == 0 && b == 1) return false;
//        if (a == 1 && b == 2) return false;
//        if (a == 2 && b == 0) return false;
//        if (a == 0 && b == 2) return true;
//        if (a == 1 && b == 0) return true;
//        if (a == 2 && b == 1) return true;
        
//        if (a == 0 && b == 1) return true;
//        if (a == 1 && b == 0) return false;

// return -1
//        if (a == 0 && b == 1) return false;
//        if (a == 0 && b == 2) return true;
//        
//        if (a == 1 && b == 0) return true;
//        if (a == 1 && b == 2) return false;
//        
//        if (a == 2 && b == 0) return false;
//        if (a == 2 && b == 1) return true;

		// return 2
		if (a == 0 && b == 1) return true;
		if (a == 0 && b == 2) return true;
		if (a == 1 && b == 0) return true;
		if (a == 1 && b == 2) return false;
		if (a == 2 && b == 0) return false;
		if (a == 2 && b == 1) return false;

		return false;
    }
}

public class Solution : Relation
{
	public int FindCelebrity(int n)
	{
		int result = -1;
		
		List<int> people = new List<int>();
		
		people.AddRange(Enumerable.Range(0, n));
		
		int a = 0;
		int b = 0;
		
		List<int>celeb = new List<int>();
		
		for (int i = 0; i < people.Count; i++)
		{
			bool IsKnow = false;
			a = people.IndexOf(i);
			for (int j = 0; j < people.Count; j++)
			{
				if(i==j) continue;
				b = people.IndexOf(j);
				if (Knows(a, b))
				{
					IsKnow = true;
					break;
				}

			}
			if (!IsKnow)
			{
				celeb.Add(a);
				if(celeb.Count > 1)
					return -1;
			}
		}
		
		if(celeb.Count == 1)
			return celeb[0];
		
		return result;
	}
}

public class Solution2 : Relation
{
	public int FindCelebrity(int n)
    {
        
        int result = -1;
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++)
            q.Enqueue(i);
        
        int a = 0;
        int b = 0;
        
        while(q.Count > 1)
        {
			Queue<int> nextQ = new Queue<int>();
            int initialQCount = q.Count;

			a = q.Dequeue();
			b = q.Dequeue();
			
			bool r1 = Knows(a,b);
            bool r2 = Knows(b,a);
            
            if(r1 && r2)
            {
                // both out
            }
            else if(!r1 && r2)
            {
				nextQ.Enqueue(a);
            } 
            else if(r1 && !r2)
            {
				//maybe b 
                nextQ.Enqueue(b);
            } 
            else if(!r1 && !r2)
            {
                nextQ.Enqueue(a);
				nextQ.Enqueue(b);
            }
			
			if(q.Count > 0)
			{
				q.ToList().ForEach(i => nextQ.Enqueue(i));
			}
			
			// loop found
			if(nextQ.Count == initialQCount)
				return -1;
			
			q = nextQ;
        }
        
        if(q.Count == 1)
            result = q.Dequeue();
        
        return result;
    }
}