using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DynamicProgramming dynamicProgramming = new DynamicProgramming();
            dynamicProgramming.Fibonacci(10);
            dynamicProgramming.Fibonacci(7);
            //dynamicProgramming.Fibonacci(3);
            
            Console.ReadKey();
        }
    }

    public class DynamicProgramming
    {
        private void Info()
        {
            //-It's an optimization technique using cache.
            //-Caching is a way to store values to be used later on to speed up programs.
            //-Memoization is a specific form of caching of of caching that involves
            //caching the return value only function. Its a way to remember a solution
            //to a problem if it has been solved before so that you dont have to
            //rework the problem again.
            
            //Things to  consider when dynamically programming
            //1. Can the problem be divided in sub-problems
            //2. Does recursive solutions solve it
            //3. Are there repetitive sub-problems
            //4. Memoize sub-problems
        }

        private Dictionary<int, int> cache = new Dictionary<int, int>();
        public int Fibonacci(int n)
        {
            if (n <= 1) {
                
                return n;
            }
            else if (cache.ContainsKey(n)) {
                Console.WriteLine("Cached");
                return cache[n];
            }
            else {
                int result = Fibonacci(n - 1) + Fibonacci(n - 2);
                cache[n] = result;
                Console.WriteLine("New Workout");
                return result;
            }
        }
    }
}