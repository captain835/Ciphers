using System;
using System.Collections.Generic;
using System.Windows;

namespace Simple_Cipher_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string defAlphabet = "abcdefghijklmnopqrstuvwxyz";
            List<string> allKeys = new List<string>();//very dumb solution I will fix it at some point
            string key = Console.ReadLine();
            if (key == "gr")
                key = GenerateRandomKey();
            string input = Console.ReadLine();
            string action = Console.ReadLine();
            if (action == "encrypt")
                Console.WriteLine(EncryptMessage(key, input));
            if (action == "decrypt")
                Console.WriteLine(DecryptMessage(key, input));
            //if (action == "bf")
            //    BruteForce(input);
            if (action == "hack")
                Hack();
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
                else if (action == "decrypt")
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
                while (randomKey.Length != 26)
                {
                    char i = defAlphabet[rnd.Next(0, 26)];
                    if (!randomKey.Contains(i))
                        randomKey += i;
                    if (randomKey.Length == 26)
                        if (allKeys.Contains(randomKey))
                            randomKey = "";
                }
                allKeys.Add(randomKey);
                return randomKey;
            }
            //void BruteForce(string message)
            //{
            //    ////setup library
            //    //NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();
            //    //oDict.DictionaryFile = "en-US.dic";
            //    //oDict.Initialize();
            //    //NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();
            //    ////oSpell.Dictionary = oDict;

            //    //bool check = false;
            //    //while (check)
            //    //{
            //    //    string key = GenerateRandomKey();
            //    //    string[] possibleMessage = DecryptMessage(key, message).Split();
            //    //    foreach (string word in possibleMessage)
            //    //        if (oSpell.TestWord(word))
            //    //        {
            //    //            check = true;
            //    //            Console.WriteLine(possibleMessage.ToString());
            //    //        }
            //    //}
            //    //if (!check)
            //    //    Console.WriteLine("No matches found.");

            //    for (int i = 0; i < Factorial(key.Length); i++)
            //    {
            //        string key = GenerateRandomKey();
            //        string[] possibleMessage = DecryptMessage(key, message).Split();
            //        Console.WriteLine(possibleMessage);
            //    }
            //}
            void Hack()
            {
                string[] message = input.Split(' ');
                foreach (var item in message)
                {
                    Console.WriteLine(WordPattern(item));
                }
                //Console.WriteLine(WordPattern(input));
            }
            List<string> allPossibleVariations = new List<string>();
            string possibleWord = "";
            //string ReplaceWithPossibleVariations(string word)
            //{
            //    //make a looping system using reccursion that also checks for the pattern
            //}
            string ReccursiveLooping(string sequence, int level) // level refers to the num of unique chars in a message            // loop through every possible variation of 1,2,3,4,5...level sequence and replace with chars
            {
                for (int i = 0; i < defAlphabet.Length; i++)
                {
                    if(sequence.Contains(defAlphabet[i]))
                    allPossibleVariations.Add();
                }
            }
            //bool CheckForPattern(string word)
            //{

            //}
            string WordPattern(string word)
            {
                string res = "";
                int count = 0;
                Dictionary<char, int> chars = new Dictionary<char, int>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (!chars.ContainsKey(word[i]))
                    {
                        res += count.ToString();
                        chars.Add(word[i], count);
                        count++;
                    }
                    else
                        res += chars[word[i]];
                }
                return res;
            }
            int Factorial(int number)
            {
                int res = 1;
                for (int i = number; i > 0; i--)
                    res *= number;
                return res;
            }
        }
    }
}
