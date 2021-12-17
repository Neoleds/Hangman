using System;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {

        static void Main(string[] args)
        {

            int guesses = 10;

            Random rnd = new Random();
            string[] secretwordList = { "volvo", "saab", "secretword" };

            int nameIndex = rnd.Next(secretwordList.Length);

            string secretword = secretwordList[nameIndex];
            char[] secretletters = secretword.ToCharArray();

            StringBuilder wrongword = new StringBuilder();

            Console.WriteLine("Välkommen till hänga gubbe. Gissa på enskilda bokstäver eller hela ord. Du har 10 försök på dig.");

            for (int i = 0; i < secretword.Length; i++)
            {
                Console.Write(" _");
            }
            Console.WriteLine();

            char[] guessletters = new char[secretletters.Length];


            for (int i = 0; i < secretletters.Length; i++)
            {
                guessletters[i] = '_';
            }

            while (guesses > 0)
            {
                string playerGuess = Console.ReadLine();

                if (playerGuess.ToLower() == secretword)
                {
                    Console.WriteLine("Grattis, du vann! \n" + secretword);
                    return;
                }
                else if (playerGuess.Length == 1)
                {
                    bool guessCorrect = false;
                    char[] playerGuessCharArray = playerGuess.ToCharArray();
                    char playerGuessChar = char.ToLower(playerGuessCharArray[0]);

                    //Går igenom hela arrayen av secretletters och jämför med gissade bokstaven.
                    for (int i = 0; i < secretletters.Length; i++)
                    {
                        if (playerGuessChar == secretletters[i])
                        {
                            //Byter ut understreck mot gissning.
                            guessletters[i] = playerGuessChar;
                            guessCorrect = true;
                        }
                    }

                    if (Enumerable.SequenceEqual(secretletters, guessletters))
                    {
                        Console.WriteLine("Grattis, du vann! \n" + secretword);
                        return;
                    }
                    if (guessCorrect == false)
                    {

                        if (wrongword.ToString().Contains(playerGuessChar.ToString()))
                        {
                            Console.WriteLine("Redan gissat.");
                        }
                        else
                        {

                            wrongword.Append(playerGuessChar);
                            guesses--;
                        }
                    }
                    Console.WriteLine("Antal gissningar: " + guesses);
                    Console.WriteLine("Fel gissningar: " + wrongword);
                    for (int i = 0; i < guessletters.Length; i++)
                    {
                        Console.Write(guessletters[i] + " ");

                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Du kan bara gissa på hela ordet eller 1 bokstav. Försök igen.");
                }

            }


        }

    }
}