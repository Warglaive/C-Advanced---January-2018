using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Number_Wars
{
    public class Program
    {
        public static void Main()
        {
            var firstPlayerCardsInput = Console.ReadLine()
                .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var secondPlayerCardsInput = Console.ReadLine()
                .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int firstCardNum;
            int secondCardNum;
            var firstPlayerHand = new Queue<string>(firstPlayerCardsInput);
            var secondPlayerHand = new Queue<string>(secondPlayerCardsInput);
            const string numberPatters = @"\d+";
            var numRegex = new Regex(numberPatters);

            var turnsCounter = 0;
            while (firstPlayerHand.Count != 0
                && secondPlayerHand.Count != 0
                && turnsCounter <= 1000000)
            {
                //take cards's numbers
                var firstCard = firstPlayerHand.Dequeue();
                var firstCardNumMatch = numRegex.Match(firstCard);

                firstCardNum = int.Parse(firstCardNumMatch.Value);

                var secondCard = secondPlayerHand.Dequeue();
                var secondCardNumMatch = numRegex.Match(secondCard);

                secondCardNum = int.Parse(secondCardNumMatch.Value);
                //The player with the bigger card (higher number) 
                //gets both cards and puts them in the bottom of his deck.
                if (firstCardNum > secondCardNum)
                {
                    firstPlayerHand.Enqueue(firstCard);
                    firstPlayerHand.Enqueue(secondCard);
                    //
                    firstPlayerHand.OrderByDescending(x => x);
                    //
                    turnsCounter++;
                    continue;
                }
                else if (firstCardNum < secondCardNum)
                {
                    secondPlayerHand.Enqueue(secondCard);
                    secondPlayerHand.Enqueue(firstCard);
                    //
                    secondPlayerHand.OrderByDescending(x => x);
                    //
                    turnsCounter++;
                    continue;
                }
                // if cards equal
                //Then every player has to put 3 more cards on the field
                else
                {
                    turnsCounter++;
                    while (firstPlayerHand.Count != 0
                        && secondPlayerHand.Count != 0
                        && turnsCounter <= 1000000)
                    {
                        var firstPlayerCard = string.Empty;
                        var secondPlayerCard = string.Empty;
                        var firstPlayerLetters = new List<string>();
                        var secondPlayerLetters = new List<string>();

                        var firstplayersCurrentThreeCards = new Queue<string>();
                        var secondplayersCurrentThreeCards = new Queue<string>();
                        if (firstPlayerHand.Count >= 3
                            && secondPlayerHand.Count >= 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                firstPlayerCard = firstPlayerHand.Peek();
                                firstplayersCurrentThreeCards.Enqueue(firstPlayerHand.Dequeue());

                                secondPlayerCard = secondPlayerHand.Peek();
                                secondplayersCurrentThreeCards.Enqueue(secondPlayerHand.Dequeue());
                                //take letters
                                firstPlayerLetters.Add(firstPlayerCard.Last().ToString());
                                secondPlayerLetters.Add(secondPlayerCard.Last().ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Draw after {turnsCounter} turns");
                            Environment.Exit(0);

                        }
                        var firstPlayerTotalLettersSum = CalculateBiggestLettersSum(firstPlayerLetters);
                        var secondPlayerTotalLettersSum = CalculateBiggestLettersSum(secondPlayerLetters);
                        //Again check for winner,
                        //but this time you need to check for the bigger sum of letters at the end of the cards. 
                        if (firstPlayerTotalLettersSum > secondPlayerTotalLettersSum)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                firstPlayerHand.Enqueue(firstplayersCurrentThreeCards.Dequeue());
                                firstPlayerHand.Enqueue(secondplayersCurrentThreeCards.Dequeue());
                            }
                        }
                        else if (firstPlayerTotalLettersSum < secondPlayerTotalLettersSum)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                secondPlayerHand.Enqueue(secondplayersCurrentThreeCards.Dequeue());
                                secondPlayerHand.Enqueue(firstplayersCurrentThreeCards.Dequeue());
                            }
                        }
                        else if (firstPlayerHand.Count == 0 && secondPlayerHand.Count == 0)
                        {
                            Console.WriteLine($"Draw after {turnsCounter} turns");
                            Environment.Exit(0);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            if (firstPlayerHand.Count > secondPlayerHand.Count)
            {
                Console.WriteLine($"First player wins after {turnsCounter} turns");
                //Environment.Exit(0);
            }
            else if (firstPlayerHand.Count < secondPlayerHand.Count)
            {
                Console.WriteLine($"Second player wins after {turnsCounter} turns");
                // Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Draw after {turnsCounter} turns");
                // Environment.Exit(0);
            }
        }

        private static int CalculateBiggestLettersSum(List<string> currentPlayerLetters)
        {
            var lettersTotalSum = 0;
            foreach (var currentLetter in currentPlayerLetters)
            {
                switch (currentLetter)
                {
                    case "a":
                        lettersTotalSum += 1;
                        break;
                    case "b":
                        lettersTotalSum += 2;
                        break;
                    case "c":
                        lettersTotalSum += 3;
                        break;
                    case "d":
                        lettersTotalSum += 4;
                        break;
                    case "e":
                        lettersTotalSum += 5;
                        break;
                    case "f":
                        lettersTotalSum += 6;
                        break;
                    case "g":
                        lettersTotalSum += 7;
                        break;
                    case "h":
                        lettersTotalSum += 8;
                        break;
                    case "i":
                        lettersTotalSum += 9;
                        break;
                    case "j":
                        lettersTotalSum += 10;
                        break;
                    case "k":
                        lettersTotalSum += 11;
                        break;
                    case "l":
                        lettersTotalSum += 12;
                        break;
                    case "m":
                        lettersTotalSum += 13;
                        break;
                    case "n":
                        lettersTotalSum += 14;
                        break;
                    case "o":
                        lettersTotalSum += 15;
                        break;
                    case "p":
                        lettersTotalSum += 16;
                        break;
                    case "q":
                        lettersTotalSum += 17;
                        break;
                    case "r":
                        lettersTotalSum += 18;
                        break;
                    case "s":
                        lettersTotalSum += 19;
                        break;
                    case "t":
                        lettersTotalSum += 20;
                        break;
                    case "u":
                        lettersTotalSum += 21;
                        break;
                    case "v":
                        lettersTotalSum += 22;
                        break;
                    case "w":
                        lettersTotalSum += 23;
                        break;
                    case "x":
                        lettersTotalSum += 24;
                        break;
                    case "y":
                        lettersTotalSum += 25;
                        break;
                    case "z":
                        lettersTotalSum += 16;
                        break;
                }
            }
            return lettersTotalSum;
        }
    }
}

