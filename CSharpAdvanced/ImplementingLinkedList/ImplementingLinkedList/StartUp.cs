using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 3; i++)
            {
                list.AddHead(new Node(i));
            }

            //list.Remove(2);

            list.PrintList();
        }
    }
}
