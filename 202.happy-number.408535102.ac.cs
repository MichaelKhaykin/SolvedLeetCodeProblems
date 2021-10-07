public class Solution {
    public bool IsHappy(int n) {
        string stringy = n.ToString();
        HashSet<int> cycle = new HashSet<int>();
        cycle.Add(n);
        
        while(stringy != "1")
        {
            int number = 0;
            foreach(var item in stringy)
            {
                number += (int)Math.Pow(char.GetNumericValue(item), 2);
            }
            
            stringy = number.ToString();
            
            if(cycle.Add(number) == false) return false;
        }
        
        return true;
    }
}
