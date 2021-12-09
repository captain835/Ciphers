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
            string inpath = @"C:\temp\dataset1.txt";
            string outpath = @"C:\temp\out.txt";
            StreamWriter file = new StreamWriter(outpath, true);
            string[] inarr = File.ReadAllLines(inpath);
            int[] arr = new int[inarr.Length];

            for (int i = 0; i < inarr.Length; i++)
                arr[i] = int.Parse(inarr[i]);
            
            Quicksort(0, arr.Length - 1);

            void Quicksort(int pivot, int endindex)
            {
                int i = pivot;
                for (int j = pivot; j <= endindex; j++)
                {
                    if (arr[j] < arr[pivot])
                    {
                        i++;
                        if(arr[i] != arr[j])
                            Swap(ref arr[i], ref arr[j]);
                    }
                    if (j == endindex)
                    {
                        if (arr[pivot] != arr[i])
                            Swap(ref arr[pivot], ref arr[i]);
                        Quicksort(pivot, i - 1);
                        Quicksort(i + 1, endindex);
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
                    file.WriteLine(item);
                }
            }
            file.Close();
        }
    }
}
