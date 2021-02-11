using System;
using System.Collections.Generic;

namespace Task_3
{
    namespace A
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
            }
            public override string ToString()
            {
                return $"{Data}";
            }
        }

        class LinkedList
        {
            Node head;
            Node tail;

            public int Count { get; set; }

            public void Add(int data)
            {
                Node node = new Node(data);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
                Count++;
            }
            public void AddFirst(int data)
            {
                Node node = new Node(data);

                node.Next = head;
                head = node;

                if (Count == 0)
                    tail = head;

                Count++;
            }
            public void Clear()
            {
                Count = 0;
                head = null;
                tail = null;
            }
            public bool Contains(int data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public void Print()
            {
                Node current = head;
                int i = 1;
                while (current != null)
                {
                    Console.WriteLine($"{i} - {current}");
                    current = current.Next;
                    i++;
                }
            }

            public Node Max()
            {
                Node current = head;
                Node max = null;
                while (current != null)
                {
                    if (max == null || current.Data > max.Data) max = current;
                    current = current.Next;
                }
                return max;
            }

            public Node Min()
            {
                Node current = head;
                Node min = null;
                while (current != null)
                {
                    if (min == null || current.Data < min.Data) min = current;
                    current = current.Next;
                }
                return min;
            }

            public Node Middle()
            {
                if (Count == 0) return null;

                int middleIndex = Count / 2;
                Node current = head;
                Node mid = null;
                int i = 0;
                while (current != null)
                {
                    if (i == middleIndex) return mid;
                    current = current.Next;
                }

                return mid;
            }

            public bool Remove(int data)
            {
                Node current = head, prev = null;

                if (head != null)
                {
                    while (current != null)
                    {
                        if (current.Data == data)
                        {
                            if (prev != null && current.Next != null)
                            {
                                prev.Next = current.Next;
                            } else if (prev == null)
                            {
                                head = current.Next;
                            } else if (current.Next == null)
                            {
                                tail = prev;
                            }

                            Count--;

                            return true;
                        }

                        prev = current;
                        current = current.Next;
                    }
                }
                return false;
            }

            public void Reverse()
            {
                Node prev = head;
                head = head.Next;
                Node current = head;
                prev.Next = null;
                while (head != null)
                {
                    head = head.Next;
                    current.Next = prev;
                    prev = current;
                    current = head;
                }
                head = prev;
            }
        }

        class MainClass
        {
            public static void Main()
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.AddFirst(3);
                linkedList.Add(4);
                linkedList.Print();
                Console.WriteLine(linkedList.Remove(3));
                linkedList.Print();
                linkedList.Reverse();
                linkedList.Print();
                Console.ReadKey();
            }
        }
    }
}