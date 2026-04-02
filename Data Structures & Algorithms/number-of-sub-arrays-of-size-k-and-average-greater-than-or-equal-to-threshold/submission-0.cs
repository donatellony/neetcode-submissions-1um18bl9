public class Solution {
    public int NumOfSubarrays(int[] arr, int k, int threshold) 
    {
        int counter = 0;
        int sum = 0;

        for(int i = 0; i < k; i++)
            sum += arr[i];

        if(sum >= threshold * k)
            counter++;

        // sliding window
        for(int i = k; i < arr.Length; i++)
        {
            sum += arr[i];
            sum -= arr[i - k];

            if(sum >= threshold * k)
                counter++;
        }

        return counter;
    }

}