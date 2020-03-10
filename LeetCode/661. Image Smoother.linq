<Query Kind="Program" />

void Main()
{
	int[,] input = {{1, 1, 1}, {1, 0, 1}, {1, 1, 1}};
	(new Solution()).ImageSmoother(input).Dump();
}


public class Solution
{
	public int[,] ImageSmoother(int[,] M)
	{
		int[,] result =  null;
		
		if(M == null)
			return result;
			
		result = new int[M.GetLength(0),M.GetLength(1)];
		
		int lastX,lastY;
		lastX = M.GetLength(0)-1;
		lastY = M.GetLength(1)-1;
		
		for (int i = 0; i < M.GetLength(0); i++)
		{
			for (int j = 0; j < M.GetLength(1); j++)
			{
				result[i,j] = GetSumfloor(i,j,lastX, lastY, M);
			}
		}
		return result;
	}
	
	public int GetSumfloor(int i, int j, int lastX, int lastY, int [,] src)
	{
		int result = 0;
		
		int minx, maxx, miny, maxy;
		int sum, count;
		minx = Math.Max(0, i-1);
		maxx = Math.Min(lastX, i + 1);
		miny = Math.Max(0, j - 1);
		maxy = Math.Min(lastY, j + 1);
		sum=0;count=0;
		for (int ii = minx; ii <= maxx; ii++)
		{
			for (int jj = miny; jj <= maxy; jj++)
			{
				count++;
				sum+=src[ii,jj];
			}
		}
		
		result = sum/count;
		
		return result;
	}
}