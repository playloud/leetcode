<Query Kind="Program" />

//278. First Bad Version
//https://leetcode.com/problems/first-bad-version/
// PSH 02/06/20 : passed
// lesson : version number can be bigger than INTEGER!!!!
void Main()
{
	(new Solution()).FirstBadVersion(2126753390).Dump();
}

// Define other methods and classes here
/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class VersionControl
{
	public bool IsBadVersion(int version)
	{
		if(version >=1702766719)
			return true;
		
		return false;
	}
}
public class Solution : VersionControl
{
	public int FirstBadVersion(int n)
	{
		
		long start = 1;
		long end = n;
		long med = 0;
		
		while(start != end && (end-start)>1) 
		{
			med = (start+end)/2;
			
			if(IsBadVersion((int)med))
			{
				end = med;
			} 
			else 
			{
				start = med;
			}
		}
		
		if(IsBadVersion((int)start)) {
			return (int)start;
		}else {
			return (int)end;
		}
	}
}