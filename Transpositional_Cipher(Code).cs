using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transpositional_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to encrypt, decrypt or test?");
            string command = Console.ReadLine();
            while(command != "test" && command != "encrypt" && command != "decrypt")
            {
                Console.WriteLine("Do you want to encrypt, decrypt or test?");
                command = Console.ReadLine();
            }
            if (command == "test")
                BlackBox();
            if (command == "encrypt")
                Console.WriteLine(Encrypt(input, key));
            string Encrypt(string input, int key)
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
                string output = "";
                for (int i = 0; i < key; i++)
                {
                    for (int i1 = 0; i1 < rows; i1++)
                    {
                        output += (matrix[i1, i]);
                    }
                }
                return output;
            }
            if (command == "decrypt")
                Console.WriteLine(Decrypt(input, key, input.Length));
            string Decrypt(string input, int key, int inputLength)
            {
                int rows = input.Length / key;
                if (input.Length % key != 0)
                    rows++;
                char[,] matrix = new char[rows, key];
                int x = 0, y = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (x == rows - 1)
                    {
                        if (y <= input.Length % key - 1 || input.Length % key == 0)
                        {
                            matrix[x, y] = input[i];
                            x = 0;
                            y++;
                            continue;
                        }
                        else
                        {
                            x = 0;
                            y++;
                            i--;
                            continue;
                        }
                    }
                    else
                        matrix[x, y] = input[i];
                    x++;
                }
                string output = "";
                for (int i = 0; i < rows; i++)
                {
                    for (int i1 = 0; i1 < key; i1++)
                    {
                         output += (matrix[i, i1]);
                    }
                }
                return output.Substring(0, inputLength);
            }
            void BlackBox()
            {
                Random numOfTests = new Random();
                for (int i = 0; i < numOfTests.Next(3, 10); i++)
                {
                    Random keyGen = new Random();
                    int key = keyGen.Next(1, 20);
                    //Console.WriteLine(key);
                    string message = Generate();
                    //Console.WriteLine($"{message.Length}: {message}");
                    string encryptedMessage = Encrypt(message, key);
                    string decryptedMessage = Decrypt(encryptedMessage, key, message.Length);
                    //Console.WriteLine($"{decryptedMessage.Length}: {decryptedMessage}");
                    if (message == decryptedMessage)
                        Console.WriteLine($"Test {i+1} : passed.");
                    else
                        Console.WriteLine($"Test {i+1} : failed.");
                }
            }
            string Generate()
            {
                // Generator
                string message = "";
                Random rand = new Random();
                int requestedLength = rand.Next(4, 10);
                rand.Next(1, requestedLength / 2);
                string[] words = new string[rand.Next(5, 20)];
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = WordGenerator();
                }
                RandomText text = new RandomText(words);
                text.AddContentParagraphs(rand.Next(1, 5), rand.Next(1, 2), rand.Next(3, 5), rand.Next(1, 6), rand.Next(7, 12));
                message = text.Content;
                return message;
            }
            string GetRandomLetter(Random rnd, string[] letters)
            {
                return letters[rnd.Next(0, letters.Length - 1)];
            }
            string WordGenerator()
            {
                //Reference: https://stackoverflow.com/questions/18110243/random-word-generator-2
                string word = "";
                Random rnd = new Random();
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
                string[] vowels = { "a", "e", "i", "o", "u" };
                int requestedLength = rnd.Next(3, 10);
                while (word.Length < requestedLength)
                {
                    if (requestedLength != 1)
                    {
                        // Add the consonant
                        string consonant = GetRandomLetter(rnd, consonants);

                        if (consonant == "q" && word.Length + 3 <= requestedLength) // check +3 because we'd add 3 characters in this case, the "qu" and the vowel.  Change 3 to 2 to allow words that end in "qu"
                        {
                            word += "qu";
                        }
                        else
                        {
                            while (consonant == "q")
                            {
                                // Replace an orphaned "q"
                                consonant = GetRandomLetter(rnd, consonants);
                            }

                            if (word.Length + 1 <= requestedLength)
                            {
                                // Only add a consonant if there's enough room remaining
                                word += consonant;
                            }
                        }
                    }

                    if (word.Length + 1 <= requestedLength)
                    {
                        // Only add a vowel if there's enough room remaining
                        word += GetRandomLetter(rnd, vowels);
                    }
                }
                return word;
            }
        }   
    }
    //Reference: https://www.dotnetperls.com/random-paragraphs-sentences
    public class RandomText
    {
        static Random _random = new Random();
        StringBuilder _builder;
        string[] _words;
    
        public RandomText(string[] words)
        {
            _builder = new StringBuilder();
            _words = words;
        }
    
        public void AddContentParagraphs(int numberParagraphs, int minSentences,
            int maxSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberParagraphs; i++)
            {
                AddParagraph(_random.Next(minSentences, maxSentences + 1),
                             minWords, maxWords);
                _builder.Append(" ");
            }
        }
    
        void AddParagraph(int numberSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberSentences; i++)
            {
                int count = _random.Next(minWords, maxWords + 1);
                AddSentence(count);
            }
        }
    
        void AddSentence(int numberWords)
        {
            StringBuilder b = new StringBuilder();
            // Add n words together.
            for (int i = 0; i < numberWords; i++) // Number of words
            {
                b.Append(_words[_random.Next(_words.Length)]).Append(" ");
            }
            string sentence = b.ToString().Trim() + ". ";
            // Uppercase sentence
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
            // Add this sentence to the class
            _builder.Append(sentence);
        }
    
        public string Content
        {
            get
            {
                return _builder.ToString();
            }
        }
    }
}
