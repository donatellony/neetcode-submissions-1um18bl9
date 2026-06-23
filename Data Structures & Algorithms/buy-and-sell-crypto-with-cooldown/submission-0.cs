public class Solution {
    private int[] prices;
    private Dictionary<(int, int), int> memo = new();
    public int MaxProfit(int[] prices) 
    {
        this.prices = prices;

        return Dfs(0, -1);
    }

    private int Dfs(int i, int coinIdx)
    {
        var key = (i, coinIdx);
        if(memo.TryGetValue(key, out var val))
        {
            return val;
        }

        if(i >= prices.Length - 1)
        {
            
            memo[key] = Math.Max(0, coinIdx > -1 ? (prices[prices.Length - 1] - prices[coinIdx]) : 0);
            return memo[key];
        }
        
        var res = 0;
        // Sell
        if(coinIdx > -1)
        {
            res = (prices[i] - prices[coinIdx]) + Dfs(i + 2, -1);
        }
        // Buy
        if(coinIdx < 0)
        {
            res = Math.Max(res, Dfs(i + 1, i));
        }
        // Skip
        res = Math.Max(res, Dfs(i + 1, coinIdx));
        memo[key] = res;
        return res;
    }
}
