using System;

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
            Console.WriteLine(Decryption(Encryption()));
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
            //int KeyBCheck()
            {
                // should check if the sum of the multiplication part and the key is bigger than 26.
            }
            int KeyACheck(int multiplct)
            {
                int counter = 0;
                while (true)
                {
                    if ((multiplct + 26 * counter) % keyA == 0)
                        return counter;
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
                                decryptedMessage += Char.ToUpper(alpha[KeyACheck(i - keyB % 26)]);
                                break;
                            }
                            else
                            {
                                decryptedMessage += alpha[KeyACheck(i - keyB % 26)];
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
