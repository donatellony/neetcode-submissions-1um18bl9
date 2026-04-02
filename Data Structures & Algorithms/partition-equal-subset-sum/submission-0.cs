public class Solution {
    private bool?[,] memo;
    public bool CanPartition(int[] nums) {
        var sum = 0;
        foreach(var num in nums)
            sum += num;
        if(sum % 2 > 0)
        {
            return false;
        }
        var halfSum = sum / 2;
        memo = new bool?[nums.Length, halfSum + 1];
        return Dfs(0, halfSum, nums);
    }

    public bool Dfs(int i, int target, int[] nums)
    {
        if(target == 0)
            return true;
        if(i == nums.Length)
        {
            return false;
        }

        if(memo[i, target] != null)
        {
            return memo[i, target].Value;
        }

        var skip = Dfs(i + 1, target, nums);
        memo[i, target] = skip;
        if(target - nums[i] >= 0){
            memo[i, target] = memo[i, target].Value || Dfs(i + 1, target - nums[i], nums); // Take
        }

        return memo[i, target].Value;
    }
}
