public class NumArray {
    private int[] sums;
    public NumArray(int[] nums) {
        sums = new int[nums.Length];
        sums[0] = nums[0];
        for(int i = 1; i < nums.Length; i++)
        {
            sums[i] = sums[i-1] + nums[i];
        }
    }
    
    public int SumRange(int left, int right) 
    {
        return left == 0 ? sums[right] : sums[right] - sums[left - 1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */