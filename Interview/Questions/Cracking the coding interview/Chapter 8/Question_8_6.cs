namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;

    /// <summary>
    /// Towers of Hanoi: In the classic problem of the Towers of Hanoi, you have 3 towers and N disks of
    /// different sizes which can slide onto any tower.The puzzle starts with disks sorted in ascending order
    /// of size from top to bottom (Le., each disk sits on top of an even larger one). You have the following
    /// constraints:
    /// (1) Only one disk can be moved at a time.
    /// (2) A disk is slid off the top of one tower onto another tower.
    /// (3) A disk cannot be placed on top of a smaller disk.
    /// Write a program to move the disks from the first tower to the last using stacks.
    /// </summary>
    public class Question_8_6
    {
        public static void MoveTower(Stack<int> src, Stack<int> dest, Stack<int> temp)
        {
            if (src.Count == 0)
            {
                return;
            }

            MoveTowerCount(src, dest, temp, src.Count);
        }

        private static void MoveTowerCount(Stack<int> src, Stack<int> dest, Stack<int> temp, int count)
        {
            if (count == 1)
            {
                Move(src, dest);
            }
            else if (count == 2)
            {
                Move(src, temp);
                Move(src, dest);
                Move(temp, dest);
            }
            else
            {
                MoveTowerCount(src, temp, dest, count - 1);
                Move(src, dest);
                MoveTowerCount(temp, dest, src, count - 1);
            }
        }

        private static bool CanMoveSingleDisk(Stack<int> src, Stack<int> dest)
        {
            return dest.Count == 0 || src.Peek() < dest.Peek();
        }

        private static void Move(Stack<int> src, Stack<int> dest)
        {
            dest.Push(src.Peek());
            src.Pop();
        }
    }
}
