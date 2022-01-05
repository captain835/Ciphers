using System;
using System.Collections.Generic;

namespace Affine_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string message = Console.ReadLine();
            int keyA = int.Parse(Console.ReadLine());
            int keyB = int.Parse(Console.ReadLine());
            Console.WriteLine(Encryption());
            string[] res = Decryption(Encryption());
            foreach (string item in res)
            {
                Console.WriteLine(item);
            }
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
                                encryptedMessage += Char.ToUpper(alpha[(i * keyA % alpha.Length + keyB) % 26]);
                                break;
                            }
                            else
                            {
                                encryptedMessage += alpha[(i * keyA % alpha.Length + keyB) % 26];
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
            string[] Decryption(string message)
            {
                string[] decryptedMessages = new string[alpha.Length + 1];
                for (int i1 = 0; i1 < alpha.Length + 1; i1++)
                    foreach (char chr in message)
                        for (int i = 0; i < alpha.Length; i++)
                        {
                            if (chr == alpha[i])
                            {
                                if (Char.IsUpper(chr))
                                {
                                    decryptedMessages[i1] += Char.ToUpper((alpha[(26 * i1 - keyB + 26 * i1) / keyA]));
                                    break;
                                }
                                else
                                {
                                    if((26 * i1 - keyB + 26 * i1) / keyA < 26 && (26 * i1 - keyB + 26 * i1) / keyA > 0)
                                        decryptedMessages[i1] += alpha[(26 * i1 - keyB + 26 * i1) / keyA];
                                    break;
                                }
                            }
                            else if (chr == ' ')
                            {
                                decryptedMessages[i1] += " ";
                                break;
                            }
                        }
                return decryptedMessages;
            }
        }
    }
}
