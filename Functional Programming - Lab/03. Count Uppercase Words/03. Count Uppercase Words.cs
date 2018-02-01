using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    public class Program
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(new[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> isUpper
                = n => n[0] == n.ToUpper()[0];
            words.Where(isUpper)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
