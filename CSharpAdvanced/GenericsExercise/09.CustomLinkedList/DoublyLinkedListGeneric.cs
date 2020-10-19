using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CustomLinkedList
{
    class DoublyLinkedListGeneric<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public bool IsReversed { get; set; }

        public void AddFirst(Node<T> newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }

        }

        public void AddLast(Node<T> newTail)
        {
            if (Tail == null)
            {
                Tail = newTail;
                Head = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
        }

        public Node<T> RemoveFirst()
        {
            var oldHead = this.Head;
            this.Head = this.Head.Next;
            Head.Previous = null;
            return oldHead;
        }

        public Node<T> RemoveLast()
        {
            var oldTail = this.Tail;
            Tail = this.Tail.Previous;
            Tail.Next = null;
            return oldTail;
        }

        public void ForEach(Action<Node<T>> action)
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public Node<T>[] ToArray()
        {
            List<Node<T>> list = new List<Node<T>>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }
    }
}