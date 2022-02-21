using System;
using System.Windows;

namespace Simple_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string defAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string key = Console.ReadLine();
            if (key == "gr")
                key = GenerateRandomKey();
            string input = Console.ReadLine();
            string action = Console.ReadLine();
            if (action == "encrypt")
                Console.WriteLine(EncryptMessage(key, input));
            if (action == "decrypt")
                Console.WriteLine(DecryptMessage(key, input));
            if (action == "bf")
                BruteForce(input);
            string EncryptMessage(string key, string message)
            {
                return TranslateMessage(key, message, "encrypt");
            }
            string DecryptMessage(string key, string message)
            {
                return TranslateMessage(key, message, "decrypt");
            }
            string TranslateMessage(string key, string message, string action)
            {
                string result = "";
                if (action == "encrypt")
                {
                    foreach (var chr in message)
                        for (int i = 0; i < defAlphabet.Length; i++)
                            if (chr == defAlphabet[i])
                            {
                                result += key[i];
                                break;
                            }
                            else if (i == 25)
                            {
                                result += chr;
                                break;
                            }
                }
                else if(action == "decrypt")
                {
                    foreach (var chr in message)
                        for (int i = 0; i < defAlphabet.Length; i++)
                            if (chr == key[i])
                            {
                                result += defAlphabet[i];
                                break;
                            }
                            else if (i == 25)
                            {
                                result += chr;
                                break;
                            }
                }
                return result;
            }
            string GenerateRandomKey()
            {
                string randomKey = "";
                Random rnd = new Random();
                while(randomKey.Length!=26)
                { 
                    char i = defAlphabet[rnd.Next(0, 26)];
                    if (!randomKey.Contains(i)) 
                        randomKey += i;
                }
                return randomKey;
            }
            void BruteForce(string message)
            {
                //setup library
                NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();
                oDict.DictionaryFile = "en-US.dic";
                oDict.Initialize();
                NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();
                oSpell.Dictionary = oDict;

                bool check = false;
                while (check)
                {
                    string key = GenerateRandomKey();
                    string[] possibleMessage = DecryptMessage(key, message).Split();
                    foreach (string word in possibleMessage)
                        if (oSpell.TestWord(word))
                        {
                            check = true;
                            Console.WriteLine(possibleMessage.ToString());
                        }
                }
                if(!check)
                    Console.WriteLine("No matches found.");
            }
        }
    }
}
