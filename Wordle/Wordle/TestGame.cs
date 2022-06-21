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
            game1.StartGame(words[index]);

        }
    }
}

