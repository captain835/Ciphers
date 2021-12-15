using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace testlol
{
    class Program
    {
        static void Main(string[] args)
        {

            string inpath = @"H:\repos\Datasets\Quick_Sort_Test_Data_Set_2.txt";
            string outpath = @"H:\repos\Datasets\out.txt";
            StreamWriter file = new StreamWriter(outpath, true);
            string[] inarr = File.ReadAllLines(inpath);
            int[] arr = new int[inarr.Length];

            for (int i = 0; i < inarr.Length; i++)
                arr[i] = int.Parse(inarr[i]);


            //int[] arr = { 2148, 9058, 7742, 3153, 324, 609, 7628, 5469, 7017, 504 };

            int[] count = new int[1];

            int pivot = 0;
            int endindex = arr.Length - 1;

            int mod = -1;
            if (pivot <= endindex)
                mod = 1;
            Quicksort(pivot, endindex, mod); 
            
            void Quicksort(int pivot, int endindex, int mod)
            {
                int i = pivot;
                for (int j = pivot; j * mod <= endindex * mod; j += mod)
                {
                    if (arr[j] * mod < arr[pivot] * mod)
                    {
                        count[0]++;
                        i += mod;
                        if (arr[i] != arr[j])
                            Swap(ref arr[i], ref arr[j]);
                    }
                    if (j == endindex)
                    {
                        if (arr[pivot] != arr[i])
                            Swap(ref arr[pivot], ref arr[i]);
                        Quicksort(pivot, i - mod, mod);
                        Quicksort(i + mod, endindex, mod);
                    }
                }
            }

            PrintArr();

            void Swap(ref int a, ref int b)
            {
                int bucket = a;
                a = b;
                b = bucket;
            }

            void PrintArr()
            {
                foreach (int item in arr)
                {
                    Console.Write(item + " ");
                    //file.WriteLine(item);
                }
                Console.WriteLine();
                Console.WriteLine($"Comparisons:{count[0]}");
            }
            //file.Close();
        }
    }
}
