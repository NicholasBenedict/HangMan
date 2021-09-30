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
            char[] wordToBeGuessed = new char[word.Length];

            int numberOfGuesses = numOfLives;
            string holder = "";
            char apostrophe = '\'';
            char space = ' ';

            for (int i = 0; i < word.Length; i++)
            {
                wordToBeGuessed[i] = '_';
            }

            holder = CheckForLetter(apostrophe, word, wordToBeGuessed);
            holder = CheckForLetter(space, word, wordToBeGuessed);

            holder = new string(wordToBeGuessed);
            Console.WriteLine($"The word or phrase you are guessing is {holder}\n" +
                $"The number of lives you have to guess it is {numberOfGuesses}");
            Console.Write("Please enter your guess: \n");
            Console.ForegroundColor = ConsoleColor.Cyan;

            while (holder != word && numberOfGuesses > 0)
            {
                char guess = Console.ReadKey().KeyChar;
                string guessHolder = guess.ToString().ToLower();
                guess = Convert.ToChar(guessHolder);

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

        public string CheckForLetter(char itemToCheckFor, string word , char[] wordToBeGuessed)
        {
            string holder = "";
            if (word.Contains(itemToCheckFor))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (itemToCheckFor == word[i])
                    {
                        wordToBeGuessed[i] = itemToCheckFor;
                        holder = new string(wordToBeGuessed);
                    }
                }
            }
            return holder;
        }
    }
}

