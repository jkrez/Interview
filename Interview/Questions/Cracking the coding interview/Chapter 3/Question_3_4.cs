namespace Questions.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Queue via Stacks: Implement a MyQueue class which implements a
    /// queue using two stacks.
    /// </summary>
    [SuppressMessage("Documentation Rules", "SA1649")]
    [SuppressMessage("Microsoft.Naming", "CA1711")]
    public class QueueFromStacks<T>
        where T : IComparable<T>
    {
        private readonly Stack<T> stackPushTo;
        private readonly Stack<T> stackPopFrom;
        private int numItems;

        private bool itemsInPushStack => this.stackPopFrom.Count == 0;

        public QueueFromStacks()
        {
            this.stackPushTo = new Stack<T>();
            this.stackPopFrom = new Stack<T>();
        }

        public void Push(T item)
        {
            if (!this.itemsInPushStack)
            {
                this.MoveItemsToStack(this.stackPushTo, this.stackPopFrom);
            }

            this.stackPushTo.Push(item);
            this.numItems++;
        }

        public T Pop()
        {
            if (this.numItems == 0)
            {
                throw new InvalidOperationException(@"There are no items in the stack.");
            }

            if (this.itemsInPushStack)
            {
                this.MoveItemsToStack(this.stackPopFrom, this.stackPushTo);
            }

            this.numItems--;
            return this.stackPopFrom.Pop();
        }

        private void MoveItemsToStack(Stack<T> dest, Stack<T> src)
        {
            while (src.Count != 0)
            {
                dest.Push(src.Pop());
            }
        }
    }
}
