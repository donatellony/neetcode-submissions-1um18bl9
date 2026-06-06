public class Solution {
    public bool CanJump(int[] nums) 
    {
        var dp = new bool[nums.Length];
        dp[nums.Length - 1] = true;

        for(int i = nums.Length - 2; i >= 0; i--)
        {
            int maxJump = Math.Min(nums[i], nums.Length - 1 - i);
            for(int j = maxJump; j >= 1; j--)
            {
                if(dp[i + j])
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[0];
    }
}
