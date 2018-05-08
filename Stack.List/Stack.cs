using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.List
{
    // A Last In First Out collection implemented as a linked list
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        private System.Collections.Generic.LinkedList<T> _list = new System.Collections.Generic.LinkedList<T>();

        // Adds the specified item to the stack
        public void Push(T item)
        {
            _list.AddFirst(item);
        }
        // Removes and returns the top item from the stack
        public T Pop()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            T value = _list.First.Value;
            _list.RemoveFirst();

            return value;
        }

        // Returns the top item from the stack without removing it from the stack
        public T Peek()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            return _list.First.Value;
        }

        // The current number of items in the stack
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        // Removes all items from the stack
        public void Clear()
        {
            _list.Clear();
        }

        // Enumerates each item in the stack in LIFO order. The stack remains unaltered.
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        // Enumerates each item in the stack in LIFO order. The stack remains unaltered.
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        
    }
}
