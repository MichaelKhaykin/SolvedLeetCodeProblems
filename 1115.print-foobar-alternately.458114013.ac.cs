using System.Threading.Tasks;

public class FooBar {
    private int n;
    
    private TaskCompletionSource<bool> semaphore1;
    private TaskCompletionSource<bool> semaphore2;

    public FooBar(int n) {
        this.n = n;
    
        semaphore1 = new TaskCompletionSource<bool>();
        semaphore2 = new TaskCompletionSource<bool>();
        semaphore2.SetResult(true);
    }

    public void Foo(Action printFoo) {
        
        for (int i = 0; i < n; i++) 
        {
            semaphore2.Task.Wait();    
        	printFoo();
            semaphore2 = new TaskCompletionSource<bool>();
            semaphore1.SetResult(true);
        }
    }

    public void Bar(Action printBar) {
        
        for (int i = 0; i < n; i++) 
        {
            semaphore1.Task.Wait();
        	printBar();
            semaphore1 = new TaskCompletionSource<bool>();
            semaphore2.SetResult(true);
        }
    }
}
