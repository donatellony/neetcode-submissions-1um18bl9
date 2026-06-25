/*

cost[0][0] -> Cost of painting the house 0 with RED
cost[1][2] -> Cost of painting the house 1 with GREEN

No two adj houses have the same color


*/


public class Solution {
    private int[][] dp;
    public int MinCost(int[][] costs) 
    {
        dp = new int[costs.Length + 1][];
        for(int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[4];
        }

        for(var i = costs.Length - 1; i >= 0; i--)
        {
            for(int c = 0; c < 4; c++)
            {
                // Take one of the colors
                var minCost = int.MaxValue;
                for(int color = 0; color < 3; color++)
                {
                    if(color == c)
                        continue;
                    minCost = Math.Min(minCost, costs[i][color] + dp[i+1][color]);
                }
                dp[i][c] = minCost;
            }
        }

        return dp[0][3];
    }
}