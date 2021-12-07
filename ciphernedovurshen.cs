using System;

namespace cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string message = Console.ReadLine();
            double keyA = int.Parse(Console.ReadLine());
            double keyB = int.Parse(Console.ReadLine());
            message = Encryption();
            Console.WriteLine(message);
            Console.WriteLine(Decryption());
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
                                encryptedMessage += Char.ToUpper(alpha[(int)Math.Ceiling((i * keyA % alpha.Length + keyB) % 26)]);
                                break;
                            }
                            else
                            {
                                encryptedMessage += alpha[(int)Math.Ceiling((i * keyA % alpha.Length + keyB) % 26)];
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
            string Decryption()
            {
                string decryptedMessage = "";
                foreach (char chr in message)
                    for (int i = 0; i < alpha.Length; i++)
                    {
                        if (chr == alpha[i])
                        {
                            if (Char.IsUpper(chr))
                            {
                                decryptedMessage += Char.ToUpper(alpha[(int)Math.Ceiling((i % 26 - keyB) % 26 / keyB)]);
                                break;
                            }
                            else
                            {
                                decryptedMessage += alpha[(int)Math.Ceiling((i % 26 - keyB) % 26 / keyB)];
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
