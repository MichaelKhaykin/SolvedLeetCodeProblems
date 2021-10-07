public class Solution {
    public void Rotate(int[] nums, int k) {
        
        if(nums.Length == 1) return;
        if(k > nums.Length)
        {
            k %= nums.Length;
        }
        
        
        int count = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            int current = i;
            int saved = nums[current];

            do
            {
                var newSaved = nums[(current + k) % nums.Length];
                nums[(current + k) % nums.Length] = saved;
                saved = newSaved;

                current = (current + k) % nums.Length;
                count++;
                
                
                if(count == nums.Length) return;
            }while(current != i);
            
            if(count == nums.Length) return;
        }
    }
}
