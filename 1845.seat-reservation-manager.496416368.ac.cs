public class SeatManager {

    SortedSet<int> set;
    public SeatManager(int n) {
        set = new SortedSet<int>();
        for(int i = 1; i <= n; i++)
        {
            set.Add(i);
        }
    }
    
    public int Reserve() {
        var stored = set.First();
        set.Remove(stored);
        return stored;
    }
    
    public void Unreserve(int seatNumber) {
        set.Add(seatNumber);
    }
}

/**
 * Your SeatManager object will be instantiated and called as such:
 * SeatManager obj = new SeatManager(n);
 * int param_1 = obj.Reserve();
 * obj.Unreserve(seatNumber);
 */
