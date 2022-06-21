using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Classes
{
    public class FileAccess
    {
        //Path to a text file containing 2315 5-letter words
        public string filePath = @"C:\Repository1\MiscProjects\Wordle\Words.txt";

        //Returns a list 2315 strings from the text file
        public List<string> GetWords()
        {
            List<string> words = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split(' ');
                    words.Add(split[0]);
                }
            }

            return words;
        }
    }
}
