using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    public class Question_8_8
    {
        public static List<string> PermutationWithDuplicates(string input)
        {
            var set = new HashSet<char>();
            foreach (var c in input)
            {
                set.Add(c);
            }

            var list = set.ToList();
            var str = new string(list.ToArray());
            return Question_8_7.PermutationsWithoutDuplicates(str);
        }

    }
}
