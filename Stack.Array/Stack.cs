using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Array
{
    // A Last In First Out collection implemented as an array.
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        // The array of items contained in the stack. Initialized to 0 length, will grow as needed during Push
        T[] _items = new T[0];

        // The current number of items in the stack
        int _size;

        // Adds the specified item to the stack
        public void Push(T item)
        {
            // _size = 0 ... first push
            // _size == length ... growth boundry
            if(_size == _items.Length)
            {
                // initial size of 4, otherwise double the current length
                int newLength = _size == 0 ? 4 : _size * 2;
                // allocate, copy and assign the new array
                T[] newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            // add the item to the stack array and increase the size
            _items[_size] = item;
            _size++;
        }
        // Removes and returns the top item from the stack
        public T Pop()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            _size--;
            return _items[_size];
        }
        // Returns the top item from the stack without removing it from the stack
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            return _items[_size - 1];
        }

        // The current number of items in the stack
        public int Count
        {
            get
            {
                return _size;
            }
        }

        // Removes all items from the stack, doesn't clear array.
        public void Clear()
        {
            _size = 0;
        }

        // Enumerates each item in the stack in Last In First Out. The stack remains unaltered.
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for(int i = _size-1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }
        // Enumerates each item in the stack in Last In First Out order.
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
