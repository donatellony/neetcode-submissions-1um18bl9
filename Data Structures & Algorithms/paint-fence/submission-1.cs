public class Solution {
    private Dictionary<int, int> memo = new Dictionary<int, int>();

    private int TotalWays(int i, int k) {
        if (i == 1) return k;
        if (i == 2) return k * k;

        if (memo.ContainsKey(i)) {
            return memo[i];
        }

        memo[i] = (k - 1) * (TotalWays(i - 1, k) + TotalWays(i - 2, k));
        return memo[i];
    }

    public int NumWays(int n, int k) {
        return TotalWays(n, k);
    }
}