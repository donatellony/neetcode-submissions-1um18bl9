public class Solution {
    private int[,] memo;
    public int MaximumProfit(List<int> profit, List<int> weight, int capacity) {
        memo = new int[profit.Count, capacity + 1];
        return Dfs(0, profit, weight, capacity);
    } 

    public int Dfs(int i, List<int> profit, List<int> weight, int capacity)
    {
        if(capacity <= 0 || i >= profit.Count)
            return 0;

        if(memo[i, capacity] != 0)
        {
            return memo[i, capacity];
        }
        
        var skip = Dfs(i+1, profit, weight, capacity);
        var newCapacity = capacity - weight[i];
        memo[i, capacity] = skip;
        if(newCapacity >= 0){
            var take = profit[i] + Dfs(i+1, profit, weight, newCapacity);
            memo[i, capacity] = Math.Max(skip, take);
        }
        return memo[i, capacity];
    }
}
