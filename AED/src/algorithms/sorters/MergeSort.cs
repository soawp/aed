using System.Collections.Generic;

namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            if (list == null || list.Count <= 1)
                return;

            Sort(list, 0, list.Count - 1);
        }

        private void Sort(List<int> list, int lo, int hi)
        {
            if (lo >= hi) return; // Base case: one element

            int mid = lo + (hi - lo) / 2;

            Sort(list, lo, mid);       // Sort left half
            Sort(list, mid + 1, hi);   // Sort right half
            Merge(list, lo, mid, hi);  // Merge sorted halves
        }

        private void Merge(List<int> list, int lo, int mid, int hi)
        {
            int leftSize = mid - lo + 1;
            int rightSize = hi - mid;

            // Create temporary arrays
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            for (int i = 0; i < leftSize; i++)
                left[i] = list[lo + i];
            for (int i = 0; i < rightSize; i++)
                right[i] = list[mid + 1 + i];

            int leftIndex = 0, rightIndex = 0, mergedIndex = lo;

            // Merge back into the original list
            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    list[mergedIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    list[mergedIndex] = right[rightIndex];
                    rightIndex++;
                }
                mergedIndex++;
            }

            // Copy any remaining elements from left
            while (leftIndex < leftSize)
            {
                list[mergedIndex] = left[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            // Copy any remaining elements from right
            while (rightIndex < rightSize)
            {
                list[mergedIndex] = right[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }
    }
}
