public class Solution {
    public int Change(int amount, int[] coins) {
        var dp = new int[coins.Length + 1, amount + 1];

        for(int i = 0; i < coins.Length + 1; i++)
            dp[i,0] = 1;

        for(int i = 0; i < amount+1; i++)
            dp[coins.Length,i] = 0;

        for(int am = 1; am <= amount; am++)
        {
            for(int i = coins.Length - 1; i >= 0; i--)
            {
                dp[i, am] = dp[i + 1, am]; // Skip way
                if(am >= coins[i])
                {
                    dp[i, am] += dp[i, am - coins[i]]; // Take
                }
            }
        }
        
        return dp[0,amount];
    }
}