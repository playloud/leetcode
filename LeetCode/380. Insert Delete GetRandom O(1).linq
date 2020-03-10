<Query Kind="Program" />

// passed on dec-11-2017
void Main()
{
	// Init an empty set.
	RandomizedSet randomSet = new RandomizedSet();
	
	// Inserts 1 to the set. Returns true as 1 was inserted successfully.
	randomSet.Insert(1).Dump();
	
	// Returns false as 2 does not exist in the set.
	randomSet.Remove(2).Dump();
	
	// Inserts 2 to the set, returns true. Set now contains [1,2].
	randomSet.Insert(2).Dump();
	
	// getRandom should return either 1 or 2 randomly.
	randomSet.GetRandom().Dump();
	
	// Removes 1 from the set, returns true. Set now contains [2].
	randomSet.Remove(1).Dump();
	
	// 2 was already in the set, so return false.
	randomSet.Insert(2).Dump();
	
	// Since 2 is the only number in the set, getRandom always return 2.
	randomSet.GetRandom().Dump();
}

// Define other methods and classes here
public class RandomizedSet {

	int magic = 512;
	
	Dictionary<int, HashSet<int>> mainDic = new Dictionary<int, HashSet<int>>();

    /** Initialize your data structure here. */
    public RandomizedSet() {
        
		
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
		
		int key = val % magic;
		
		if(mainDic.ContainsKey(key))
		{
			if(mainDic[key].Contains(val))
			{
				return false;
			}
			mainDic[key].Add(val);
		}
		else
		{
			HashSet<int> set = new HashSet<int>();
			set.Add(val);
			mainDic.Add(key, set);
		}
        
		return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        
		int key = val % magic;
		
		if(mainDic.ContainsKey(key))
		{
			if(mainDic[key].Contains(val))
			{
				// now delete
				mainDic[key].Remove(val);
				return true;
			}
			else
			{
				// no such val
				return false;
			}
		}
		
		return false;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        
		Random rand = new Random();
		int keyCount = mainDic.Keys.Count;
		if(keyCount > 0)
		{
			while (true)
			{
				int skipValue = rand.Next(0, keyCount);
				int key = mainDic.Keys.Skip(skipValue).Take(1).FirstOrDefault();
				
				if(mainDic[key].Count > 0)
				{
					skipValue = rand.Next(0, mainDic[key].Count);
					int result = mainDic[key].ToList().Skip(skipValue).Take(1).FirstOrDefault();
					return result;
				}
			}
			
		}
		return 0;
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */