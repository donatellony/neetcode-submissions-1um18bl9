public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) 
    {
        // i1, i2
        // Boundaries -> 0 <= i1, i2 <= text1.length, text2.length
        // To know i1, i2, we have to know i1+1, i2+1, big to small
        var dp = new int[text1.Length + 1][];
        for(int i = 0; i < text1.Length + 1; i++)
        {
            dp[i] = new int[text2.Length + 1];
        }

        for(int i1 = text1.Length - 1; i1 >= 0; i1--)
        {
            for(int i2 = text2.Length - 1; i2 >= 0; i2--)
            {
                if(text1[i1] == text2[i2])
                {
                    dp[i1][i2] = 1 + dp[i1 + 1][i2 + 1];
                }
                else
                {
                    dp[i1][i2] = Math.Max(dp[i1 + 1][i2], dp[i1][i2 + 1]);
                }
            }
        }
        return dp[0][0];
    }
}
