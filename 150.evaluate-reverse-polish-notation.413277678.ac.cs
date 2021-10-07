public class Solution {
    public int EvalRPN(string[] tokens) {
        
        Stack<int> current = new Stack<int>();
        
        for(int i = 0; i < tokens.Length; i++)
        {
            if (int.TryParse(tokens[i], out int x))
            {
                current.Push(x);
            }
            else
            {
                switch(tokens[i])
                {
                    case "+":
                        current.Push(current.Pop() + current.Pop());
                        break;
                        
                    case "-":
                        int left = current.Pop();
                        int right = current.Pop();
                        current.Push(right - left);
                        break;
                        
                    case "*":
                        current.Push(current.Pop() * current.Pop());
                        break;
                        
                    case "/":
                        int l = current.Pop();
                        int r = current.Pop();
                        current.Push(r / l);
                        break;
                }
            }
        }
        
        return current.Pop();
    }
}
