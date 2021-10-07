public class Solution {
    public string IntToRoman(int num) {
        Dictionary<int, string> Mapping = new Dictionary<int, string>()
            {
                [1] = "I",
                [5] = "V",
                [10] = "X",
                [50] = "L",
                [100] = "C",
                [500] = "D",
                [1000] = "M"
            };

            Dictionary<int, string> SpecialCases = new Dictionary<int, string>()
            {
                [4] = "IV",
                [9] = "IX",
                [40] = "XL",
                [90] = "XC",
                [400] = "CD",
                [900] = "CM"
            };

            List<int> numsToMatchOn = new List<int>();
            foreach (var kvp in Mapping)
            {
                numsToMatchOn.Add(kvp.Key);
            }

            string stringified = num.ToString();
            int place = (int)Math.Pow(10, stringified.Length - 1);

            string returnVal = "";

            for (int i = 0; i < stringified.Length; i++)
            {
                int digit = (int)char.GetNumericValue(stringified[i]) * place;
                place /= 10;

                if (SpecialCases.ContainsKey(digit))
                {
                    returnVal += SpecialCases[digit];
                    continue;
                }

                var diff = int.MaxValue;
                var closestMatch = 0;
                foreach (var match in numsToMatchOn)
                {
                    if (digit - match < 0) break;

                    if (diff > digit - match)
                    {
                        diff = digit - match;
                        closestMatch = match;
                    }
                }
            
                

                if(Mapping.ContainsKey(closestMatch))
                {
                    int index = numsToMatchOn.FindIndex((x) => x == closestMatch);
                    while (true)
                    {
                        returnVal += Mapping[closestMatch];
                        digit -= closestMatch;

                        if (SpecialCases.ContainsKey(digit))
                        {
                            returnVal += SpecialCases[digit];
                            digit = 0;
                        }

                        if (digit == 0) break;
                        if (digit - closestMatch < 0)
                        {
                            index--;
                            closestMatch = numsToMatchOn[index];
                        }
                    }
                }
            }

            return returnVal;
    }
}
