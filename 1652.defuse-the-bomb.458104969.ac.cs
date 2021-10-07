public class Solution {
    public int[] Decrypt(int[] code, int k) {
        
        if(k == 0) return new int[code.Length];
        if(k > 0) return ComputeNextNumbers(code, k);
        
        for(int i = 0; i < code.Length / 2; i++)
        {
            var temp = code[i];
            code[i] = code[code.Length - 1 - i];
            code[code.Length - 1 - i] = temp;
        }
        
        var result = ComputeNextNumbers(code, k * -1);
        
        for(int i = 0; i < code.Length / 2; i++)
        {
            var temp = result[i];
            result[i] = result[code.Length - 1 - i];
            result[code.Length - 1 - i] = temp;
        }
        
        return result;
    }
    
    public int[] ComputeNextNumbers(int[] code, int k)
    {
        var initialSum = 0;
        for(int i = 1; i < k + 1; i++)
        {
            initialSum += code[i];
        }
        int initialSumIndex = (k + 1) % code.Length;

        int[] returnArr = new int[code.Length];

        for(int i = 0; i < code.Length; i++)
        {
            var saved = code[i];
            returnArr[i] = initialSum;

            initialSum -= code[(i + 1) % code.Length];
            initialSum += code[initialSumIndex];

            initialSumIndex++;
            initialSumIndex %= code.Length;
        }

        return returnArr;
    }
}
