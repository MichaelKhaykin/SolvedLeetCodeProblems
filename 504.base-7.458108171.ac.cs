public class Solution {
    public string ConvertToBase7(int num) {
        bool isNegative = num < 0;
        
        string str = "";
        
        num = Math.Abs(num);
        
        do
        {
            var division = num / 7;
            var mod = num % 7;
            
            num = division;
            
            str += mod;
        }while(num != 0);
    
        StringBuilder reverse = new StringBuilder();
        for(int i = str.Length - 1; i >= 0; i--)
        {
            reverse.Append(str[i]);
        }
        str = reverse.ToString();
        
        return isNegative ? "-" + str : str;
    }
}
