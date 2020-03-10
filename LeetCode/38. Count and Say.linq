<Query Kind="Program" />

void Main()
{
	Solution sol = new Solution();
	for (int i = 0; i < 15; i++)
	{
		Console.WriteLine ("{0} : {1}", i, sol.CountAndSay(i));
	}


}

// Define other methods and classes here
public class Solution {
    public string CountAndSay(int n) {
		
		if(n <= 0)
			return null;
		if(n == 1)
			return "1";
		
		string result = null;
		StringBuilder sbuf = new StringBuilder();
		
		
		Queue<string> queue = new Queue<string>();
		queue.Enqueue("1");
		for (int i = 1; i < n; i++)
		{
			Queue<string> tempQueue = new Queue<string>();
			while(queue.Count > 0)
			{
				int count = 0;
				string cur = queue.Dequeue();
				count++;
				while(queue.Count > 0 && queue.Peek() == cur)
				{
					queue.Dequeue();
					count++;
				}
				tempQueue.Enqueue(count.ToString());
				tempQueue.Enqueue(cur);
			}
			queue = tempQueue;
			//queue.Dump();
		}
		queue.ToList().ForEach(a=>sbuf.Append(a));
		return sbuf.ToString();
    }
}