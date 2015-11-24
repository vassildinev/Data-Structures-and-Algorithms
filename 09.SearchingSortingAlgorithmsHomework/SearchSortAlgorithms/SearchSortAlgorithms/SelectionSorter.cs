namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.SelectSort(collection);
        }

        private void SelectSort(IList<T> arr)
        {
            int pos_min;
            T temp;

            for (int i = 0; i < arr.Count - 1; i++)
            {
                pos_min = i;

                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[j].CompareTo(arr[pos_min]) < 0)
                    {
                        pos_min = j;
                    }
                }

                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
        }
    }
}
