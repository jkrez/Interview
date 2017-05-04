namespace Questions.Extensions
{
    using System;
    using Questions.Data_structures;

    public static class BinaryTreeNodeExtensions
    {
        public static void TestE<T>(this BinaryTreeNode<T> n)
            where T : IEquatable<T>
        {
            n = n;
            return;
        }

        public static void ValidateArgument<T>(this BinaryTreeNode<T> node, string argumentName)
            where T : IEquatable<T>
        {
            if (node == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
