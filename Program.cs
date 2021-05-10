using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** Welcome to the Mastermind Game   *******\n\n");
            MastermindGame masterMind = new MastermindGame();
            masterMind.Play();
            Console.ReadLine();
        }
    }

    public class MastermindGame
    {
        public void Play()
        {
            int totalAttempts = 10;
            bool correctAnswerFlag = false;
            char[] result = new char[4];
            
            // Step 1: Generate the random number

            Random _random = new Random();
            var randomNumber = Generate4DigitRandomNumber(_random);

            Console.WriteLine("Please enter the answer in 4 digits:");
            while(totalAttempts > 0 && !correctAnswerFlag)
            {
                // Accept the answer from user
                Console.Write("Attempt No. {0}: ", (10 - totalAttempts) + 1);
                var userResponse = int.Parse(Console.ReadLine());
                totalAttempts--;
                if(!(userResponse >= 1000 && userResponse <= 9999))
                {
                    Console.WriteLine("Invalid Input.");
                    continue;
                }

                int matchDigitCount = 0;
                for (int index = 0, divider = 1000; index < 4; divider/=10, index++)
                {
                    var userRespondedDigit = ((userResponse / divider) % 10);
                    result[index] = ' ';
                    if (randomNumber[index] == userRespondedDigit)
                    {
                        result[index] = '+';
                        matchDigitCount++;
                    } 
                    else if (randomNumber.Contains(userRespondedDigit))
                    {
                        result[index] = '-';
                    }
                    Console.Write("{0} ", userRespondedDigit);
                }
                Console.WriteLine();
                for (int index = 0; index < 4; index++)
                {
                    Console.Write("{0} ", result[index]);
                }
                if(matchDigitCount == 4)
                {
                    break;
                } 
                else if(totalAttempts > 0)
                {
                    Console.WriteLine("\n\nPlease try again.");
                }
            }
            if (totalAttempts > 0)
            {
                Console.WriteLine("\n\nCONGRATULATIONS. You have won the game.");
            }
            else
            {
                Console.WriteLine("\n\nSorry you have lost the game.");
            }

        }

        public List<int> Generate4DigitRandomNumber(Random _random)
        {
            List<int> randomDigits = new List<int>();
            int digitsLeft = 4;
            while(digitsLeft > 0)
            {
                var randomDigit = _random.Next(1, 7);
                if (!randomDigits.Contains(randomDigit) && randomDigit != 7)
                {
                    randomDigits.Add(randomDigit);
                    digitsLeft--;
                }
            }
            return randomDigits;
        }
    }
}
