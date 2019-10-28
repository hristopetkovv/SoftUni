using System;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new CoolLinkedList();

            linkedList.AddHead(5);
            linkedList.AddHead(10);
            linkedList.AddHead(15);

            // 15 <-> 10 <-> 5

            Console.WriteLine((int)linkedList.Head.Value == 15);
            Console.WriteLine((int)linkedList.Tail.Value == 5);
            Console.WriteLine(linkedList.Count == 3);

            linkedList.AddTail(20);
            linkedList.AddTail(25);

            // 15 <-> 10 <-> 5 <-> 20 <-> 25

            linkedList.ForEach(Console.WriteLine);

            var arr = linkedList.ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine((int)linkedList.Head.Value == 15);
            Console.WriteLine((int)linkedList.Tail.Value == 25);
            Console.WriteLine(linkedList.Count == 5);

            Console.WriteLine((int)linkedList.RemoveHead() == 15);
            Console.WriteLine((int)linkedList.RemoveHead() == 10);
            Console.WriteLine((int)linkedList.Head.Value == 5);
            Console.WriteLine(linkedList.Count == 3);

            // 5 <-> 20 <-> 25

            Console.WriteLine((int)linkedList.RemoveTail() == 25);
            Console.WriteLine((int)linkedList.RemoveTail() == 20);
            Console.WriteLine((int)linkedList.RemoveTail() == 5);
            Console.WriteLine(linkedList.Count == 0);

            try
            {
                Console.WriteLine(linkedList.Head);
                Console.WriteLine(false);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(true);
            }

            linkedList = new CoolLinkedList();

            linkedList.AddTail(5);
            linkedList.AddTail(10);
            linkedList.AddTail(5);
            linkedList.AddTail(20);
            linkedList.AddTail(5);

            linkedList.Remove(5);

            Console.WriteLine((int)linkedList.Head.Value == 10);
            Console.WriteLine((int)linkedList.Tail.Value == 20);
            Console.WriteLine((int)linkedList.Count == 2);


        }
    }
}
