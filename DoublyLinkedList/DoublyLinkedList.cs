using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DoublyLinkedList
{
    // A linked list collection capable of basic operations such as Add, Remove, Find and Enumerate
    public class LinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        // The first node in the list of null if empty
        public LinkedListNode<T> Head
        {
            get;
            private set;
        }
        /// <summary>
        /// The last node in the list of null if empty
        /// </summary>
        public LinkedListNode<T> Tail
        {
            get;
            private set;
        }

        #region Add First
        // Adds the specified value to the start of the linked list
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        // Add the specified node to the start of the linked list
        public void AddFirst(LinkedListNode<T> node)
        {
            // Save off the head node so we don't lose it
            LinkedListNode<T> temp = Head;
            // Point head to the new node
            Head = node;
            // Insert the rest of the list behind the head
            Head.Next = temp;
            if (Count == 0)
            {
                // If the list was empty then Head and Tail should both point to the new node.
                Tail = Head;
            }
            else
            {
                // Before: Head -------> 5 <-> 7 -> null
                // After:  Head -> 3 <-> 5 <-> 7 -> null
                // temp.Previous was null, now Heads
                temp.Previous = Head;
            }
            Count++;
        }
        #endregion

        #region Add Last
        // Add the value to the end of the list
        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        // Add the specified node to the end of the linked list
        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            // Before: Head -> 3 <-> 5 -> null
            // After:  Head -> 3 <-> 5 <-> 7 -> null
            // 7.Previous = 5
            node.Previous = Tail;
            Count++;
        }
        #endregion

        #region Remove
        // Removes the first node from the list
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                // Before: Head -> 3 <-> 5
                // After:  Head ------> 5

                // Head -> 3 -> null
                // Head ------> null
                Head = Head.Next;
                Count--;
                if (Count == 0)
                {
                    Tail = null;
                }
                else
                {
                    // 5.Previous was 3, now null
                    Head.Previous = null;
                }
            }
        }

        // Removes the last node from the list
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    // Before: Head --> 3 <-> 5 <-> 7
                    //         Tail = 7
                    // After:  Head --> 3 <-> 5 <-> null
                    //         Tail = 5
                    // Null out 5's Next Pointer
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }
                Count--;
            }
        }
        #endregion

        #region ICollection

        // The number of items currently in the list
        public int Count { get; private set; }

        // Adds the specified value to the front of the list
        public void Add(T item)
        {
            AddFirst(item);
        }

        // Returns true if the list containes the specified item, false otherwise.
        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // Copies the node values into the specified array.
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }
        // True if the collection is readonly, false otherwise.
        public bool IsReadOnly
        {
            get { return false; }
        }

        // Removes the first occurance of the item from the list (searching from Head to Tail).
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;
            // 1: Empty List - do nothing
            // 2: Single node: (previous is null)
            // 3: Many nodes
            //  a: node to remove is the first node
            //  b: node to remove is the middle or last

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // it's a node in the middle or end
                    if (previous != null)
                    {
                        // Case 3b
                        // Before: Head -> 3 -> 5 -> 7
                        // After:  Head -> 3 ------> 7
                        previous.Next = current.Next;

                        // it was the end - so update Tail
                        if (current.Next == null)
                        {
                            Tail = previous;
                        } else
                        {
                            // Before: Head -> 3 <-> 5 <-> 7 -> null
                            // After:  Head -> 3 <-------> 7 -> null
                            // previous = 3
                            // current = 5
                            // current.next = 7
                            // so... 7.Previous = 3
                            current.Next.Previous = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        // Case 2 or 3a
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        #endregion
    }
}
