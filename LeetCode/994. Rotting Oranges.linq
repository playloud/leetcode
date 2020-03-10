<Query Kind="Program" />

//994. Rotting Oranges
void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int OrangesRotting(int[][] grid)
	{
		
		int lastRottenCount = 0;
		int elpasedTime = 0;
		
		List<Cell> cells = new List<Cell>();
		
		
		
		for (int time = 1; time < 100; time++)
		{
			elpasedTime = time;
			int currentRottenCount = 0;
			
			
			
			
			if (currentRottenCount == lastRottenCount)
				break;
			
		}
		
		return -1;
	}
	
	
}

class Cell 
{
	public Cell(int x, int y, int state)
	{
		this.x = x;
		this.y = y;
		this.state = state;
	}
	
	public int x { get; set; }
	public int y { get; set; }
	public int state { get; set; }
}