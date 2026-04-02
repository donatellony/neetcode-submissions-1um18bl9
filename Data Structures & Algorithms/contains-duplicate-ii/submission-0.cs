public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) 
    {
        HashSet<int> window = new();

        for(int i = 0; i < nums.Length; i++)
        {
            if(window.Contains(nums[i]))
                return true;

            window.Add(nums[i]);

            if(window.Count > k)
                window.Remove(nums[i - k]);
        }

        return false;
    }
}