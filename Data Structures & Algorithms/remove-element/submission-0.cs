public class Solution {
    public int RemoveElement(int[] nums, int val) 
    {
        int l = 0, r = 0;
        while(r < nums.Length)
        {
            if(nums[r] != val)
            {
                Swap(nums, l, r);
                ++l;
            }
            ++r;
        }

        return l;
    }

    private void Swap(int[] nums, int i1, int i2)
    {
        if(i1 == i2)
            return;
        (nums[i1], nums[i2]) = (nums[i2], nums[i1]);
    }
}