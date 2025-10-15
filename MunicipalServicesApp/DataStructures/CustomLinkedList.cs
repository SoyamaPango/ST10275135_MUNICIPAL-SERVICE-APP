using System;
using System.Collections;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class LinkedNode<T>
    {
        public T Value;
        public LinkedNode<T> Next;
        public LinkedNode(T v) { Value = v; Next = null; }
    }

    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private LinkedNode<T> head;
        private LinkedNode<T> tail;
        private int count;
        public CustomLinkedList() { head = tail = null; count = 0; }

        public void AddLast(T value)
        {
            var n = new LinkedNode<T>(value);
            if (head == null) head = tail = n;
            else { tail.Next = n; tail = n; }
            count++;
        }

        public void AddFirst(T value)
        {
            var n = new LinkedNode<T>(value);
            if (head == null) head = tail = n;
            else { n.Next = head; head = n; }
            count++;
        }

        public int Count => count;

        public IEnumerator<T> GetEnumerator()
        {
            var cur = head;
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Clear() { head = tail = null; count = 0; }
    }
}
