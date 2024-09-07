namespace Questions.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Stack Min: How would you design a stack which, in addition to
    /// push and pop, has a function min which returns the minimum element?
    /// Push, pop and min should all operate in 0(1) time.
    /// </summary>
    [SuppressMessage("Documentation Rules", "SA1649")]
    [SuppressMessage("Microsoft.Naming", "CA1711")]
    public class MinStack<T>
        where T : IComparable<T>
    {
        // A better solution would be where this grows dynamically.
        private const int maxItems = 100;

        private readonly T[] stackItems;
        private readonly T[] minItems;

        private int numItems;
        private int numMinItems;

        public MinStack()
        {
            this.stackItems = new T[maxItems];
            this.minItems = new T[maxItems];
        }

        public void Push(T item)
        {
            if (this.numItems == maxItems)
            {
                throw new InvalidOperationException(@"Stack is full.");
            }

            this.stackItems[this.numItems++] = item;
            if (this.numMinItems == 0 ||
                this.minItems[this.numMinItems].CompareTo(item) >= 0)
            {
                this.minItems[this.numMinItems++] = item;
            }
        }

        public T Pop()
        {
            if (numItems == 0)
            {
                throw new InvalidOperationException(@"Stack does not contain any items.");
            }

            var itemRemoved = this.stackItems[this.numItems - 1];
            if (itemRemoved.CompareTo(this.GetMinimum()) == 0)
            {
                this.numMinItems--;
            }

            this.numItems--;
            return itemRemoved;
        }

        public T GetMinimum()
        {
            if (numItems == 0)
            {
                throw new InvalidOperationException(@"Stack does not contain any items.");
            }

            return this.minItems[this.numMinItems - 1];
        }
    }
}
