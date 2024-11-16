using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximTasks.SortingAlgorithms
{
    public class QuickSortClass
    {
        public static string SortedString(string input)
        {
            var array = input.ToCharArray();
            Quicksort(array, 0, array.Length - 1);
            return new string(array);
        }

        private static void Quicksort(char[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                Quicksort(array, left, pivotIndex - 1);
                Quicksort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(char[] array, int left, int right)
        {
            char pivot = array[right];
            int pivotIndex = left;

            for (int i = left; i < right; i++)
            {
                if (array[i] <= pivot)
                {
                    (array[pivotIndex], array[i]) = (array[i], array[pivotIndex]);
                    pivotIndex++;
                }
            }

            (array[pivotIndex], array[right]) = (array[right], array[pivotIndex]);

            return pivotIndex;
        }
    }
}
