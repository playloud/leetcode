<Query Kind="Program" />

// failed, hard to think..
void Main()
{
    int[] input = {-1, 2, 1, -4};
    Solution sol = new Solution();
    //sol.ThreeSumClosest(input, 1).Dump();

    int[] input2 = {1,1,-1,-1,3};
    //sol.ThreeSumClosest(input2, -1).Dump();

    int[] input3 = { 1,2,5,10,11 };
    sol.ThreeSumClosest(input3, 12).Dump();

}

// PSH 09/18/18 : failed..
// Define other methods and classes here
public class Solution
{

    public int ThreeSumClosest(int[] nums, int target)
    {
        if (nums.Length < 3)
            return 0;

        Array.Sort(nums);
        
        int result = 0;
        
        int closestSum = 0;
        SortedList sol = new SortedList();
        
        for (int i = 0; i < nums.Length-2; i++)
        {
            int curValue = nums[i];
            
            int newTarget = target - curValue;
            
            // now find two sum
            int j,k, tempSum, diff;
            j= i+1;
            k = nums.Length - 1;
            tempSum = 0;
            
            int jj,kk;
            jj=kk=0;
            
            int partDiff = int.MaxValue;
            
            while(j < k)
            {
                tempSum = nums[j] + nums[k];
                jj=j;kk=k;

                if (tempSum < newTarget)
                {
                    ++j;
                }
                else if (tempSum > newTarget)
                {
                    --k;
                }
                else if (tempSum == newTarget)
                {
                    return target;
                }
            }
            
            Console.WriteLine("Newtarget:{0}  tempSum:{1} {2} {3} {4}", newTarget, tempSum, i,jj,kk);
            
            closestSum = tempSum+curValue;
            
            diff = Math.Abs( target - closestSum);
            
            // key diff, value closestSum
            if(!sol.ContainsKey(diff))
                sol.Add(diff, closestSum);
        }
        
        sol.Dump();
        
        result = (int)sol.GetByIndex(0);
        
        return result;

    }
    
    


//    public int failed2_ThreeSumClosest(int[] nums, int target)
//    {
//        if (nums.Length < 3)
//            return 0;
//        
//        Array.Sort(nums);
//
//        SortedList sl = new SortedList();
//
//        int distance = 0;
//        int left, right, sum;
//        
//        left = 0;
//        right = nums.Length-1;
//        
//        while(left<right-1)
//        {
//            for (int i = left+1; i < right; i++)
//            {
//                sum = nums[left] + nums[i] + nums[right];
//                sum.Dump("sum");
//                distance = target - sum;
//                int key = Math.Abs(distance);
//                if(!sl.ContainsKey(key))
//                    sl.Add(key, sum);
//
//            }
//            left++;
//        }
//        sl.Dump();
//        return (int)sl.GetByIndex(0);
//    }
//
//    public int failed_ThreeSumClosest(int[] nums, int target)
//    {
//        if (nums.Length < 3)
//            return 0;
//
//        Array.Sort(nums);
//        
//        SortedList sl = new SortedList();
//        
//        int difference = 0;
//        int a, b, c, sum;
//        
//        for (int i = 0; i < nums.Length - 2; i++)
//        {
//            a = nums[i];
//            b = nums[i + 1];
//            c = nums[i + 2];
//
//            sum = a + b + c;
//
//            difference = sum - target;
//            
//            if(!sl.ContainsKey(Math.Abs(difference)))
//            {
//                sl.Add(Math.Abs(difference), sum);
//            }
//        }
//        
//        return (int)sl.GetByIndex(0);
//    }
}