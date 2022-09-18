using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program

    {
        
        // FindPivot (index for pivot)
        
        static int FindPivot(int[] numbers, int minIndex, int maxIndex)
        {

            int pivot = minIndex - 1;
            int temp = 0;

            for (int i = minIndex; i < maxIndex; i++)
            {
                if (numbers[i] < numbers[maxIndex])
                {
                    pivot++;
                    temp = numbers[pivot];
                    numbers[pivot] = numbers[i];
                    numbers[i] = temp;
                }
            }

            pivot++;
            temp = numbers[pivot];
            numbers[pivot] = numbers[maxIndex];
            numbers[maxIndex] = temp;

            return pivot;

        }
        
        
        
        // Main algorithm sorting
        
        static int[] QuickSort(int[] numbers, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return numbers;
            }
            
            int pivot = FindPivot(numbers, minIndex, maxIndex);

            QuickSort(numbers, minIndex, pivot - 1);
            QuickSort(numbers, pivot + 1, maxIndex);

            return numbers;

        }
        
        
        
        
        // Initialization massive with sort
        
        static int[] massive(int size)
        {
            int[] array = new int[size]; // Create massive with fixed size

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            return array = QuickSort(array, 0, array.Length - 1);

        }



        // Main func
        
        static int[] sequence(int size)
        {
            
            int[] array = massive(size);
            
            printArray(array);
            
            int lenght = 0;
            int cur_lenght = 1;
            int last_index = 0;

            
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] - array[i - 1] == 1)
                {
                    cur_lenght++;
                }
                
                else if (array[i] - array[i-1] != 1)
                {
                    if (cur_lenght > lenght)
                    {
                        lenght = cur_lenght;
                        cur_lenght = 1;
                        last_index = i-1;
                    }
                }

                if (i == array.Length - 1)
                {
                    if (cur_lenght > lenght)
                    {
                        lenght = cur_lenght;
                        cur_lenght = 1;
                        last_index = i;
                    }
                }
            }

            int[] max_seq = new int[lenght];

            int j = 0;
            for (int i = last_index - lenght + 1; i <= last_index; i++)
            {
                max_seq[j] = array[i];
                j++;
            }

            return max_seq;

        }



        static void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
            Console.WriteLine();
        }
        
        
        
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            printArray(sequence(size));
            
            // size: 6, massive: -9 -10 4 3 6 5,  answer: 3 4 5 6
            // size: 6, massive: -10 -8 -9 -7 2 3, answer: -10 -9 -8 -7
            // size: 6, massive: 3 4 1 2 6 5, answer: 1 2 3 4 5 6
        }
    }
}
