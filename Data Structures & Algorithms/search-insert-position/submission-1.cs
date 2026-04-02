public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int l = 0, r = nums.Length -1;
        while(l<r)
        {
            var m = (l+r)/2;
            if(nums[m]==target)
                return m;

            if(nums[m] > target)
            {
                r = m;
            }
            else
            {
                l = m+1;
            }
        }
        return nums[l] >= target ? l : l+1;
    }
}