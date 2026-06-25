/*

cost[0][0] -> Cost of painting the house 0 with RED
cost[1][2] -> Cost of painting the house 1 with GREEN

No two adj houses have the same color


*/


public class Solution {
    int[][] costs;
    private readonly Dictionary<(int i, int c), int> memo = new();
    public int MinCost(int[][] costs) 
    {
        this.costs = costs;
        return Dfs(0, -1);
    }

    public int Dfs(int i, int c)
    {
        if(i == costs.Length)
            return 0;
        if(memo.TryGetValue((i, c), out var cost))
        {
            return cost;
        }
        
        // Take one of the colors
        var minCost = int.MaxValue;
        for(int color = 0; color < 3; color++)
        {
            if(color == c)
                continue;
            minCost = Math.Min(minCost, costs[i][color] + Dfs(i+1, color));
        }
        memo[(i, c)] = minCost;
        return minCost;
    }
}