<Query Kind="Program" />

void Main()
{
//	char[,] grid = {{'1','1','1','1','1','1','1'},{'0','0','0','0','0','0','1'},{'1','1','1','1','1','0','1'},{'1','0','0','0','1','0','1'},{'1','0','1','0','1','0','1'},{'1','0','1','1','1','0','1'},{'1','1','1','1','1','1','1'}};
	
	char[,] grid = 
	{{'1','1','1','1','0','1','1','1','1','1','1','1','0','1','0','1','1','1','1','1'},{'1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1'},{'0','1','1','1','1','1','0','1','1','0','1','1','1','1','1','1','1','1','0','1'},{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','0','1'},{'1','1','1','1','0','1','1','1','1','1','1','1','1','0','1','1','1','1','0','1'},{'1','1','1','1','1','0','1','1','1','0','1','1','1','1','1','1','1','1','0','1'},{'1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1'},{'0','1','0','1','1','1','1','1','1','0','0','1','0','1','0','1','1','1','1','1'},{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},{'1','1','1','1','0','0','0','1','0','1','1','1','1','0','1','0','1','1','1','1'},{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},{'1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','0','1','1'},{'0','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1'},{'1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1'},{'1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},{'1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','1','1'},{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},{'1','0','1','1','1','0','1','1','1','1','0','1','1','1','1','1','1','1','1','1'},{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},{'1','1','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'}};
	
	(new Solution()).NumIslands(grid).Dump();
}


public class Solution
{
	List<List<char>> groups = new List<System.Collections.Generic.List<char>>();
	
	public int NumIslands(char[,] grid)
	{
		int maxi = grid.GetLength(0);
		int maxj = grid.GetLength(1);
		
		PointManager pman = new PointManager();
		
		char[] tempGrp = new char[2];
		
		for (int i = 0; i < maxi; i++)
		{
			for (int j = 0; j < maxj; j++)
			{
				if (grid[i, j] == '1')
				{
					// check left
					if (j - 1 >= 0 && IsKey(grid[i, j - 1]))
					{
						// check up, and up is land, 
						if (i - 1 >= 0 && IsKey(grid[i - 1, j]))
						{
							// update element first
							grid[i, j] = grid[i, j - 1];
							pman.AddPoint(grid[i, j], i, j);

							// update both isald, merging
							char upKey = grid[i - 1, j];
							char leftKey = grid[i, j];
							
							if (upKey != leftKey) // if not same, merge
							{
								tempGrp[0] = leftKey;
								tempGrp[1] = upKey;
								pman.Merge(leftKey, upKey, grid);
								
							}
							else // if same, do nothing
							{
								
							}
						}
						else
						{
							// update element
							grid[i, j] = grid[i, j - 1];
							pman.AddPoint(grid[i, j], i, j);
						}
					}
					else if (i - 1 >= 0 && IsKey(grid[i - 1, j])) // up is island, left is not
					{
						grid[i, j] = grid[i - 1, j];
						pman.AddPoint(grid[i, j], i, j);
					}
					else
					{
						// new island
						grid[i, j] = GetKey();
						pman.AddPoint(grid[i, j], i, j);
						
					}
				}
			}
		}
		
		return pman.GetNumberOfIsland();
	}
	
	char seedKey = 'a';
	public char GetKey()
	{
		return seedKey++;
	}

	public bool IsKey(char c)
	{
		if (c >= 'a')
			return true;
		return false;
	}
	
	public class Point
	{
		public int x { get; set; }
		public int y { get; set; }
	}
	
	public class PointManager
	{
		Dictionary<char, List<Point>> dic = new Dictionary<char, List<Point>>();
		
		
		public void AddPoint(char c, int x, int y)
		{
			if(dic.ContainsKey(c))
				dic[c].Add(new Point() {x=x, y=y});
			else
			{
				List<Point> points = new List<Point>();
				points.Add(new Point() {x=x, y=y});
				dic.Add(c, points);
			}
		}
		
		public void Merge(char c, char d, char[,] grid)
		{
			// c obsorbs d
			if(dic[c].Count >= dic[d].Count)
			{
				dic[c].AddRange(dic[d]);
				foreach (Point p in dic[d])
				{
					grid[p.x, p.y] = c;
				}
				dic[d].Clear();
			}
			else
			{
				dic[d].AddRange(dic[c]);
				foreach (Point p in dic[c])
				{
					grid[p.x, p.y] = d;
				}
				dic[c].Clear();
			}
		}
		
		public int GetNumberOfIsland()
		{
			return (dic.Where(a=>a.Value.Count > 0).Count());
			
		}
	}
	
	

}