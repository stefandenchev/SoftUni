using _08.CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            List<int> addCollectionIndexes = new List<int>();

            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            List<int> addRemoveCollectionIndexes = new List<int>();
            List<string> addRemoveCollectionRemoved = new List<string>();

            MyList myList = new MyList();
            List<int> myListIndexes = new List<int>();
            List<string> myListRemoved = new List<string>();

            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            var elements = input.Split();

            for (int i = 0; i < elements.Length; i++)
            {
                addCollectionIndexes.Add(addCollection.Add(elements[i]));
                addRemoveCollectionIndexes.Add(addRemoveCollection.Add(elements[i]));
                myListIndexes.Add(myList.Add(elements[i]));
            }

            for (int i = 0; i < n; i++)
            {
                addRemoveCollectionRemoved.Add(addRemoveCollection.Remove());
                myListRemoved.Add(myList.Remove());
            }

            Console.WriteLine(String.Join(" ", addCollectionIndexes));
            Console.WriteLine(String.Join(" ", addRemoveCollectionIndexes));
            Console.WriteLine(String.Join(" ", myListIndexes));
            Console.WriteLine(String.Join(" ", addRemoveCollectionRemoved));
            Console.WriteLine(String.Join(" ", myListRemoved));
        }
    }
}
