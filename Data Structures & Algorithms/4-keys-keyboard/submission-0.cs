public class Solution {
    private int[] memo;
    public int MaxA(int n) 
    {
        memo = new int[n+1];
        Array.Fill(memo, -1);

        return Dfs(n);
    }

    private int Dfs(int n)
    {
        if(n < 4)
            return n;
        if(memo[n] != -1)
            return memo[n];
        
        // To make a copy, we should at least do ctrl+a ctrl+c
        var max = n;
        for(int j = 1; j <= n - 3; j++)
        {
            max = Math.Max(max, Dfs(j) * (n - j - 1));
        }
        return memo[n] = max;
    }
}
