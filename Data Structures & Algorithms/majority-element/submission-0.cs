public class Solution {
    public int MajorityElement(int[] nums) 
    {
        int counter = 1;
        int majorityElement = nums[0];
        for(int i = 1; i < nums.Length; i++)
        {
            if(majorityElement == nums[i])
            {
                ++counter;
                continue;
            }
            if(--counter == 0)
            {
                majorityElement = nums[i];
                ++counter;
            }
        }
        return majorityElement;
    }
}