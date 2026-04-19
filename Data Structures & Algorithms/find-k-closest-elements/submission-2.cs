public class Solution {
    public List<int> FindClosestElements(int[] arr, int k, int x) 
    {
        List<int> result = [];
        int l = 0, r = arr.Length - k;
        while(l < r)
        {
            var m = l + (r - l) / 2;
            if(x - arr[m] > arr[m + k] - x)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }
        for(int i = l; i < l + k; i++)
        {
            result.Add(arr[i]);
        }
        return result;
    }
}