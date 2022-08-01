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
            bool outOfAttempts = false;
            List<char> letters = currentWord.ToCharArray().ToList(); //The current word to guess
            List<char> notGuessed = new List<char>(); //List of letters in the current word (For identifying a correct letter with the wrong placement)
            List<char> qThroughP = new List<char>() {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'};
            List<char> aThroughL = new List<char>() {' ', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'};
            List<char> zThroughM = new List<char>() {' ', ' ', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ' '};
            List<string> prevGuesses = new List<string>();
            List<string> prevHints = new List<string>();
            FileAccess data = new FileAccess();
            List<string> validWords = data.GetWords();
            List<List<char>> keyboard = new List<List<char>>() {qThroughP, aThroughL, zThroughM};

            while (!gameWon) //Game repeats until all letters are guessed correctly 
            {
                notGuessed.Clear();

                foreach (char c in letters)
                {
                    notGuessed.Add(c);
                }

                if (attempts == 6) //After 6 guesses the game ends
                {
                    outOfAttempts = true;
                    break;
                }

                string stringGuess = Console.ReadLine();
                Console.WriteLine();

                List<char> guess = stringGuess.ToCharArray().ToList();             

                if (guess.Count != 5)
                {
                    Console.WriteLine("*Only 5 letter words are accepted*");
                    Console.WriteLine("-------------------------");
                    continue;
                }
                if (!validWords.Contains(stringGuess)) 
                {
                    Console.WriteLine("*Word not found in word list*");
                    Console.WriteLine("-------------------------");
                    continue;
                }
                
                Console.Clear();
                
                List<char> hints = new List<char>() { ' ', ' ', ' ', ' ', ' '};

                for (int i = 0; i < prevGuesses.Count; i++) //Prints all previous guesses and their corresponding hints in order after each new guess
                {
                    for (int j = 0; j < prevGuesses[i].Length; j++)
                    {
                        Console.Write($"{(prevGuesses[i])[j]} ");                      
                    }

                    Console.WriteLine();

                    for (int j = 0; j < prevHints[i].Length; j++)
                    {
                        Console.Write($"{(prevHints[i])[j]} ");
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------");
                }
                
                //Diplays the users guess
                foreach (char letter in guess)
                {
                    Console.Write(letter.ToString().ToUpper());
                    Console.Write(" ");
                }

                attempts++;

                for (int i = 0; i < guess.Count; i++) //Checks each letter of the guess against the current word
                {
                    int currentCount = 0; //Tracks the number of times the current letter appears in the word
                    foreach (char letter in letters) 
                    {
                        if (letter == guess[i])
                        {
                            currentCount++;
                        }
                    }

                    if (guess[i] == letters[i]) //Correct letter in correct location
                    {
                        hints[i] = 'O';
                        notGuessed[i] = '#'; //Correct letters already guessed will not be detected unless there are duplicates in the current word
                        for (int j = 0; j < guess.Count; j++) //If the same letter has been guessed elsewhere in the word and marked with a *, it will be replaced by an X if the word does not contain multiple instances of that letter, since it has now been guessed correctly 
                        {
                            if (hints[j] == '*' && guess[j] == guess[i] && currentCount <= 1)
                            {
                                hints[j] = 'X';
                            }
                        }
                    }
                    else if (letters.Contains(guess[i]) && notGuessed.Contains(guess[i]))  //Correct letter, wrong location
                    {                       
                        hints[i] = '*';
                        notGuessed[notGuessed.IndexOf(guess[i])] = '#';
                    }
                    else //Current word does not contain this letter
                    {
                        hints[i] = 'X';
                    }
                }

                string hintString = string.Join("", hints);
                prevHints.Add(hintString);

                for (int i = 0; i < guess.Count; i++) //Removes incorrect letters from the keyboard display
                {
                    if (hints[i] == 'X' && !letters.Contains(guess[i]))
                    {
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
                Console.WriteLine("----------------------");

                foreach (List<char> list in keyboard) //Displays the remaining possible letters
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

                if (attempts < 6) //Displays remaining number of attempts 
                {                   
                    Console.Write("|");
                    Console.Write($"Attempts Remaining: {6 - attempts}");
                    Console.Write("|");
                    Console.WriteLine();
                    Console.WriteLine("----------------------");
                    Console.WriteLine();
                }

                gameWon = true;
                foreach (char c in hints) //Checks hints for all correct letter symbols, if not then loop restarts
                {
                    if (c != 'O')
                    {
                        gameWon = false;
                        break;
                    }
                }
                prevGuesses.Add(stringGuess.ToUpper());
            }

            if (outOfAttempts) //Displays final results 
            {
                Console.WriteLine("You lose!");
                Console.Write("The word was ");
                foreach (char l in letters)
                {
                    Console.Write(l.ToString().ToUpper());
                }
            }
            else
            {
                Console.WriteLine("Winner!");
                Console.WriteLine($"You guessed correctly in {attempts} attempt(s)");
            }           
        }
    }
}
