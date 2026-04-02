public class Solution {
    public int MaxSubArray(int[] nums) 
    {
        var maxSum = nums[0];
        var currSum = maxSum;
        for(int i = 1; i < nums.Length; i++)
        {
            currSum = Math.Max(currSum, 0);
            currSum += nums[i];
            maxSum = Math.Max(maxSum, currSum);
        }
        return maxSum;
    }
}