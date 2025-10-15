namespace MunicipalServicesApp.DataStructures
{
    public class CustomQueue<T>
    {
        private LinkedNode<T> head;
        private LinkedNode<T> tail;
        private int count;
        public CustomQueue() { head = tail = null; count = 0; }

        public void Enqueue(T item)
        {
            var n = new LinkedNode<T>(item);
            if (tail == null) head = tail = n;
            else { tail.Next = n; tail = n; }
            count++;
        }

        public T Dequeue()
        {
            if (head == null) throw new System.InvalidOperationException("Queue empty");
            var v = head.Value;
            head = head.Next;
            if (head == null) tail = null;
            count--;
            return v;
        }

        public T Peek() => head == null ? default(T) : head.Value;
        public int Count => count;
        public bool IsEmpty => count == 0;
    }
}
