<Query Kind="Program" />

void Main()
{
	int[] temperatures = {73, 74, 75, 71, 69, 72, 76, 73};
	
	(new Solution()).DailyTemperatures(temperatures).Dump();
}

public class Solution
{
	public int[] DailyTemperatures(int[] temperatures)
	{
		int[] result = new int[temperatures.Length];
		Dictionary<int, List<int>> dicTemp = new Dictionary<int, System.Collections.Generic.List<int>>();
		int maxTemperature, minTemperature;
		
		maxTemperature = temperatures[0];
		minTemperature = temperatures[0];
		
		// build dictionary
		// key : temperature
		// value : list of index
		for (int i = 0; i < temperatures.Length; i++)
		{
			int temper = temperatures[i];
			if (!dicTemp.ContainsKey(temper))
			{
				var lst = new List<int>();
				lst.Add(i);
				dicTemp.Add(temper, lst);
			}
			else
			{
				dicTemp[temper].Add(i);
			}
			
			if(temper < minTemperature)
				minTemperature = temper;
			
			if(temper > maxTemperature)
				maxTemperature = temper;
		}
		
		//maxTemperature.Dump("max");
		//minTemperature.Dump("min");
		
		for (int i = 0; i < temperatures.Length; i++)
		{
			int currentTemp = temperatures[i];
			result[i] = 0;
			
			if(currentTemp >= maxTemperature)
				result[i] = 0;
			else
			{
				for (int j = i; j < temperatures.Length; j++)
				{
					if (j == i) continue;
					if (temperatures[j] > currentTemp)
					{
						result[i] = j - i;
						break;
					}
				}
			}
		}
		return result;
	}


}