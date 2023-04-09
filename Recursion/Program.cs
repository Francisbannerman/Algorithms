using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AllAboutRecursion aboutRecursion = new AllAboutRecursion();
            
            //var print = aboutRecursion.findFactorialRecursive(5);
            //var print = aboutRecursion.findFactorialIterative(5);
            //Console.WriteLine(print);

            //var print = aboutRecursion.fibonacciIterative(12);
            var print1 = aboutRecursion.fibonacciRecursive(8);
             //Console.WriteLine(print);
            Console.WriteLine(print1);

            //var print = aboutRecursion.ReverseString("francis");
            //Console.WriteLine(print);

            Console.ReadKey();
        }
    }

    public class AllAboutRecursion
    {
        public void Info()
        {
            /// Recursion is when a thing is defined in terms of itself. A recursive method
            /// calls itself. Can be a substitue for iteration. This is by applying a result of
            /// a procedure, to a procedure. This is by dividing a problem into sub-problems
            /// of the same type as the original. Commonly used with advanced sorting
            /// algorithms and navigating trees.
            ///
            /// Advantages - Easier to read and write
            ///                   - Easier to debug
            ///                   - Easier to apply D.R.Y
            ///                   - Best used for data structures that have an unknown loop
            ///                      requirement. eg, tree data structures where the
            ///                      length of the tree is unknown at first.
            ///                   - Best when the problem can be divided in smaller
            ///                      subproblems that are smaller instances of the same problem
            ///                   - Each instance of the subproblem is identical in nature
            ///                   - The solution to each subproblem can be combined to solve
            ///                      the problem at hand
            ///                   - Best for divide and conquer problems
            /// Disadvantages - Sometimes slower
            ///                        - Uses more memory
            ///                        - Larger stack
        }

        public int findFactorialRecursive(int num) //BigO(n)
        {
            if (num == 1)
            {
                return num;
            }
            return num * (findFactorialRecursive(num - 1));
        }

        public int findFactorialIterative(int num) //BigO(n)
        {
            int answer = 1;
            if (num == 2)
            {
                return num;
            }
            for (int i = 2; i <= num; i++)
            {
                answer = answer * i;
            }
            return answer;
        }

        public int fibonacciIterative(int num)
        {
            int num1 = 0;
            int num2 = 1;
            int fibNum = 0;
            
            for (int i =0; i < num; i++)
            {
                fibNum= num1;
                num1 = num2;
                num2 = fibNum + num2;

                //Console.WriteLine(fibNum);
            }
            return num1;
        }

        public int fibonacciRecursive(int num) // BigO(2 toThePowerOf n)
        {
            if (num <= 1)
            {
                return num;
            }
            //return fibonacciRecursive(num - 1) + fibonacciRecursive(num - 2);
            var ans = fibonacciRecursive(num - 1) + fibonacciRecursive(num - 2);
            //Console.WriteLine(ans);
            return ans;
        }

        public string ReverseString(string str)
        {
            if (str.Length == 0)
            {
                return "";
            }
            else
            {
                // var tryMe = ReverseString(str.Substring(1)) + str[0];
                // Console.WriteLine(str);
                // return tryMe;

                return ReverseString(str.Substring(1)) + str[0];
            }
        }
    }
}