namespace Questions.Data_structures
{
    using System;
    using System.Diagnostics;

    // This class definition is taken from the book and adapted to C#.
    [DebuggerDisplay("Data = {Data}")]
    public class Node<T>
        where T : IEquatable<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public void AppendToTail(T data)
        {
            Node<T> end = new Node<T>(data);
            Node<T> n = this;

            while (n.Next != null)
            {
                n = n.Next;
            }

            n.Next = end;
        }
    }
}
