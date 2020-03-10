<Query Kind="Program" />

void Main()
{
	int[,] mat = new int[7, 11];

	Random rand = new Random();
	int seed = 1;
	for (int i = 0; i < mat.GetLength(0); i++)
	{
		for (int j = 0; j < mat.GetLength(1); j++)
		{
			//seed = seed + rand.Next()%5; 
			seed = seed + 3;
			mat[i, j] = seed;
		}
	}

	//mat.Dump();

	//	int[,] mat2 = {{1,4,7,11,15},{2,5,8,12,19},{3,6,9,16,22},{10,13,14,17,24},{18,21,23,26,30}};
	//	int target = 5;
	//	//mat2.Dump();
	//	(new Solution()).SearchMatrix(mat2, target).Dump();
	//
	//	int[,] mat3 = { {5}};
	//	mat3.Dump();
	//	(new Solution()).SearchMatrix(mat3, target).Dump();

	int[,] mat4 = { { 5 }, { 6 }};
	int target = 6;
	mat4.Dump();
	(new Solution()).SearchMatrix(mat4, target).Dump();



}

// Define other methods and classes here
public class Solution
{
	public enum Direction {row, col};
	
	public bool SearchMatrix(int[,] matrix, int target)
	{
		
		int maxI = matrix.GetLength(0)-1;
		int maxJ = matrix.GetLength(1)-1;

		if (maxI == -1)
			return false;
		
		if(maxI == 0 && maxJ == -1)
			return false;
		

		int i,j;
		
		i=0;
		j=0;
		
		
		Direction currentDirection = Direction.row;
		
		while(true)
		{
			//Console.WriteLine("{0} {1} {2}", i,j, currentDirection);
			
			bool partResult = MyBinarySearch(currentDirection, i,j,target, matrix);
			
			if(partResult)
				return true;
			if(currentDirection == Direction.row)
			{
				if(i < maxI)
					i++;
				currentDirection = Direction.col;
			}
			else
			{
				if(j < maxJ)
					j++;
				currentDirection = Direction.row;
			}
			
			if(i == maxI+1 && j == maxJ+1)
				break;
		}
		return false;
	}
	
	public bool MyBinarySearch(Direction direction, int startI, int startJ, int target, int[,] matrix)
	{
		int middle;
		
		if(direction == Direction.row)
		{
			int max = matrix.GetLength(1) - 1;
			int j = startJ;	
			middle = (j+max)/2;
			
			while(true)
			{
				
				
				if(matrix[startI, middle] == target || matrix[startI, j] == target || matrix[startI, max] == target)
				{
					return true;
				} 
				else if(matrix[startI, middle] < target)
				{
					if (middle == j || middle == max)
						break;
					j = middle;
					middle = (j+max)/2;
				} 
				else if(matrix[startI, middle] > target)
				{
					if (middle == j || middle == max)
						break;
					max = middle;
					middle = (j+max)/2;
				}
				
				
			}
			
		}
		else if(direction == Direction.col)
		{
			int max = matrix.GetLength(0) - 1;
			int i = startI;
			middle = (i + max) / 2;
			
			while (true)
			{
				if (matrix[middle, startJ] == target || matrix[i, startJ] == target || matrix[max, startJ] == target )
				{
					return true;
				}
				else if (matrix[middle, startJ] < target)
				{
					if (middle == i || middle == max)
						break;
					i = middle;
					middle = (i + max) / 2;
				}
				else if (matrix[middle, startJ] > target)
				{
					if (middle == i || middle == max)
						break;
					max = middle;
					middle = (i + max) / 2;
				}
			}
		}
		return false;
	}
}	