public class Solution {
    public int MinSubArrayLen(int target, int[] nums) 
    {
        var result = int.MaxValue;
        var currSum = 0;
        int l = 0;
        for(int r = 0; r < nums.Length; r++)
        {
            currSum += nums[r];
            while(currSum >= target)
            {
                result = Math.Min(result, r - l + 1);
                currSum -= nums[l++];
            }
        }

        return result == int.MaxValue ? 0 : result;
    }
}