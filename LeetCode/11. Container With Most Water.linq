<Query Kind="Program" />

void Main()
{
    int[] height = {1,8,6,2,5,4,8,3,7};
    Solution sol = new Solution();
    sol.MaxArea(height).Dump();
    
}

// // PSH 09/17/18 : accepted, 
// Define other methods and classes here
public class Solution
{
    public int MaxArea(int[] height)
    {
        int max = int.MinValue;
        
        int left, right;
        left = 0;
        right = height.Length - 1;
        
        while(left < right)
        {
            int area = (right - left) * Math.Min(height[left],height[right]);
            if(max < area) max = area;
            
            if(height[left] > height[right]) right--;
            else left++;
        }
        
        return max;
    }
}