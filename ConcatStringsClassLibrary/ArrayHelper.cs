using System;
using System.Collections.Generic;
using System.Linq;
using static System.Array;


namespace ConcatStringsClassLibrary
{
    public static class ArrayHelper
    {
        public static T[] SortByMergeMethod<T>(this T[] array)
            where T : IComparable =>
            DivideElements(array, SortByMergeArray);

        public static T[] SortToUnrepeatedItems<T>(this T[] array)
            where T : IComparable =>
            DivideElements(array, SortNotRepeatedArray);

        private static T[] DivideElements<T>(T[] array, Func<T[], T[], T[]> func)
            where T : IComparable
        {
            if (array.Length == 1)
                return array;

            var middleIndex = array.Length / 2;

            return func(
                DivideElements(array.Take(middleIndex).ToArray(), func),
                DivideElements(array.Skip(middleIndex).ToArray(), func));
        }

        private static T[] SortByMergeArray<T>(T[] array1, T[] array2)
            where T : IComparable =>
            MergeArrays(array1, array2, CompareElements);

        private static T[] SortNotRepeatedArray<T>(T[] array1, T[] array2)
            where T : IComparable =>
            MergeArrays(array1, array2, CompareWithNonRepeatedElements);

        private static T[] MergeArrays<T>(T[] array1, T[] array2, ItemOparationOfArrays<T> func)
            where T : IComparable
        {
            var sumLength = array1.Length + array2.Length;
            var sortedArray = new T[sumLength];
            var indexOfArray1 = 0;
            var indexOfArray2 = 0;
            var counter = 0;

            for (int i = 0; i < sumLength; i++, counter++)
            {
                var funcResult = func(array1, array2, ref indexOfArray1, ref indexOfArray2);
                if (!EqualityComparer<T>.Default.Equals(funcResult, default(T)))
                    sortedArray[counter] = funcResult;
                else
                    counter--;
            }

            if (counter != 0)
                Resize(ref sortedArray, counter);

            return sortedArray;
        }

        private static T CompareElements<T>(T[] array1, T[] array2, ref int indexOfArray1, ref int indexOfArray2)
            where T : IComparable
        {
            if (indexOfArray2.CompareTo(array2.Length) < 0 && indexOfArray1.CompareTo(array1.Length) < 0)
            {
                if (array1[indexOfArray1].CompareTo(array2[indexOfArray2]) > 0)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
            else
            {
                if (indexOfArray2 < array2.Length)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
        }

        private static T CompareWithNonRepeatedElements<T>(T[] array1, T[] array2, ref int indexOfArray1,
            ref int indexOfArray2)
            where T : IComparable
        {
            if (indexOfArray2.CompareTo(array2.Length) < 0 && indexOfArray1.CompareTo(array1.Length) < 0)
            {
                if (array1[indexOfArray1].CompareTo(array2[indexOfArray2]) == 0)
                {
                    indexOfArray1++;
                    return default(T);
                }
                else if (array1[indexOfArray1].CompareTo(array2[indexOfArray2]) > 0)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
            else
            {
                if (indexOfArray2 < array2.Length)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
        }

        private delegate T ItemOparationOfArrays<T>(T[] array1, T[] array2, ref int indexOfArray1,
            ref int indexOfArray2)
            where T : IComparable;
    }
}