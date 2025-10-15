using System;

namespace MunicipalServicesApp.DataStructures
{
    public class CustomSet<T> where T : IComparable<T>
    {
        private CustomBST<T, bool> bst = new CustomBST<T, bool>();
        public void Add(T item)
        {
            var existing = bst.Find(item);
            if (existing == null || existing.Equals(default(bool))) 
            {
                bst.Insert(item, true);
            }
        }
        public bool Contains(T item)
        {
            var v = bst.Find(item);
            return !(v == null || v.Equals(default(bool)));
        }
    }
}
