
using System;

namespace Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            Console.Write("Do you want to encrypt, decrypt or brute force? ");
            string command = Console.ReadLine();
            if (command == "encrypt")
            {
                Console.Write("Please provide a key: ");
                int key = int.Parse(Console.ReadLine());
                string encryptedMessage = Encrypt(message, key);
                Console.WriteLine(encryptedMessage);
            }
            string Encrypt(string message, int key)
            {
                char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
                string encryptedMessage = "";
                foreach (char chr in message)
                    for (int i = 0; i < characters.Length; i++)
                    {
                        if (chr == characters[i])
                        {
                            if (Char.IsUpper(chr))
                            {
                                encryptedMessage += Char.ToUpper(characters[(i + key) % 26]);
                                break;
                            }
                            else
                            {
                                encryptedMessage += characters[(i + key) % 26];
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
            if (command == "decrypt")
            {
                Console.Write("Please provide a key: ");
                int key = int.Parse(Console.ReadLine());
                string decryptedMessage = Decrypt(message, key);
                Console.WriteLine(decryptedMessage);
            }
            string Decrypt(string message, int key)
            {
                char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
                string decryptedMessage = "";
                foreach (char chr in message)
                    for (int i = 0; i < characters.Length; i++)
                    {
                        if (chr == characters[i])
                        {
                            if (Char.IsUpper(chr) && key > i)
                                decryptedMessage += Char.ToUpper(characters[26 + (i - key % 26)]);
                            else if (Char.IsUpper(chr) && key <= i)
                                decryptedMessage += Char.ToUpper(characters[i - key % 26]);
                            else if (key > i)
                                decryptedMessage += characters[26 + (i - key % 26)];
                            else
                                decryptedMessage += characters[Math.Abs(i - key % 26)];
                        }
                        else if (chr == ' ')
                        {
                            decryptedMessage += " ";
                            break;
                        }
                    }
                return decryptedMessage;
            }
            if (command == "brute force")
                BruteForce(message);
            void BruteForce(string message)
            {
                string bruteForcedMessage = "";
                char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
                for (int i1 = 1; i1 < characters.Length; i1++)
                {
                    foreach (char chr in message)
                    {
                        for (int i = 0; i < characters.Length; i++)
                        {
                            if (chr == characters[i])
                            {
                                if (Char.IsUpper(chr))
                                {
                                    bruteForcedMessage += Char.ToUpper(characters[(i + i1)%26]);
                                    break;
                                }
                                else
                                {
                                    bruteForcedMessage += characters[(i + i1)%26];
                                    break;
                                }
                            }
                            else if (chr == ' ')
                            {
                                bruteForcedMessage += " ";
                                break;
                            }
                        }
                    }
                Console.WriteLine(bruteForcedMessage);
                bruteForcedMessage = "";
                }
            }
        }
    }
}
