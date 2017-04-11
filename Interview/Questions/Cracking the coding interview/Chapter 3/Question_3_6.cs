namespace Questions.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Animal Shelter: An animal shelter, which holds only dogs and cats,
    /// operates on a strictly"first in, first out" basis. People must adopt
    /// either the "oldest" (based on arrival time) of all animals at the
    /// shelter, or they can select whether they would prefer a dog or a cat
    /// (and will receive the oldest animal of that type). They cannot select
    /// which specific animal they would like. Create the data structures to
    /// maintain this system and implement operations such as enqueue,
    /// dequeueAny, dequeueDog, and dequeueCat. You may use the built-in
    /// Linked List data structure
    /// </summary>
    public class AnimalShelter
    {
        private LinkedList<Cat> cats;
        private LinkedList<Dog> dogs;

        public AnimalShelter()
        {
            this.cats = new LinkedList<Cat>();
            this.dogs = new LinkedList<Dog>();
        }

        public void Enqueue(Animal animal)
        {
            var dog = animal as Dog;
            var cat = animal as Cat;

            if (cat != null)
            {
                this.cats.AddLast(cat);
            }
            else if (dog != null)
            {
                this.dogs.AddLast(dog);
            }
            else
            {
                throw new InvalidOperationException(@"The shelter doesn't accept this animal.");
            }
        }

        public Animal DequeueAny()
        {
            if (this.cats.Count == 0 && this.dogs.Count == 0)
            {
                throw new InvalidOperationException(@"There are no anmials at the shelter.");
            }

            var catEnqueueTime = this.cats.First?.Value?.ArrivalTime ?? DateTimeOffset.MaxValue;
            var dogEnqueueTime = this.dogs.First?.Value?.ArrivalTime ?? DateTimeOffset.MaxValue;

            if (dogEnqueueTime < catEnqueueTime)
            {
                return DequeueDog();
            }
            else
            {
                return DequeueCat();
            }
        }

        public Cat DequeueCat()
        {
            if (this.cats.Count == 0)
            {
                throw new InvalidOperationException(@"No cats at the shelter");
            }

            var cat = this.cats.First.Value;
            this.cats.RemoveFirst();
            return cat;
        }

        public Dog DequeueDog()
        {
            if (this.dogs.Count == 0)
            {
                throw new InvalidOperationException(@"No dogs at the shelter");
            }

            var dog = this.dogs.First.Value;
            this.dogs.RemoveFirst();
            return dog;
        }
    }

    [SuppressMessage("Maintainability Rules", "SA1402")]
    public class Cat : Animal
    {
        public Cat(int id)
            : base(id)
        {
        }
    }

    [SuppressMessage("Maintainability Rules", "SA1402")]
    public class Dog : Animal
    {
        public Dog(int id)
            : base(id)
        {
        }
    }

    [SuppressMessage("Maintainability Rules", "SA1402")]
    [DebuggerDisplay("Id = {Id}, ArrivalTime = {DebuggerDisplay,nq}")]
    public abstract class Animal
    {
        protected Animal(int id)
        {
            Id = id;
            ArrivalTime = DateTimeOffset.UtcNow;
        }

        public int Id { get; }

        public DateTimeOffset ArrivalTime { get; }

        [SuppressMessage("Microsoft.Performance", "CA1811")]
        private string DebuggerDisplay => $"{ArrivalTime:HH:mm:ss.fff}";
    }
}
