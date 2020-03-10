<Query Kind="Program" />

//54. Spiral Matrix
// https://leetcode.com/problems/spiral-matrix/
// lesson : dont forget the null input
// Runtime: 244 ms, faster than 31.59% of C# online submissions for Spiral Matrix.
void Main()
{
	var arr = "[[1,2,3],[4,5,6],[7,8,9]]".ToJaggedIntArray();
	(new Solution()).SpiralOrder(arr).Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public IList<int> SpiralOrder(int[][] matrix)
	{
		
		List<int> result = new List<int>();
		if(matrix == null || matrix.Length == 0)
			return result;
		
		HashSet<string> visited = new HashSet<string>();

		List<int[]> directions = new List<int[]>{
			new int[]{0,1},
			new int[]{1,0},
			new int[]{0,-1},
			new int[]{-1,0}
		};
		
		int columns = matrix.Length;
		int rows = matrix[0].Length;
		int total = columns * rows;
		
		int i = 0;
		int j = 0;
		
		int iDir = 0;
		int[] curDirection = directions.ElementAt(iDir);
		
		
		while(visited.Count < total)
		{
			string key = string.Format("{0}_{1}", i,j);
			visited.Add(key);
			result.Add(matrix[i][j]);
			
			// check next direction
			int nexti = curDirection[0] + i;
			int nextj = curDirection[1] + j;
			
			// check valid next index?
			bool isValidNextIndex = true;
			
			if(nexti >= matrix.Length || nexti < 0 )
				isValidNextIndex = false;
			if(nextj >= matrix[0].Length || nextj < 0)
				isValidNextIndex = false;
			
			bool isVisited = false;
			isVisited = visited.Contains(string.Format("{0}_{1}", nexti,nextj));
			
			// if visited? or not valid index, change direction
			if(isVisited || !isValidNextIndex)
			{
				// re get next direction
				iDir++;
				if (iDir == 4)
					iDir = 0;
				curDirection = directions[iDir];
				nexti = curDirection[0] + i;
				nextj = curDirection[1] + j;
			}
		    
			i = nexti;
			j = nextj;
		}
		return result;
	}
}