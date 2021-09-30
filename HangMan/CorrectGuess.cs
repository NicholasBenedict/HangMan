using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class CorrectGuess
    {
        public void CorrectGuessDisplay(string word, int numOfLives)
        {
            Console.Clear();
            word = word.Replace(" ", string.Empty);
            char[] wordToBeGuessed = new char[word.Length];

            int numberOfGuesses = numOfLives;
            string holder = "";
            

            for (int i = 0; i < word.Length; i++)
            {
                wordToBeGuessed[i] = '_';
            }

            holder = new string(wordToBeGuessed);
            Console.WriteLine($"The word you are guessing is {holder}");
            Console.Write("Please enter your guess: \n");
            Console.ForegroundColor = ConsoleColor.Cyan;

            while (holder != word && numberOfGuesses > 0)
            {
                char guess = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (word.Contains(guess))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (guess == word[i])
                        {
                            wordToBeGuessed[i] = guess;
                            holder = new string(wordToBeGuessed);
                        }
                    } 
                    Console.WriteLine(holder + "\n");
                    Console.WriteLine("Guess the next letter");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;


                }
                else
                {
                    Console.WriteLine("Sorry that was a wrong guess \n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    numberOfGuesses--;
                    Console.WriteLine($"You have {numberOfGuesses} lives left");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            if (numberOfGuesses == 0)
            {
                Console.WriteLine("You lost the game!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The word you were trying to guess was {word}");
                Console.ReadLine();
            }
            else if(numberOfGuesses > 0)
            {
                Console.WriteLine("Congrats on guessing the word!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ReadLine();
            }
        }
    }
}

