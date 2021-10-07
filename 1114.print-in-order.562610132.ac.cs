public class Foo {

    object locker = new object();
    
    bool firstCalled = false;
    bool secondCalled = false;
   
    public Foo() {
        
    }

    public void First(Action printFirst) {
        
        // printFirst() outputs "first". Do not change or remove this line.
        printFirst();
        
        lock(locker)
        {
            firstCalled = true;
        }
    }

    public void Second(Action printSecond) {
        
        while(!firstCalled) {}
        
        // printSecond() outputs "second". Do not change or remove this line.
        printSecond();
        
        lock(locker)
        {
            secondCalled = true;
        }
    }

    public void Third(Action printThird) {
        
        while(!secondCalled) {}
        
        // printThird() outputs "third". Do not change or remove this line.
        printThird();
    }
}
