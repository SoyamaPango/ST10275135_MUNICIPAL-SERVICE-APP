namespace MunicipalServicesApp.DataStructures
{
    public class CustomStack<T>
    {
        private LinkedNode<T> head;
        private int count;
        public CustomStack() { head = null; count = 0; }
        public void Push(T item) { var n = new LinkedNode<T>(item); n.Next = head; head = n; count++; }
        public T Pop() { if (head == null) throw new System.InvalidOperationException("Stack empty"); var v = head.Value; head = head.Next; count--; return v; }
        public T Peek() => head == null ? default(T) : head.Value;
        public int Count => count;
        public bool IsEmpty => count == 0;
    }
}
