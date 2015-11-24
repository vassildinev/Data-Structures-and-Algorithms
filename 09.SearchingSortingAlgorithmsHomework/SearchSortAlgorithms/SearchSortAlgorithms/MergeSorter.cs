namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void DoMerge(IList<T> numbers, int left, int mid, int right)
        {
            var temp = new T[25];
            int i, leftEnd, numberOfElements, position;

            leftEnd = (mid - 1);
            position = left;
            numberOfElements = (right - left + 1);

            while ((left <= leftEnd) && (mid <= right))
            {
                if (numbers[left].CompareTo(numbers[mid]) <= 0)
                {
                    temp[position++] = numbers[left++];
                }
                else
                {
                    temp[position++] = numbers[mid++];
                }
            }

            while (left <= leftEnd)
            {
                temp[position++] = numbers[left++];
            }

            while (mid <= right)
            {
                temp[position++] = numbers[mid++];
            }

            for (i = 0; i < numberOfElements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        private void MergeSort(IList<T> numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(numbers, left, mid);
                MergeSort(numbers, (mid + 1), right);
                DoMerge(numbers, left, (mid + 1), right);
            }
        }
    }
}
