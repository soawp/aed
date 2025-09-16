namespace AD
{
    public class Opgave2
    {
        static long calls = 0;

        private static long FibonacciRecursiveInternal(int n)
        {
            calls++; // count the number of times this function is called

            if (n <= 0) return 0; // Fib(0) = 0
            if (n == 1) return 1; // Fib(1) = 1

            return FibonacciRecursiveInternal(n - 1) + FibonacciRecursiveInternal(n - 2);
        }

        public static long FibonacciRecursive(int n)
        {
            calls = 0; // reset call counter
            return FibonacciRecursiveInternal(n);
        }

        private static long FibonacciIterativeInternal(int n)
        {
            calls++; // count the call

            if (n <= 0) return 0;
            if (n == 1) return 1;

            long a = 0;
            long b = 1;
            long fib = 0;

            for (int i = 2; i <= n; i++)
            {
                fib = a + b;
                a = b;
                b = fib;
                calls++; // count each iteration as a call
            }

            return fib;
        }

        public static long FibonacciIterative(int n)
        {
            calls = 0; // reset call counter
            return FibonacciIterativeInternal(n);
        }

        public static void Run()
        {
            int MAX = 35;

            System.Console.WriteLine("Recursief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} calls)", n, FibonacciRecursive(n), calls);
            }
            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} loops)", n, FibonacciIterative(n), calls);
            }
        }
    }
}
