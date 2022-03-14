using System;
using System.Numerics;

namespace Affine_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string message = Console.ReadLine();
            int key = int.Parse(Console.ReadLine());
            int keyA = key / message.Length;
            int keyB = key % message.Length;
            string encryptedMessage = Encryption();
            Console.WriteLine(encryptedMessage);
            Console.WriteLine(Decryption(encryptedMessage));
            //BruteForce(encryptedMessage);
            string Encryption()
            {
                string encryptedMessage = "";
                foreach (char chr in message)
                    for (int i = 0; i < alpha.Length; i++)
                    {
                        if (chr == alpha[i])
                        {
                            if (Char.IsUpper(chr))
                            {
                                encryptedMessage += Char.ToUpper(alpha[((i * keyA) % message.Length + keyB) % 26]);
                                break;
                            }
                            else
                            {
                                encryptedMessage += alpha[((i * keyA) % message.Length + keyB) % 26];
                                break;
                            }
                        }
                        else if (chr == ' ')
                        {
                            encryptedMessage += " ";
                            break;
                        }
                    }
                return encryptedMessage;
            }
            string Decryption(string enMessage)
            {
                // BigInteger.ModPow(a, n - 2, n)
                string decryptedMessage = "";
                foreach (char chr in enMessage)
                    for (int i = 0; i < alpha.Length; i++)
                    {
                        if (chr == alpha[i])
                        {
                            if (Char.IsUpper(chr))
                            {
                                decryptedMessage += Char.ToUpper(alpha[(int)BigInteger.ModPow(keyA, message.Length - 2, message.Length)*(i - keyB)%26]);
                                break;
                            }
                            else
                            {
                                decryptedMessage += alpha[(int)BigInteger.ModPow(keyA, message.Length - 2, message.Length) * (i - keyB) % 26];
                                break;
                            }
                        }
                        else if (chr == ' ')
                        {
                            decryptedMessage += " ";
                            break;
                        }
                    }
                return decryptedMessage;
            }
            //void BruteForce(string enMessage)
            //{
            //    int matches = 0;
            //    string possibleMessage = "";
            //    Console.WriteLine();
            //    for (int i = message.Length + 1; i < 100000; i++)
            //    {
            //        Console.WriteLine($"Epoch: {i - message.Length}");
            //        //ClearCurrentConsoleLine();
            //        int keyA = i / message.Length;
            //        int keyB = i % message.Length;
            //        foreach (char chr in enMessage)
            //            for (int i1 = 0; i1 < alpha.Length; i1++)
            //            {
            //                if (chr == alpha[i1])
            //                {
            //                    if (Char.IsUpper(chr))
            //                    {
            //                        possibleMessage += Char.ToUpper(alpha[KeyACheck(i1 - keyB % 26 + KeyBCheck(i1 - keyB % 26))]);
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        possibleMessage += alpha[KeyACheck(i1 - keyB % 26 + KeyBCheck(i1 - keyB % 26))];
            //                        break;
            //                    }
            //                }
            //                else if (chr == ' ')
            //                {
            //                    possibleMessage += " ";
            //                    break;
            //                }
            //            }
            //    }
            //    if (possibleMessage.ToLower().Contains(" a ") || possibleMessage.ToLower().Contains(" and ") || possibleMessage.ToLower().Contains(" an ") || possibleMessage.ToLower().Contains(" or ") || possibleMessage.ToLower().Contains(" is ") || possibleMessage.ToLower().Contains(" for ") || possibleMessage.ToLower().Contains(" but ") || possibleMessage.ToLower().Contains(" from ") || possibleMessage.ToLower().Contains(" he ") || possibleMessage.ToLower().Contains(" she ") || possibleMessage.ToLower().Contains(" it ") || possibleMessage.ToLower().Contains(" I ") || possibleMessage.ToLower().Contains(" you ") || possibleMessage.ToLower().Contains(" this "))
            //    {
            //        Console.WriteLine(possibleMessage);
            //        matches++;
            //    }
            //    Console.WriteLine($"{matches} found.");
            //}

            //void ClearCurrentConsoleLine()
            //{
            //    int currentLineCursor = Console.CursorTop;
            //    Console.SetCursorPosition(0, Console.CursorTop);
            //    Console.Write(new string(' ', Console.WindowWidth));
            //    Console.SetCursorPosition(0, currentLineCursor);
            //}
        }
    }
}
