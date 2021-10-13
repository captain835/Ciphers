using System;

namespace Transpositional_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to encrypt or decrypt?");
            string command = Console.ReadLine();
            if (command == "encrypt")
                Encrypt(input, key);
            void Encrypt(string input, int key)
            {
                int rows = input.Length / key;
                if (input.Length % key != 0)
                    rows++;
                char[,] matrix = new char[rows, key];
                int x = 0, y = 0;
                foreach (char chr in input)
                {
                    matrix[x, y] = chr;
                    if (y == key - 1)
                    {
                        x++;
                        y = 0;
                    }
                    else
                        y++;
                }
                for (int i = 0; i < key; i++)
                {
                    for (int i1 = 0; i1 < rows; i1++)
                    {
                        Console.Write(matrix[i1, i]);
                    }
                }
            }
        }
    }
}
