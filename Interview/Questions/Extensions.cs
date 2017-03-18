namespace Questions
{
    using System.Linq;

    public static class Extensions
    {
        public static bool ContentsEqual<T>(this T[,] m1, T[,] m2)
        {
            return m1.Rank == m2.Rank &&
                   Enumerable.Range(0, m1.Rank).All(
                          dimension => m1.GetLength(dimension) ==
                       m2.GetLength(dimension)) &&
                   m1.Cast<T>().SequenceEqual(m2.Cast<T>());
        }
    }
}
