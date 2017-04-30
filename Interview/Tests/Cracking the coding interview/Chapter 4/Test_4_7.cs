namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;

    [TestClass]
    public class Test_4_7
    {
        [TestMethod]
        public void Question_4_7_BasicCases()
        {
            // The dependencies list is converted to pairs eg "a", "b" -> (a, b)
            // Depends (a, b) means project b depends on a being built first.

            // Base edge cases.
            Validate(CreateProjectList(), /* dependencies */ CreateDependencies());

            // Two project orderings
            Validate(CreateProjectList("a", "b"), CreateDependencies(), "a", "b");
            Validate(CreateProjectList("a", "b"), CreateDependencies("a", "b"), "a", "b");
            Validate(CreateProjectList("a", "b"), CreateDependencies("b", "a"), "b", "a");
            // Simple cycle.
            Validate(CreateProjectList("a", "b"), CreateDependencies("b", "a", "a", "b"));

            // Three project tests.
            Validate(CreateProjectList("a", "b", "c"), /* dependencies */ CreateDependencies(), "a", "b", "c");
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("a", "b"), "a", "c", "b");
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a"), "b", "c", "a");
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("a", "b", "b", "c"), "a", "b", "c");
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a", "c", "b"), "c", "b", "a");
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a", "c", "a"), "b", "c", "a");
            // Complex cycle.
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a", "c", "b", "a", "c"));
        }

        [TestMethod]
        public void Question_4_7_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_7.FindBuildOrder(null, CreateDependencies("a", "b")), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_4_7.FindBuildOrder(CreateProjectList("a"), null), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_4_7.FindBuildOrder(CreateProjectList("a"), CreateDependencies("a", "b")), typeof(ArgumentOutOfRangeException));
        }

        private static void Validate(List<string> projects, Dictionary<string, string> dependencies, params string[] expectedOrder)
        {
            var result = Question_4_7.FindBuildOrder(projects, dependencies);
            Assert.IsNotNull(result);
            var expectedProjectsOrder = CreateProjectList(expectedOrder);
            Assert.IsTrue(expectedProjectsOrder.SequenceEqual(result));
        }

        private static List<string> CreateProjectList(params string[] projects)
        {
            return new List<string>(projects);
        }

        private static Dictionary<string, string> CreateDependencies(params string[] dependencies)
        {
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < dependencies?.Length; i += 2)
            {
                dict.Add(dependencies[i], dependencies[i + 1]);
            }

            return dict;
        }
    }
}
