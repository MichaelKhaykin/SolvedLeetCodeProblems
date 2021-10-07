public class Solution {
    public int CountHomogenous(string s) {
        int moduloBy = (int)Math.Pow(10, 9) + 7;
       
        long total = 0;
        int current = 1;
        
        for(int i = 1; i < s.Length; i++){
            
            if(s[i] != s[i - 1]){
                total += Sum(current);
                current = 1;
            }
            else{
                current++;
            }
        }
        
        total += Sum(current);
        
        return (int)(total % moduloBy);
    }
    
    public int NChooseK(int n, int k){
        var nFactorial = Factorial(n);
        var kFactorial = Factorial(k);
        var nMinusKFactorial = Factorial(n - k);
        
        return nFactorial / (kFactorial * nMinusKFactorial);
    }
    
    public int Factorial(int n){
        int copy = 1;
        for(int i = 0; i < n; i++){
            copy *= (n - i);
        }
        return copy;
    }
    
    private long Sum(int n){
        long res = 0;
        while(n > 0)
        {
            res += n--;
        }
        return res;
    }
}
