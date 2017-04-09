namespace Questions.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Stack of Plates: Imagine a (literal) stack of plates. If the stack gets
    /// too high, it might topple. Therefore, in real life, we would likely
    /// start a new stack when the previous stack exceeds some threshold.
    /// Implement a data structure SetOfStacks that mimics this. SetOfStacks
    /// should be composed of several stacks and should create a new stack once
    /// the previous one exceeds capacity. SetOfStacks. push () and SetOfStacks.
    /// pop () should behave identically to a single stack (that is, pop ( )
    /// should return the same values as it would if there were just a single
    /// stack).
    ///
    /// FOLLOW UP
    /// Implement a function popAt(int index) which performs a pop operation on
    /// a specific sub-stack.
    /// </summary>
    [SuppressMessage("Documentation Rules", "SA1649")]
    [SuppressMessage("Microsoft.Naming", "CA1711")]
    public class SetOfStacks<T>
        where T : IComparable<T>
    {
        private const int maxSizePerStack = 2;
        private readonly List<T[]> stacks;
        private int numItems;

        public SetOfStacks()
        {
            stacks = new List<T[]>();
        }

        public void Push(T item)
        {
            var stackNumber = this.numItems / maxSizePerStack;
            var stackIndex = this.numItems % maxSizePerStack;
            if (stackIndex == 0)
            {
                this.stacks.Add(new T[maxSizePerStack]);
            }

            this.stacks[stackNumber][stackIndex] = item;
            this.numItems++;
        }

        public T Pop()
        {
            this.numItems--;
            var stackNumber = this.numItems / maxSizePerStack;
            var stackIndex = this.numItems % maxSizePerStack;
            var item = this.stacks[stackNumber][stackIndex];
            if (stackIndex == 0)
            {
                this.stacks.Remove(this.stacks[stackNumber]);
            }

            return item;
        }

        public T PopAt(int index)
        {
            return default(T);
        }
    }
}
