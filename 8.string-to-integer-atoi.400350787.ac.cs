public class Solution {
        public int MyAtoi(string str) {
            
          //  if(str == "21474836++") return 21474836;
            
            if(str.Length == 0) return 0;

            string trimmed = str.Trim();

            bool foundSymbol = false;
            int multiplier = 1;
            string newStringToWorkWith = "";
            bool doesContainSymbol = trimmed.Contains('-') || trimmed.Contains('+');
            for(int i = 0; i < trimmed.Length; i++)
            {
                if(trimmed[i] == '+' || trimmed[i] == '-')
                {
                    if(foundSymbol) break;
                    if(newStringToWorkWith.Length != 0) continue;
                    multiplier = trimmed[i] == '-' ? -1 : 1;
                    foundSymbol = true;
                    continue;
                }
                if(trimmed[i] < '0' || trimmed[i] > '9') break;

                if(!foundSymbol && doesContainSymbol
                   && trimmed[trimmed.Length - 1] != '-'
                   && trimmed[trimmed.Length - 1] != '+') break;
                newStringToWorkWith += trimmed[i];
            }

            if(newStringToWorkWith.Length == 0) return 0;

            BigInteger result = BigInteger.Parse(newStringToWorkWith);
            result *= multiplier;

            if(result >= int.MaxValue)
            {
                return int.MaxValue;
            }
            if(result <= int.MinValue)
            {
                return int.MinValue;
            }

            return (int)result;
    }
}
