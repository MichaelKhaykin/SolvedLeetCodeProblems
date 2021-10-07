public class Solution {
    public int[] PrevPermOpt1(int[] arr) {
        
        int first = -1;
        
        int second = -1;
        int secondVal = int.MinValue;
        
        for(int i = arr.Length - 1; i > 0; i--)
        {
            if(arr[i] < arr[i - 1])
            {
                first = i - 1;
                break;
            }
        }
        
        if(first == -1) return arr;
        
        for(int i = arr.Length - 1; i > first; i--)
        {
            if(secondVal <= arr[i] && arr[i] < arr[first])
            {
                second = i;
                secondVal = arr[i];
            }
        }
        
        
        var temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
        
        return arr;
    }
}
