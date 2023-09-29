using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class SimulateQueue<T> : IEnumerable<T>
    {
        protected List<T> list;  // Creating protected generic list

        public SimulateQueue()
        {
            list = new List<T>();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => list.Count;  // Returning the number of elements contained in the list

        // Adds item to the queue.
        public void Enqueue(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            list.Add(item);
            Console.WriteLine($"{item} ställer sig i kön");
        }

        // Remove item from the queue.
        public void Dequeue()
        {
            if (Count > 0)
            {
                Console.WriteLine($"{list.First()} blir expedierad och lämnar kön");
                list.RemoveAt(0);
            }
        }
    }
}
