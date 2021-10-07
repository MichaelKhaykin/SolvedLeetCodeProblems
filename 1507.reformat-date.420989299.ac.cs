public class Solution {
    
    Dictionary<string, string> monthmap = new Dictionary<string, string>()
    {
        ["Jan"] = "01",
        ["Feb"] = "02",
        ["Mar"] = "03",
        ["Apr"] = "04",
        ["May"] = "05",
        ["Jun"] = "06",
        ["Jul"] = "07",
        ["Aug"] = "08",
        ["Sep"] = "09",
        ["Oct"] = "10",
        ["Nov"] = "11",
        ["Dec"] = "12",
    };
    
    public string ReformatDate(string date) {
       
        
        StringBuilder day = new StringBuilder();
        
        int i = 0;
        
        while(date[i] != ' ')
        {
            if(date[i] >= '0' && date[i] <= '9')
            {
                day.Append(date[i]);
            }
            i++;
        }
        
        i++;
        
        StringBuilder month = new StringBuilder();
        while(date[i] != ' ')
        {
            month.Append(date[i]);
            i++;
        }
        
        i++;
        StringBuilder year = new StringBuilder();
        while(i < date.Length)
        {
            year.Append(date[i]);
            i++;
        }
        
        var dayS = day.Length == 1 ? "0" + day.ToString() : day.ToString();
        
        return $"{year.ToString()}-{monthmap[month.ToString()]}-{dayS}";
    }
}
