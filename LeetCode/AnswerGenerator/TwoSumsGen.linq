<Query Kind="Program" />

void Main()
{
	Random rand = new Random();
	
	HashSet<int> set = new HashSet<int>();
	
	for (int i = 0; i < 100; i++)
	{
		int value = rand.Next(0, 1000);
		if(!set.Contains(value))
		{
			set.Add(value);
		}
		
	}
	int[] arr = set.ToArray();
	string result = string.Join(",", arr);
	Console.WriteLine ("[{0}]",result);
	int index1 = rand.Next(0, arr.Length);
	int index2 = rand.Next(0, arr.Length);
	int sum = arr[index1] + arr[index2];
	Console.WriteLine (sum);
	
	Console.WriteLine ("[{0},{1}]", index1, index2);
	
}

// Define other methods and classes here
