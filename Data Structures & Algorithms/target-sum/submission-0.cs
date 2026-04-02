public class Solution {
    private Dictionary<(int, int), int> memo;
    public int FindTargetSumWays(int[] nums, int target) {
        memo = new();
        return Dfs(0, nums, target);
    }

    public int Dfs(int i, int[] nums, int target)
    {
        if(i == nums.Length)
        {
            if(target == 0)
                return 1;
            return 0;
        }
        var key = (i, target);
        if(memo.ContainsKey(key))
        {
            return memo[key];
        }

        var add = Dfs(i + 1, nums, target + nums[i]);
        var subtract = Dfs(i + 1, nums, target - nums[i]);
        
        memo[key] = add + subtract;

        return memo[key];
    }
}
