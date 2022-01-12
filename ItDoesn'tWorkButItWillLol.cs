using System;

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
            int KeyBCheck(int multiplct)
            {
                int add = 0;
                if ((multiplct + keyB) % 26 != 0)
                    add++;
                if (multiplct + keyB > 26)
                    return (multiplct + keyB) / 26 + add;
                else return 0;
            }
            int KeyACheck(int multiplct)
            {
                int counter = 0;
                while (true)
                {
                    if ((multiplct + 26 * counter) % keyA == 0)
                        return (multiplct + 26 * counter) / keyA;
                    counter++;
                }

            }
            string Decryption(string enMessage)
            {
                string decryptedMessage = "";
                foreach (char chr in enMessage)
                    for (int i = 0; i < alpha.Length; i++)
                    {
                        if (chr == alpha[i])
                        {
                            if (Char.IsUpper(chr))
                            {
                                decryptedMessage += Char.ToUpper(alpha[KeyACheck(i - keyB % 26 + KeyBCheck(i - keyB % 26))]);
                                break;
                            }
                            else
                            {
                                decryptedMessage += alpha[KeyACheck(i - keyB % 26 + KeyBCheck(i - keyB % 26))];
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
        }
    }
}
