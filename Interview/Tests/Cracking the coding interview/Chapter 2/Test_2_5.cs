namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    [TestClass]
    public class Test_2_5
    {
        [TestMethod]
        public void Question_2_5_BasicCases()
        {
            Validate(617, 295);
        }

        [TestMethod]
        public void Question_2_5_InvalidCases()
        {
            var node = new Node<Digit>(new Digit(1));
            TestHelpers.AssertExceptionThrown(() => Question_2_5.SumLists(null, node), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_2_5.SumLists(node, null), typeof(ArgumentNullException));
        }

        [TestMethod]
        public void Question_2_5_EdgeCases()
        {
            Validate(1, 1000);
            Validate(1, 999);
            Validate(99999, 9);
            Validate(9, 9);
            Validate(0, 0);
        }

        private static void Validate(int num1, int num2)
        {
            var numberAsList1 = CreateDigitList(num1, reversed: true);
            var numberAsList2 = CreateDigitList(num2, reversed: true);
            var expected = CreateDigitList(num1 + num2, reversed: true);
            var result = Question_2_5.SumLists(numberAsList1, numberAsList2);
            ListHelpers.ValidateLinkedListContent(expected, result);
        }

        private static Node<Digit> CreateDigitList(int num, bool reversed = false)
        {
            var list = CreateList(num, reversed);
            return ListHelpers.CreateLinkedList(list.Select(n => new Digit(n)).ToArray());
        }

        private static List<int> CreateList(int num, bool reversed = false)
        {
            var digits = new List<int>();

            do
            {
                digits.Add(num % 10);
                num /= 10;
            }
            while (num > 0);

            if (!reversed)
            {
                digits.Reverse();
            }

            return digits;
        }
    }
}
