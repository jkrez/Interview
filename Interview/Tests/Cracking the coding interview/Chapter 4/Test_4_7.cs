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
            Validate(CreateProjectList(), /* dependencies */ CreateDependencies(), CreateProjectList(), CreateProjectList());

            // Two project orderings.
            Validate(CreateProjectList("a", "b"), CreateDependencies(), CreateProjectList("a", "b"), CreateProjectList("a", "b"));
            Validate(CreateProjectList("a", "b"), CreateDependencies("a", "b"), CreateProjectList("a", "b"), CreateProjectList("a", "b"));
            Validate(CreateProjectList("a", "b"), CreateDependencies("b", "a"), CreateProjectList("b", "a"), CreateProjectList("b", "a"));

            // Simple cycle.
            Validate(CreateProjectList("a", "b"), CreateDependencies("b", "a", "a", "b"), null, null);

            // Three project tests.
            Validate(CreateProjectList("a", "b", "c"), /* dependencies */ CreateDependencies(), CreateProjectList("a", "b", "c"), CreateProjectList("a", "b", "c"));
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("a", "b"), CreateProjectList("a", "c", "b"), CreateProjectList("a", "b", "c"));
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a"), CreateProjectList("b", "c", "a"), CreateProjectList("b", "a", "c"));
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("a", "b", "b", "c"), CreateProjectList("a", "b", "c"), CreateProjectList("a", "b", "c"));
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a", "c", "b"), CreateProjectList("c", "b", "a"), CreateProjectList("c", "b", "a"));
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a", "c", "a"), CreateProjectList("c", "b", "a"), CreateProjectList("b", "c", "a"));

            // Complex cycle.
            Validate(CreateProjectList("a", "b", "c"), CreateDependencies("b", "a", "c", "b", "a", "c"), null, null);
        }

        [TestMethod]
        public void Question_4_7_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_7.FindBuildOrder(null, CreateDependencies("a", "b")), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_4_7.FindBuildOrder(CreateProjectList("a"), null), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_4_7.FindBuildOrder(CreateProjectList("a"), CreateDependencies("a", "b")), typeof(ArgumentOutOfRangeException));
        }

        private static void Validate(List<string> projects, Dictionary<string, string> dependencies, List<string> expectedOrder, List<string> expectedDFSOrder)
        {
           // var result = Question_4_7.FindBuildOrder(projects, dependencies);
            //ValidateResult(result, projects, expectedOrder);
            var result2 = Question_4_7.FindBuildOrderDFS(projects, dependencies);
            ValidateResult(result2, projects, expectedDFSOrder);
        }

        private static void ValidateResult(List<string> result, List<string> projects, List<string> expectedProjectsOrder)
        {
                if (expectedProjectsOrder != null)
                {
                    // No order needed since empty project list.
                    Assert.IsNotNull(result);
                }
                else
                {
                    // Error occurred or no ordering.
                    Assert.IsNull(result);
                    return;
                }

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
