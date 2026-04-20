public class Solution {
    public int PivotIndex(int[] nums) 
    {
        var total = 0;
        foreach(var num in nums)
            total += num;
        
        var leftSum = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            var rightSum = total - leftSum - nums[i];
            if(rightSum == leftSum)
                return i;
            
            leftSum += nums[i];
        }

        return -1;
    }
}