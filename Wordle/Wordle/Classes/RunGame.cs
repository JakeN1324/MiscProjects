using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Classes
{
    public class RunGame
    {
        public void StartGame(string currentWord)
        {
            bool gameWon = false;
            int attempts = 0;
            List<char> letters = currentWord.ToCharArray().ToList(); //The current word to guess
            List<char> notGuessed = new List<char>(); //List of letters in the current word (For identifying a correct letter with the wrong placement)
            foreach (char c in letters)
            {
                notGuessed.Add(c);
            }
            Console.WriteLine(currentWord);
            Console.WriteLine();
            while (!gameWon) //Game repeats until all letters are guessed correctly 
            {
                List<char> guess = Console.ReadLine().ToCharArray().ToList();
                
                List<char> hints = new List<char>() { ' ', ' ', ' ', ' ', ' '};
                

                foreach (char letter in guess)
                {
                    Console.Write(letter.ToString().ToUpper());
                    Console.Write(" ");
                }

                attempts++;

                for (int i = 0; i < guess.Count; i++)
                {
                    if (guess[i] == letters[i])
                    {
                        hints[i] = 'O';
                        notGuessed[i] = '#';
                    }
                    else if (letters.Contains(guess[i]) && notGuessed.Contains(guess[i]))
                    {
                        hints[i] = '*';
                    }
                    else
                    {
                        hints[i] = 'X';
                    }
                }

                Console.WriteLine();
                foreach (char c in hints)
                {
                    Console.Write($"{c} ");                   
                }

                Console.WriteLine();
                foreach (char c in notGuessed)
                {
                    Console.Write($"{c} ");
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------");

                gameWon = true;
                foreach (char c in hints)
                {
                    if (c != 'O')
                    {
                        gameWon = false;
                        break;
                    }
                }
            }
            Console.WriteLine("Winner!");
            Console.WriteLine($"You guessed correctly in {attempts} attempts");
        }
    }
}
