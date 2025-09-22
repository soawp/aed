using System.Collections.Generic;

namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 3;

        public override void Sort(List<int> list)
        {
            if (list == null || list.Count <= 1)
                return;

            Sort(list, 0, list.Count - 1);
        }

        private void Sort(List<int> list, int lo, int hi)
        {
            if (hi - lo <= CUTOFF)
            {
                InsertionSort(list, lo, hi);
                return;
            }

            int pivotIndex = Partition(list, lo, hi);
            Sort(list, lo, pivotIndex - 1);
            Sort(list, pivotIndex + 1, hi);
        }

        private int Partition(List<int> list, int lo, int hi)
        {
            int pivot = list[hi]; // Laatste element als pivot
            int i = lo - 1;

            for (int j = lo; j < hi; j++)
            {
                if (list[j] <= pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, hi);
            return i + 1;
        }

        private void Swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private void InsertionSort(List<int> list, int lo, int hi)
        {
            for (int i = lo + 1; i <= hi; i++)
            {
                int key = list[i];
                int j = i - 1;

                while (j >= lo && list[j] > key)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = key;
            }
        }
    }
}
