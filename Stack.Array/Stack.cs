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
            // _size == length ... growth
        }
    }
}
