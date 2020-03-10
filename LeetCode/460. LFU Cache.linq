<Query Kind="Program" />

void Main()
{
	
	LFUCache cache = new LFUCache(10 /* capacity */ );
	
	//return;
	
	cache.Put(10, 13);
	cache.Put(3, 17);
	cache.Put(6, 11);
	cache.Put(10, 5);
	cache.Put(9, 10);
	cache.Get(13).Dump();
	cache.Put(2, 19);
	cache.Get(2).Dump();
	cache.Get(3).Dump();
	cache.Put(5, 25);
	cache.Get(8).Dump();
	cache.Put(9, 22);
	cache.Put(5, 5);
	cache.Put(1, 30);
	cache.Get(11).Dump();
	cache.Put(9, 12);
	cache.Get(7).Dump();
	cache.Get(5).Dump();
	cache.Get(8).Dump();
	cache.Get(9).Dump();
	cache.Put(4, 30);
	cache.Put(9, 3);
	cache.Get(9).Dump();
	cache.Get(10).Dump();
	cache.Get(10).Dump();
	cache.Put(6, 14);
	cache.Put(3, 1);
	cache.Get(3).Dump();
	cache.Put(10, 11);
	cache.Get(8).Dump();
	cache.Put(2, 14);
	cache.Get(1).Dump();
	cache.Get(5).Dump();
	cache.Get(4).Dump();
	cache.Put(11, 4);
	cache.Put(12, 24);
	cache.Put(5, 18);
	cache.Get(13).Dump();
	cache.Put(7, 23);
	cache.Get(8).Dump();
	cache.Get(12).Dump();
	cache.Put(3, 27);
	cache.Put(2, 12);
	cache.Get(5).Dump();
	cache.Put(2, 9);
	cache.Put(13, 4);
	cache.Put(8, 18);
	cache.Put(1, 7);
	cache.Get(6).Dump();
	cache.Put(9, 29);
	cache.Put(8, 21);
	cache.Get(5).Dump();
	cache.Put(6, 30);
	cache.Put(1, 12);
	cache.Get(10).Dump();
	cache.Put(4, 15);
	cache.Put(7, 22);
	cache.Put(11, 26);
	cache.Put(8, 17);
	cache.Put(9, 29);
	cache.Get(5).Dump();
	cache.Put(3, 4);
	cache.Put(11, 30);
	cache.Get(12).Dump();
	cache.Put(4, 29);
	cache.Get(3).Dump();
	cache.Get(9).Dump();
	cache.Get(6).Dump();
	cache.Put(3, 4);
	cache.Get(1).Dump();
	cache.Get(10).Dump();
	cache.Put(3, 29);
	cache.Put(10, 28);
	cache.Put(1, 20);
	cache.Put(11, 13);
	cache.Get(3).Dump();
	cache.Put(3, 12);
	cache.Put(3, 8);
	cache.Put(10, 9);
	cache.Put(3, 26);
	cache.Get(8).Dump();
	cache.Get(7).Dump();
	cache.Get(5).Dump();
	cache.Put(13, 17);
	cache.Put(2, 27);
	cache.Put(11, 15);
	cache.Get(12).Dump();
	cache.Put(9, 19);
	cache.Put(2, 15);
	cache.Put(3, 16);
	cache.Get(1).Dump();
	cache.Put(12, 17);
	cache.Put(9, 1);
	cache.Put(6, 19);
	cache.Get(4).Dump();
	cache.Get(5).Dump();
	cache.Get(5).Dump();
	cache.Put(8, 1);
	cache.Put(11, 7);
	cache.Put(5, 2);
	cache.Put(9, 28);
	cache.Get(1).Dump();
	cache.Put(2, 2);
	cache.Put(7, 4);
	cache.Put(4, 22);
	cache.Put(7, 24);
	cache.Put(9, 26);
	cache.Put(13, 28);
	cache.Put(11, 26);
}

// Define other methods and classes here
public class LFUCache
{

	int capacity = 0;
	int iTimestamp = 0;
	
	Dictionary<int, MyValue> dic = null;
	AccessManager ac = null;
	
	public LFUCache(int capacity)
	{
		dic = new Dictionary<int, MyValue>(capacity);
		this.capacity = capacity;
		ac = new AccessManager(capacity);
	}

	public int Get(int key)
	{
		Console.Write("Get:{0} =>", key);
		if(capacity <= 0)
			return -1;
		
		if(dic.ContainsKey(key))
		{
			ac.Remove(dic[key]);
			++dic[key].AccessCount;
			dic[key].Timestamp = ++iTimestamp;
			ac.Add(dic[key]);
			return dic[key].Value;
		}
		//ac.Prt();
		return -1;
	}
	
	public void Put(int key, int value)
	{
		Console.WriteLine("put {0}:{1}", key, value);
		
		if (capacity <= 0)
			return;
		
		iTimestamp++;

		if (!dic.ContainsKey(key))
		{
			if(dic.Values.Count() == capacity)
			{
				InvalidateCache();
			}
			MyValue mv = new MyValue() { AccessCount = 1, Timestamp = iTimestamp, Value = value, Key = key };
			dic.Add(key, mv);
			ac.Add(mv);
		}
		else
		{
			ac.Remove(dic[key]);
			dic[key].Timestamp = iTimestamp;
			dic[key].Value = value;
			dic[key].AccessCount = 1;
			ac.Add(dic[key]);
		}
		
		ac.Prt();
		Console.WriteLine();
	}
	
	public void InvalidateCache()
	{
		ac.Prt();
		MyValue mvToDelete = ac.GetInvalidateObj();
		Console.WriteLine("sacrifice :"+ mvToDelete);
		dic.Remove(mvToDelete.Key);
		
	}
	
	public class AccessManager
	{
		int capacity = 0;
		SortedSet<MyValue> ss = null;
		
		public AccessManager(int capacity)
		{
			this.capacity = capacity;
			ss = new SortedSet<MyValue>();
		}
		
		public void Add(MyValue mv)
		{
			ss.Add(mv);
		}
		
		public void Remove(MyValue mv)
		{
			ss.Remove(mv);
		}
		
		// return key
		public MyValue GetInvalidateObj()
		{
			MyValue mv = ss.ElementAt(0);
			ss.Remove(mv);
			return mv;
		}
		
		public void Prt()
		{
			ss.ToList().ForEach(a=> Console.Write(string.Format("({0}-{1},{2}:{3}) ",a.AccessCount, a.Timestamp, a.Key, a.Value)));
			Console.WriteLine();
		}
		
	}
	
	public class MyValue : IComparable
	{
		public int Timestamp { get; set; }
		public int Value { get; set; }
		public int AccessCount { get; set; }
		public int Key { get; set; }

		public int CompareTo(object ot)
		{
			MyValue other = (MyValue)ot;
			
			if(this.AccessCount > other.AccessCount)
				return 1;
			else if(AccessCount < other.AccessCount)
				return -1;
			else if(AccessCount == other.AccessCount)
			{
				if(Timestamp < other.Timestamp)
				{
					return -1;
				}
				else if(Timestamp > other.Timestamp)
				{
					return 1;
				}
			}
			return 0;
		}

		public override string ToString()
		{
			 return string.Format("{0}:{3} Timestamp:{1} AccessCount:{2}", this.Key, this.Timestamp, this.AccessCount, this.Value);
		}
	}
}