public class Solution {
    private int[] prices;
    private Dictionary<(int, bool), int> memo = new();

    public int MaxProfit(int[] prices) {
        this.prices = prices;
        return Dfs(0, true);
    }

    private int Dfs(int i, bool buying) {
        if (i >= prices.Length) return 0;

        var key = (i, buying);
        if (memo.TryGetValue(key, out var val)) return val;

        int res = Dfs(i + 1, buying);

        if (buying) {
            int buy = -prices[i] + Dfs(i + 1, false);
            res = Math.Max(res, buy);
        } else {
            int sell = prices[i] + Dfs(i + 2, true);
            res = Math.Max(res, sell);
        }

        memo[key] = res;
        return res;
    }
}