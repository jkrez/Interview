namespace Questions.Cracking_the_coding_interview
{
    using System;

    /// <summary>
    /// Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
    ///  steps at a time.Implement a method to count how many possible ways the child can run up the
    /// stairs.
    /// </summary>
    public class Question_8_1
    {
        // Time: O(n)
        // Space: O(1)
        public static int NumberOfWays(int numberOfSteps)
        {
            if (numberOfSteps < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfSteps));
            }

            switch (numberOfSteps)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 4;
            }

            int n;
            int nm1 = n = 4;
            int nm2 = 2;
            int nm3 = 1;
            for (int i = 3; i <= numberOfSteps; i++)
            {
                n = nm1 + nm2 + nm3;
                nm3 = nm2;
                nm2 = nm1;
                nm1 = n;
            }

            return n;
        }
    }
}
