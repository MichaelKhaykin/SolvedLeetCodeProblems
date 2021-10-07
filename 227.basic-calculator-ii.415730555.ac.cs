public class Solution {
   
    public Queue<string> ShuntingYard(string input)
    {
        static string GetNumber(ReadOnlySpan<char> x, int i)
        {
            int current = i;
            while (current < x.Length && x[current] >= '0' && x[current] <= '9') current++;
            return x.Slice(i, current - i).ToString();
        }

        var spanny = input.AsSpan();
        Queue<string> output = new Queue<string>();
        Stack<char> operators = new Stack<char>();

        Dictionary<char, int> Precedence = new Dictionary<char, int>()
        {
            ['+'] = 1,
            ['-'] = 1,
            ['*'] = 2,
            ['/'] = 2
        };

        for (int i = 0; i < input.Length; i++)
        {
            if(input[i] == ' ') continue;
            
            var item = input[i];

            var len = GetNumber(spanny, i);

            if (len.Length > 0)
            {
                output.Enqueue(len);
                i += len.Length - 1;
                continue;
            }

            var cPrec = Precedence[item];

            while (operators.Count > 0 && Precedence[operators.Peek()] >= cPrec)
            {
                output.Enqueue(operators.Pop().ToString());
            }
            operators.Push(item);
        }

        while (operators.Count > 0)
        {
            output.Enqueue(operators.Pop().ToString());
        }

        return output;
    }
    public int Evaluate(Queue<string> input)
    {
        Stack<int> nums = new Stack<int>();
        while (input.Count > 0)
        {
            var deq = input.Dequeue();

            if (int.TryParse(deq, out int x))
            {
                nums.Push(x);
            }
            else
            {
                var l = nums.Pop();
                var r = nums.Pop();

                switch (deq)
                {
                    case "+":
                        nums.Push(r + l);
                        break;

                    case "-":
                        nums.Push(r - l);
                        break;

                    case "*":
                        nums.Push(r * l);
                        break;

                    case "/":
                        nums.Push(r / l);
                        break;
                }
            }
        }
        return nums.Pop();
    }
    
    public int Calculate2(string s)
    {
        return Evaluate(ShuntingYard(s));
    }
    
    
    
    public int Calculate(String s) {
        
        static bool IsDigit(char num)
        {
            return num >= '0' && num <= '9';
        }
        
        
        int len = s.Length;
        if (s == null || len == 0) return 0;
        Stack<int> stack = new Stack<int>();
        int currentNumber = 0;
        char operation = '+';
        for (int i = 0; i < len; i++) {
            char currentChar = s[i];
            if (IsDigit(currentChar)) {
                currentNumber = (currentNumber * 10) + (currentChar - '0');
            }
            if (!IsDigit(currentChar) && currentChar != ' ' || i == len - 1) {
                if (operation == '-') {
                    stack.Push(-currentNumber);
                }
                else if (operation == '+') {
                    stack.Push(currentNumber);
                }
                else if (operation == '*') {
                    stack.Push(stack.Pop() * currentNumber);
                }
                else if (operation == '/') {
                    stack.Push(stack.Pop() / currentNumber);
                }
                operation = currentChar;
                currentNumber = 0;
            }
        }
        int result = 0;
        while (stack.Count > 0) {
            result += stack.Pop();
        }
        return result;
    }
}
