public class Solution {
    public string ReformatNumber(string number) {
        
        StringBuilder digits = new StringBuilder();
        
        foreach(var item in number)
        {
            if(item >= '0' && item <= '9')
            {
                digits.Append(item);
            }
        }
        
        if(digits.Length <= 3) return digits.ToString();
        if(digits.Length == 4)
        {
            return $"{digits[digits.Length - 4]}{digits[digits.Length - 3]}-{digits[digits.Length - 2]}{digits[digits.Length - 1]}";
        }
        
        List<string> blocks = new List<string>();
        
        StringBuilder current = new StringBuilder();
        
        int currentCell = 0;
        
        for(int i = 0; i < digits.Length; i++)
        {
            
            
            
            
            current.Append(digits[i]);
            currentCell++;
            
            if(currentCell == 3)
            {
                blocks.Add(current.ToString());
                currentCell = 0;
                current.Clear();
                
                int left = digits.Length - i - 1;
                if(left == 2)
                {
                    blocks.Add($"{digits[digits.Length - 2]}{digits[digits.Length - 1]}");

                    break;
                }
                else if(left == 4)
                {
                    blocks.Add($"{digits[digits.Length - 4]}{digits[digits.Length - 3]}");
                    blocks.Add($"{digits[digits.Length - 2]}{digits[digits.Length - 1]}");

                    break;
                }
            }
        }
        
        StringBuilder final = new StringBuilder();
        foreach(var str in blocks)
        {
            final.Append(str);
            final.Append('-');
        }
        
        final.Remove(final.Length - 1, 1);
        return final.ToString();
    }
}
