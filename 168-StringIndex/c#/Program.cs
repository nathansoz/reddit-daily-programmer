using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "...You...!!!@!3124131212 Hello have this is a --- string Solved !!...? to test @\n\n\n#!#@#@%$**#$@ Congratz this!!!!!!!!!!!!!!!!one ---Problem\n\n";
            int[] positions = new int[] {12, -1, 1, -100, 4, 1000, 9, -1000, 16, 13, 17, 15};
            
            foreach(int position in positions)
            {
                string word = test.Word(position);
                if(word != "")
                {
                    Console.Write(word + " ");
                }
            }

            Console.Read();
        }
    }

    public static class StringExtension
    {
        public static string Word(this String str, int index)
        {
            string[] words = GetArrayOfWords(str);
            if (words.Length >= index && index > 0)
            {
                return words[index - 1];
            }
            else
            {
                return "";
            }
        }

        private static string[] GetArrayOfWords(string str)
        {

            List<string> words = new List<string>();
            
            Match match = Regex.Match(str, "[a-zA-Z0-9]+");

            while(match.Success)
            {
                words.Add(match.ToString());
                match = match.NextMatch();
            }

            return words.ToArray();

        }
    }
}
