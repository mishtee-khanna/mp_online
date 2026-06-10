using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    internal class QueueDemo
    {
        public static void Main()
        {
            // Create a queue of strings
            Queue<string> queue = new Queue<string>();

            // Enqueue (add) items to the queue

            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");

            Console.WriteLine("Queue contents : ");
            foreach (string item in queue)
            {
                Console.WriteLine(item);
            }

            //Dequeue (remove) items from the queue

            Console.WriteLine("\nDequeueing items : ");
            while(queue.Count > 0)
            {
                string task = queue.Dequeue();
                Console.WriteLine("Processing task : " + task);
            }
            //Peek (look at the next item without removing it)

            queue.Enqueue("Task A");
            queue.Enqueue("Task B");

            Console.WriteLine("\nNext task to process : " + queue.Peek());
        }
    }
}
