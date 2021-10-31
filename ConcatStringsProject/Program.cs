using System;
using ConcatStringsClassLibrary;
using static System.Console;

namespace ConcatStringsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var example1 = new string[] {"a", "b"};
            var example2 = new string[] {"abaca", "foobar"};

            var tmp = new ConcatStrings();

            ShowConsoleResults(tmp, example1, example2);

            ReadKey();
        }

        private static void FormatedWriteLine(string array1, string array2, string resultArray) =>
            WriteLine($"Concat: '{array1}' and '{array2}' | Result by task: '{resultArray}'");

        private static void ShowConsoleResults(ConcatStrings concat, params string[][] arrays)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                FormatedWriteLine(
                    arrays[i][0],
                    arrays[i][1],
                    concat.SortByAlphabet(
                        arrays[i][0],
                        arrays[i][1]));
            }
        }
    }
}