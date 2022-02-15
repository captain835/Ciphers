using System;
using System.Collections.Generic;

namespace Simple_cipher
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] alphabets = new char[2,51];
            alphabets[0, i] = "abcdefghijklmnopqrstuvwxyz,./<>?;[]{}-_=+()&*%^#$!@";

            Console.WriteLine("Input a message:");
            string message = Console.ReadLine();
            Console.WriteLine($"Input a key with length 51 which consists only of digits");
            string key = Console.ReadLine();
            while (key.Length != 51)
                Console.WriteLine("Invalid key: " + $"Input a key with length 51 which consists only of digits");

            void GenerateAlphabet(string key)
            {
                for (int i = 0; i < 51; i++)
                {
                    int index = int.Parse((key[i]).ToString());
                    alphabets[1,i] = alphabets[0,index];
                }
                    
            }

            void Encrypt()
            {
                string encryptedMessage = "";
                foreach (char chr in message)
                    for (int i = 0; i < 51; i++)
                        if (chr.ToString().ToLower() == alphabets[0,i].ToString())
                            encryptedMessage += alphabets[1,i];
            }
            void Decrypt(string encrypted)
            {
                string decryptedMessage = "";
                foreach (char chr in encrypted)
                    for (int i = 0; i < alphabet.Length; i++)
                        if (chr.ToString().ToLower() == alphabet[i].ToString())
                            encryptedMessage += alphabets[1, i];
            }


        }
    }
}
