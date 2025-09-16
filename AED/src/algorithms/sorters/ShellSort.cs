using System.Collections.Generic;

namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            int n = list.Count;

            // Start with a big gap, then reduce the gap
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Perform a gapped insertion sort
                for (int i = gap; i < n; i++)
                {
                    int temp = list[i];
                    int j = i;

                    // Shift earlier gap-sorted elements up until the correct location for list[i] is found
                    while (j >= gap && list[j - gap] > temp)
                    {
                        list[j] = list[j - gap];
                        j -= gap;
                    }

                    // Put temp (the original list[i]) in its correct location
                    list[j] = temp;
                }
            }
        }
    }
}
