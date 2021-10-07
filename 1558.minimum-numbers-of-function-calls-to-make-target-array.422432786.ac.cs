public class Solution {
    
    int ans = 0;
    
    public void modify(int[] arr, int op, int ind)
    {
        ans++;
        if(op == 0)
        {
            arr[ind]--;
            return;
        }
        
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] /= 2;
        }
    }
    
    public int MinOperations(int[] nums) {
        
        while(true)
        {
            bool allEven = true;
            bool allZereos = true;
            List<int> nonEvens = new List<int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != 0)
                {
                    allZereos = false;
                }
                if(nums[i] % 2 != 0 && nums[i] != 0) 
                {
                    nonEvens.Add(i);
                    allEven = false;
                }
            }

            if(allZereos) return ans;

            if(allEven)
            {
                modify(nums, 1, -1);
            }
            else
            {
                foreach(var item in nonEvens)
                {
                    modify(nums, 0, item);
                }
            }
        }
    }
}
