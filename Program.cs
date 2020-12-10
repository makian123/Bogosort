using System;

namespace Bogosort
{
    class Program
    {
        static int[] Shuffle(int[] array)
        {
            var random = new Random();
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                                        // Swap.
                int tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
            return array;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[20];

            for(int i = 0; i < 20; ++i)
            {
                arr[i] = i;
            }

            arr = Shuffle(arr);

            arr = Bogosort(arr);

            for (int i = 0; i < 20; ++i)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static int[] Bogosort(int[] array)
        {
            while(!Sorted(array))
            {
                array = Shuffle(array);
            }
            return array;
        }

        static bool Sorted(int[] array)
        {
            for(int i = 0; i < array.Length; i += 2)
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
