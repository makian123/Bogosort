using System;
using System.Threading;
using System.Diagnostics;
using System.Linq;


namespace Bogosort
{
    class Program
    {
        public static int swaps = 0;

        static int[] Shuffle(int[] array)   //Shuffle values inside the array
        {
            Random random = new Random();
            for (int i = array.Length; i > 1; i--)
            {
                array = array.OrderBy(i => random.Next()).ToArray();
                swaps++;
            }
            return array;
        }

        static void Main(string[] args)
        {
            //Initialize variables
            int length = 9;
            int[] arr = new int[length];
            Stopwatch stopwatch = new Stopwatch();

            //Fill array
            for(int i = 0; i < arr.Length; ++i)
            {
                arr[i] = i + 1;
            }

            //Shuffle
            arr = Shuffle(arr);

            //Start timing, shuffle array, stop timing
            stopwatch.Start();
            arr = Bogosort(arr);
            stopwatch.Stop();

            //Print sorted array
            Console.Write("Sorted array: ");
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(" {0}", arr[i]);
            }
            Console.WriteLine("\nTime taken to sort: {0}ms\nNumber of swaps: {1}", stopwatch.ElapsedMilliseconds, swaps);
        }

        static int[] Bogosort(int[] array)  //Bogosort algorithm
        {
            while(!Sorted(array))
            {
                array = Shuffle(array);
            }
            return array;
        }

        static bool Sorted(int[] array) //Check if sorted
        {
            for(int i = 0; i < array.Length - 1; ++i)
            {
                if(array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
