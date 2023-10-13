using System;
using System.Collections.Generic;
using System.Linq;

namespace frequency_analysis
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the encrypted text: ");
            string encryptedText = Console.ReadLine();

            char mostCommonLetter = FindMostCommonLetter(encryptedText);

            int shift = mostCommonLetter - 'e';

            string decryptedText = DecryptCaesarCipher(encryptedText, shift);
            Console.WriteLine("");

            Console.WriteLine("Decrypted text: " + decryptedText);
        }

        static char FindMostCommonLetter(string text)
        {
            var charFrequency = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char lowerC = char.ToLower(c);
                    if (charFrequency.ContainsKey(lowerC))
                    {
                        charFrequency[lowerC]++;
                    }
                    else
                    {
                        charFrequency[lowerC] = 1;
                    }
                }
            }

            char mostCommonLetter = charFrequency.OrderByDescending(pair => pair.Value).First().Key;
            return mostCommonLetter;
        }

        static string DecryptCaesarCipher(string text, int shift)
        {
            char[] decryptedChars = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsLower(c) ? 'a' : 'A';
                    decryptedChars[i] = (char)(baseChar + (c - baseChar - shift + 26) % 26);
                }
                else
                {
                    decryptedChars[i] = c;
                }
            }

            return new string(decryptedChars);
        }
    }
}
