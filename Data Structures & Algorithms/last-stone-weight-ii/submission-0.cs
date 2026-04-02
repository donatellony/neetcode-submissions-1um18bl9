public class Solution {
    public int LastStoneWeightII(int[] stones) 
    {
        /*
        So, to calculate i, target:
        Boundaries:
            i: 0 -> stones.Length
            t: 0 -> target
        Prereqs to calculate i, target:
        Skip:
            - i + 1, target is the same
            - We have to know i + 1 before i (Big to small)
        Take:
            - i + 1, t - stones[i]
            - We have to know i + 1 before i (Big to small),  t - stones[i] (Small to big)
        */
        var sum = 0;
        foreach (int s in stones)
            sum += s;
        
        var len = stones.Length;

        int target = sum / 2;
        var dp = new int[len + 1][];
        for(int i = 0; i < len + 1; i++)
        {
            dp[i] = new int[target + 1];
        }

        for(int i = stones.Length - 1; i >= 0; i--)
        {
            for(int t = 1; t < target + 1; t++)
            {
                int max = dp[i+1][t]; // Skip
                if(t >= stones[i])
                {
                    max = Math.Max(max, stones[i] + dp[i+1][t - stones[i]]); // Take
                }
                dp[i][t] = max;
            }
        }

        int best = dp[0][target];
        return sum - 2 * best;
    }
}