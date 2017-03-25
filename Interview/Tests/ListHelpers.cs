namespace Tests
{
    using System;
    using System.Runtime.Remoting.Messaging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Data_structures;

    public class ListHelpers
    {

        public static Node<T> CloneList<T>(Node<T> list)
            where T : IEquatable<T>
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            var head = new Node<T>(list.Data);
            var cur = head;
            list = list.Next;

            while (list != null)
            {
                cur.Next = new Node<T>(list.Data);
                cur = cur.Next;
                list = list.Next;
            }

            return head;
        }

        public static Node<T>CreateLinkedList<T>(params T[] items)
            where T : IEquatable<T>
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var head = new Node<T>(items[0]);
            var cur = head;
            for (var i = 1; i < items.Length; i++)
            {
                cur.Next = new Node<T>(items[i]);
                cur = cur.Next;
            }

            return head;
        }

        public static void ValidateLinkedListContent<T>(Node<T> expected, Node<T> actual)
            where T : IEquatable<T>
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            while (expected != null && actual != null)
            {
                Assert.AreEqual(expected.Data, actual.Data);
                expected = expected.Next;
                actual = actual.Next;
            }

            Assert.IsNull(expected);
            Assert.IsNull(actual);
        }
    }
}
