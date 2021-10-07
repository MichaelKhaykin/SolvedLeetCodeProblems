public class Solution {
    
    public Dictionary<char, string> Conversion = new Dictionary<char, string>()
    {
        ['1'] = "One",
        ['2'] = "Two",
        ['3'] = "Three",
        ['4'] = "Four",
        ['5'] = "Five",
        ['6'] = "Six",
        ['7'] = "Seven",
        ['8'] = "Eight",
        ['9'] = "Nine",
    };
    
    public Dictionary<char, string> Ten = new Dictionary<char, string>()
    {
        ['2'] = "Twenty",
        ['3'] = "Thirty",
        ['4'] = "Forty",
        ['5'] = "Fifty",
        ['6'] = "Sixty",
        ['7'] = "Seventy",
        ['8'] = "Eighty",
        ['9'] = "Ninety"
    };
    
    public Dictionary<int, string> Last = new Dictionary<int, string>()
    {
        [3] = "Thousand",
        [4] = "Thousand",
        [5] = "Thousand",
        [6] = "Million",
        [7] = "Million",
        [8] = "Million",
        [9] = "Billion"
    };
    
    public string Special(char second)
    {
        switch(second)
        {
            case '0':
                return "Ten";
                
            case '1':
                return "Eleven";
                
            case '2':
                return "Twelve";
                
            case '3':
                return "Thirteen";
                
            case '4':
                return "Fourteen";
                
            case '5':
                return "Fifteen";
                
            case '6':
                return "Sixteen";
                
            case '7':
                return "Seventeen";
                
            case '8':
                return "Eighteen";
                
            case '9':
                return "Nineteen";
        }
        
        throw new Exception("Faidisakjidjsad");
    }
    
    public string Reverse(string x)
    {
        var arr = x.ToCharArray();
        Array.Reverse(arr);
        
        return new string(arr);
    }
    
    public string NumberToWords(int num) {
        
        if(num == 0) return "Zero";
        
        var l = num.ToString();
    
        List<(string, int)> x = new List<(string, int)>();
        
        StringBuilder b = new StringBuilder();
        int count = 0;
        for(int i = l.Length - 1; i >= 0; i--)
        {
            count++;
            b.Append(l[i]);
        
            if(count == 3)
            {
                if(x.Count == 0)
                {
                    x.Add((Reverse(b.ToString()), count - 1));
                }
                else
                {
                    x.Add((Reverse(b.ToString()), x[x.Count - 1].Item2 + count));
                }
                b.Clear();
                count = 0;
            }
        }
    
        if(b.Length != 0)
        {
            if(x.Count == 0)
            {
                x.Add((Reverse(b.ToString()), count - 1));
            }
            else
            {
                x.Add((Reverse(b.ToString()), x[x.Count - 1].Item2 + count));
            }
        }
        
        StringBuilder total = new StringBuilder();
        x.Reverse();
        
        foreach(var item in x)
        {
            var str = item.Item1;
            var numb = item.Item2;
            bool wentin = false;
            
            switch(str.Length)
            {
                case 1:
                if(str[0] == '0') break;
                total.Append(Conversion[str[0]]);
                
                wentin = true;    
                break;
                    
                case 2:
                
                if(str[0] == '1')
                {
                    total.Append(Special(str[1]));
                    wentin = true;
                }
                else
                {
                    if(str[0] != '0')
                    {
                        total.Append(Ten[str[0]]);
                        total.Append(' ');
                        wentin = true;
                    }
                    if(str[1] != '0')
                    {                 
                        total.Append(Conversion[str[1]]);
                        wentin = true;
                    }
                }
                    
                break;
                    
                case 3:
                
                if(str[0] != '0')
                {
                    total.Append(Conversion[str[0]] + ' ' + "Hundred");
                    total.Append(' ');
                    wentin = true;
                }     
                
                if(str[1] == '1')
                {
                    total.Append(Special(str[2]));
                    wentin = true;
                }
                else
                {
                    if(str[1] != '0')
                    {
                        total.Append(Ten[str[1]]);
                        total.Append(' ');
                        wentin = true;
                    }
                    if(str[2] != '0')
                    {                 
                        total.Append(Conversion[str[2]]);
                        wentin = true;
                    }
                }
                    
                break;
            }
            
            if(!wentin) continue;
            
            total.Append(' ');
            if(Last.ContainsKey(numb))
            {
                total.Append(Last[numb]);
            }
            total.Append(' ');
                
        }
        
        return total.ToString().Replace("  ", " ").Trim();
    }
}
