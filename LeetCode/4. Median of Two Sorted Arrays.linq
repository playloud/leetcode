<Query Kind="Program" />

//PSH 09/23/18 17:53:55 passed at 38.64%
void Main()
{
    int[] nums1 = {1,2};
    int[] nums2 = {3,4};
    Solution sol = new Solution();
    sol.FindMedianSortedArrays(nums1, nums2).Dump();
}

// Define other methods and classes here
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double result = 0;
        
        int i,j;
        int val1,val2;
        i=j=0;
        bool isVal1Valid, isVal2Valid;
        isVal1Valid = isVal2Valid = true;
        ArrayList al = new ArrayList();
        
        val1 = val2 = 0;
        
        while(i < nums1.Length || j < nums2.Length)
        {
            if(i<nums1.Length)
            {
                val1 = nums1[i];
                isVal1Valid = true;
            }
            else
                isVal1Valid = false;
            
            if(j<nums2.Length)
            {
                val2 = nums2[j];
                isVal2Valid = true;
            }
            else
                isVal2Valid = false;
                
            if(isVal1Valid && isVal2Valid)
            {
                if(val1 <= val2)
                {
                    al.Add(val1);
                    i++;
                } else 
                {
                    al.Add(val2);
                    j++;
                }
            }
            else if(isVal1Valid)
            {
                al.Add(val1);
                i++;
            }
            else if(isVal2Valid)
            {
                al.Add(val2);
                j++;
            }
        }
        
        int count = al.Count;
        if(count%2 == 0) 
        {
            //LESSON!!
            double first = (double)(int)al[count/2];
            double second = (double)(int)al[(count/2)-1];
            result = (first+second)/2;
            // cass even
            //result = (double)( ((int)al[count/2]+ (int)al[(count/2)-1])/2);
        }
        else 
        {
            // case odd count
            result = (double)((int)al[count/2]);
        }
        
        return result;
    }
}