using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Wordle.Classes
{

    public class TestGame
    {
        static void Main()
        {
            FileAccess data = new FileAccess();
            List<string> words = new List<string>();

            words = data.GetWords();

            Random random = new Random();
            int index = random.Next(words.Count);
            
            RunGame game1 = new RunGame();

            Console.WriteLine("Enter any 5 letter word to guess.");
            Console.WriteLine("Key: O = Correct letter and location, * = Correct letter but wrong location, X = Word does not contain this letter");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            //game1.StartGame(words[index]);
            game1.StartGame("there");
        }
    }
}

                                                                 
