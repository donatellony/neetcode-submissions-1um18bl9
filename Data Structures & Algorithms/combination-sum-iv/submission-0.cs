/*

Having an array of nums
Return all the combinations that sum up to num

There might be multiple combinations with the same set of numbers:
1,1,2
1,2,1
Are both valid

State is how many ways do we have to achieve the target
*/



public class Solution {
    private int[] memo;
    private int[] nums;
    public int CombinationSum4(int[] nums, int target) 
    {
        this.nums = nums;
        this.memo = new int[target + 1];
        Array.Fill(memo, -1);
        return Dfs(target);
    }

    private int Dfs(int target)
    {
        if(target == 0)
            return 1;
        if(memo[target] != -1)
            return memo[target];
        
        var res = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            // Take
            if(target >= num)
            {
                res += Dfs(target - num);
            }
        }
        
        memo[target] = res;
        return res;
    }
}