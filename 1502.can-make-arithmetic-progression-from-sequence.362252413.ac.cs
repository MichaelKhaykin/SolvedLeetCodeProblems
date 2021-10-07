public class Solution {  
    public bool CanMakeArithmeticProgression(int[] arr) {        
        for(int i = 0; i < arr.Length; i++)
        {
            for(int j = i + 1; j < arr.Length; j++)
            {   
                if(arr[j] < arr[i])
                {
                    var temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }
        
        int diff = arr[0] - arr[1];
        for(int i = 1; i < arr.Length; i++)
        {
            if(i + 1 >= arr.Length) break;
            
            if(arr[i] - arr[i + 1] != diff)
            {
                return false;
            }
        }
        
        return true;
    }
}
