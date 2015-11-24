namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private int Partition(IList<T> list, int left, int right)
        {
            T pivot = list[left];

            while (true)
            {
                while (list[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (list[right].CompareTo(pivot) > 0)
                    right--;

                if (list[right].CompareTo(pivot) == 0 && list[left].CompareTo(pivot) == 0)
                {
                    left++;
                }

                if (left < right)
                {
                    T temp = list[left];
                    list[left] = list[right];
                    list[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        void QuickSort(IList<T> list, int left, int right)
        {
            if (list == null || list.Count <= 1)
            {
                return;
            }

            if (left < right)
            {
                int pivotIdx = Partition(list, left, right);

                if (pivotIdx > 1)
                {
                    QuickSort(list, left, pivotIdx - 1);
                }
                if (pivotIdx + 1 < right)
                {
                    QuickSort(list, pivotIdx + 1, right);
                }
            }
        }
    }
}
