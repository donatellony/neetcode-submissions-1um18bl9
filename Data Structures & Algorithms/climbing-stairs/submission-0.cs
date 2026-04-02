public class Solution {
    public int ClimbStairs(int n) {
        if(n == 0)
            return 0;
        var stairPos = n-1;     
        var dp = new int[] {1, 2};
        if(stairPos < dp.Length)
        {
            return dp[stairPos];
        }

        while(n > 2)
        {
            var newDp1 = dp[0] + dp[1];
            dp[0] = dp[1];
            dp[1] = newDp1;
            n--;
        }
        return dp[1];
    }
}
