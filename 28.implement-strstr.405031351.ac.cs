public class Solution {
    public int StrStr(string haystack, string needle) {
        if(needle == "") return 0;
        if(needle.Length > haystack.Length) return -1;
        
        int needleIndex = 0;
        for(int i = 0; i < haystack.Length; i++)
        {
            int oldI = i;
            bool didGoIn = false;
            while(i < haystack.Length && haystack[i] == needle[needleIndex])
            {
                didGoIn = true;
                i++;
                needleIndex++;
                
                if(needleIndex >= needle.Length)
                {
                    return oldI;
                }
            }
            
            if(didGoIn == false) continue;
            i = oldI;
            needleIndex = 0;
        }
        
        return -1;
    }
}

