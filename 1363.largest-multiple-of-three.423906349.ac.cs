class Solution
{
public string LargestMultipleOfThree(int[] digits) {
        Array.Sort(digits, (x,y) => -x.CompareTo(y));        
        if (digits[0] == 0) { return "0"; }
        
        List<int> modGives0 = new List<int>();
        List<int> modGives1 = new List<int>();
        List<int> modGives2 = new List<int>();
        
        int sum = 0;
        
        for(int i=0; i< digits.Length; i++)
        {
            switch(digits[i] %3)
            {
                case 0: modGives0.Add(digits[i]); break;
                case 1: modGives1.Add(digits[i]); break;
                case 2: modGives2.Add(digits[i]); break;
                default: break;
            }
            sum += digits[i];            
        }
        
        switch (sum % 3)
        {
            case 0: 
                modGives0.AddRange(modGives1);
                modGives0.AddRange(modGives2);
                break;
                
            case 1: 
                if (modGives1.Count > 0) {            
                    modGives1.RemoveAt(modGives1.Count-1); 
                    modGives0.AddRange(modGives1);
                    modGives0.AddRange(modGives2);
                }
                else if (modGives2.Count > 1)
                {
                    modGives2.RemoveAt(modGives2.Count-1); 
                    modGives2.RemoveAt(modGives2.Count-1); 
                    modGives0.AddRange(modGives2); 
                }
                break; 
               
            case 2:
                if (modGives2.Count > 0)
                {
                    modGives2.RemoveAt(modGives2.Count-1); 
                    modGives0.AddRange(modGives1);
                    modGives0.AddRange(modGives2);
                }
                else if (modGives1.Count > 1)
                {
                    modGives1.RemoveAt(modGives1.Count-1); 
                    modGives1.RemoveAt(modGives1.Count-1); 
                    modGives0.AddRange(modGives1);
                }
                break;
        }
                
        return string.Concat(modGives0.OrderByDescending(x=>x).Select(x=>x.ToString()));
    }
}
