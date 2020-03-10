<Query Kind="Program" />

void Main()
{
	//int[] cost = {10, 15, 20};	
	int[] cost = {1, 100, 1, 1, 1, 100, 1, 1, 100, 1};	
	(new Solution()).MinCostClimbingStairs(cost).Dump();
	
	
}

// Define other methods and classes here
public class Solution
{
	public int MinCostClimbingStairs(int[] cost)
	{
		Hashtable buffer = new Hashtable();
		return GetMinCost(cost.Length, cost, buffer);
	}
	
	public int GetMinCost(int step, int[] cost, Hashtable buffer)
	{
		
		if(step == 0)
			return cost[0];
		
		if(step == 1)
			return cost[1];
		
		int prevCost = 0;
		int prevPrevCost = 0;
		
		if(buffer.ContainsKey(step -1))
			prevCost = (int)buffer[step-1];
		else
			prevCost = GetMinCost(step-1, cost, buffer);

		if (buffer.ContainsKey(step - 2))
			prevPrevCost = (int)buffer[step - 2];
		else
			prevPrevCost = GetMinCost(step - 2, cost, buffer);
		
		int myCost = 0;
		if(step < cost.Length)
			myCost = cost[step];
		
		int minCost = myCost + Math.Min(prevCost, prevPrevCost);
		
		if(!buffer.ContainsKey(step))
			buffer.Add(step, minCost);
		
		return minCost;
	}
}