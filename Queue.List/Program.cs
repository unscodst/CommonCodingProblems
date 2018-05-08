using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.List
{

    // A First In First Out collection

    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        // The queued items - the Last list item is the newest queue item, the First is the oldest. This is so LinkedList<T>.GetEnumerator simply works
        System.Collections.Generic.LinkedList<T> _items = new System.Collections.Generic.LinkedList<T>();
    }
}
