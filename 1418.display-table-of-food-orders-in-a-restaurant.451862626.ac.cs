public class Solution {
    
       public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
        {

            HashSet<string> tableNumbers = new HashSet<string>();

            Dictionary<string, Dictionary<string, int>> map = new Dictionary<string, Dictionary<string, int>>();

            HashSet<string> allFoods = new HashSet<string>();

            HashSet<string> headers = new HashSet<string>();

            foreach (var order in orders)
            {
                var customerName = order[0];
                var tableNumber = order[1];
                var foodItem = order[2];

                headers.Add(foodItem);
                tableNumbers.Add(tableNumber);

                if (map.ContainsKey(tableNumber) == false)
                {
                    map.Add(tableNumber, new Dictionary<string, int>());
                }

                if (map[tableNumber].ContainsKey(foodItem) == false)
                {
                    map[tableNumber].Add(foodItem, 0);
                }

                map[tableNumber][foodItem]++;

                allFoods.Add(foodItem);
            }

            var arr = allFoods.ToArray();
            Array.Sort(arr, StringComparer.Ordinal);

            List<string> sortedAllFoods = new List<string>(arr);

            tableNumbers = tableNumbers.Select((x) => int.Parse(x)).OrderBy((x) => x).Select((x) => x.ToString()).ToHashSet();

            List<IList<string>> strings = new List<IList<string>>();

            arr = headers.ToArray();
            Array.Sort(arr, StringComparer.Ordinal);
            var l = new List<string>(arr);
            l.Insert(0, "Table");
            strings.Add(l);


            foreach (var num in tableNumbers)
            {
                var listOfFoods = map[num];
                var copy = listOfFoods.Keys.Select((t) => t).ToArray();
                Array.Sort(copy, StringComparer.Ordinal);

                Dictionary<string, int> fix = new Dictionary<string, int>();
                for(int i = 0; i < copy.Length; i++)
                {
                    fix.Add(copy[i], listOfFoods[copy[i]]);
                }

                List<string> current = new List<string>()
                {
                    num
                };

                int index = 0;

                foreach (var kvp in fix)
                {
                    while (index < sortedAllFoods.Count && sortedAllFoods[index] != kvp.Key)
                    {
                        current.Add("0");
                        index++;
                    }

                    current.Add($"{kvp.Value}");
                    index++;
                }

                while (index < sortedAllFoods.Count)
                {
                    current.Add("0");
                    index++;
                }

                strings.Add(current);
            }

            return strings;
        }
}
