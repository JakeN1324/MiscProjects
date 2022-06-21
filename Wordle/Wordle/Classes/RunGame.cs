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
            List<char> qThroughP = new List<char>() {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'};
            List<char> aThroughL = new List<char>() {' ', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'};
            List<char> zThroughM = new List<char>() {' ', ' ', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ' '};
            List<List<char>> keyboard = new List<List<char>>() {qThroughP, aThroughL, zThroughM};

            foreach (char c in letters)
            {
                notGuessed.Add(c);
            }

            while (!gameWon) //Game repeats until all letters are guessed correctly 
            {
                List<char> guess = Console.ReadLine().ToCharArray().ToList();

                if (guess[0] == '@')
                {
                    Console.WriteLine("----------------------");
                    foreach (List<char> list in keyboard)
                    {
                        Console.Write("|");
                        foreach (char letter in list)
                        {                          
                            Console.Write(letter.ToString().ToUpper());
                            Console.Write(" ");
                        }
                        Console.Write("|");
                        Console.WriteLine();
                    }
                    Console.WriteLine("----------------------");
                    continue;
                }
                else if (guess.Count != 5 && guess[0] != '@')
                {
                    Console.WriteLine("*Only 5 letter words are accepted*");
                    Console.WriteLine("-------------------------");
                    continue;
                }
                
                List<char> hints = new List<char>() { ' ', ' ', ' ', ' ', ' '};
                
                //Diplays the users guess
                foreach (char letter in guess)
                {
                    Console.Write(letter.ToString().ToUpper());
                    Console.Write(" ");
                }

                attempts++;

                for (int i = 0; i < guess.Count; i++) //Checks each letter of the guess against the current word
                {
                    if (guess[i] == letters[i]) //Correct letter in correct location
                    {
                        hints[i] = 'O';
                        notGuessed[i] = '#'; //Correct letters already guessed will not be detected unless there are duplicates in the current word
                    }
                    else if (letters.Contains(guess[i]) && notGuessed.Contains(guess[i])) //Correct letter, wrong location
                    {
                        hints[i] = '*';
                    }
                    else //Current word does not contain this letter
                    {
                        hints[i] = 'X';
                        foreach (List<char> list in keyboard)
                        {
                            if (list.Contains(guess[i]))
                            {
                                list[list.IndexOf(guess[i])] = ' ';
                            }
                        }
                    }
                }

                Console.WriteLine();
                foreach (char c in hints) //Prints the hint symbols under each letter
                {
                    Console.Write($"{c} ");                   
                }

                Console.WriteLine();
                Console.WriteLine("-------------------------");

                gameWon = true;
                foreach (char c in hints) //Checks hints for all correct letter symbols, if not then loop restarts
                {
                    if (c != 'O')
                    {
                        gameWon = false;
                        break;
                    }
                }
            }
            Console.WriteLine("Winner!");
            Console.WriteLine($"You guessed correctly in {attempts} attempt(s)");
        }
    }
}
