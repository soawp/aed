using System.Collections.Generic;

namespace AD
{
    public class Opgave6
    {
        public static string ForwardString(List<int> list, int from_index)
        {
            if (from_index >= list.Count)
            {
                return ""; // basisgeval
            }

            // Voeg huidige element toe + recursieve aanroep voor rest
            string rest = ForwardString(list, from_index + 1);
            return list[from_index] + (rest == "" ? "" : " " + rest);
        }

        public static string BackwardString(List<int> list, int from_index)
        {
            if (from_index < 0)
            {
                return ""; // basisgeval
            }

            // Voeg huidige element toe + recursieve aanroep voor rest vóór
            string rest = BackwardString(list, from_index - 1);
            return list[from_index] + (rest == "" ? "" : " " + rest);
        }

        public static void Run()
        {
            List<int> list = new List<int>(new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11});

            System.Console.WriteLine(ForwardString(list, 3));
            System.Console.WriteLine(ForwardString(list, 7));
            System.Console.WriteLine(BackwardString(list, 3));
            System.Console.WriteLine(BackwardString(list, 7));
        }
    }
}
