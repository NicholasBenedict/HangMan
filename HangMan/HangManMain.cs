﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace HangMan
{
    class HangManMain
    {
        static void Main(string[] args)
        {
            CorrectGuess correctGuess = new CorrectGuess();
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("HangMan.dictionary.txt");
            StreamReader reader = new StreamReader(stream);
            string file2 = reader.ReadToEnd();
            string[] readFile = file2.Split('\n');

            Console.WriteLine("Welcome to HangMan \n");
            Console.ForegroundColor = ConsoleColor.Blue;


            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Play with one Player: \n" +
                                  "2. Play with two Players \n" +
                                  "3. Exit the game \n");

                int numOfPlayers = Convert.ToInt32(Console.ReadLine());
                if (numOfPlayers == 1)
                {
                    Random random = new Random();
                    int wordNum = random.Next(0, readFile.Length);
                    string word = readFile[wordNum];
                    while(word.Length < 3)
                    {
                        wordNum = random.Next(0, readFile.Length);
                        word = readFile[wordNum];
                    }
                    correctGuess.CorrectGuessDisplay(word.ToLower(), 10);
                }
                else if (numOfPlayers == 2)
                {
                    Console.WriteLine("Enter the word or words you want the other person to guess: \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string word = null;
                    while(true)
                    {
                        var key = System.Console.ReadKey(true);
                        if(key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        word += key.KeyChar;
                    }
                    Console.WriteLine("How many guesses do they get?(please enter a number): \n");
                    int numberOfLives = Convert.ToInt32(Console.ReadLine());

                    correctGuess.CorrectGuessDisplay(word.ToLower(), numberOfLives);
                }
                else
                {
                    isRunning = false;
                }
            }

        }
    }
}