using System;
using System.Linq;
using static System.Text.RegularExpressions.Regex;

namespace ConcatStringsClassLibrary
{
    public class ConcatStrings
    {
        public string SortByAlphabet(string strA, string strB)
        {
            if (strA == null) throw new ArgumentNullException(nameof(strA));
            if (strB == null) throw new ArgumentNullException(nameof(strB));
            if (IsMatch(strA, @"\d"))
                throw new AggregateException($"Argument {nameof(strA)} should be only with 'a'-'z'");
            if (IsMatch(strB, @"\d"))
                throw new AggregateException($"Argument {nameof(strB)} should be only with 'a'-'z'");
            return new string((strA + strB).ToCharArray().SortToUnrepeatedItems());
        }
    }
}