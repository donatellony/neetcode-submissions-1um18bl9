public class Solution {
    public int Jump(int[] nums) 
    {
        var dp = new int[nums.Length];
        Array.Fill(dp, int.MaxValue);
        dp[nums.Length - 1] = 0;

        for(int i = nums.Length - 2; i >= 0; i--)
        {
            var maxJump = Math.Min(nums[i], nums.Length - i - 1);
            for(int j = 1; j <= maxJump; j++)
            {
                if(dp[i+j] != int.MaxValue)
                    dp[i] = Math.Min(dp[i], dp[i+j] + 1);
            }
        } 
        return dp[0];
    }
}
