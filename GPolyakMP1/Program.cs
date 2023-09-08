//Author: Gali Polyak
//File Name: Program.cs
//Project Name: GPoly2akMP1
//Creation Date: Mar. 02, 2022
//Modified Date: Mar. 07, 2022
//Description: General Card Manager Tool

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GPolyakMP1
{
    class MainClass
    {
        const int NUM_HANDS = 4;

        private static int[] values = new int[13];
        private static List<Hand> hands = new List<Hand>();

        private static StreamWriter outFile = null;
        private static StreamReader inFile = null;

        private static string writeFilePath = "PolyakG_Results.txt";
        private static string readFilePath = "CardInput.txt";


        public static void Main(string[] args)
        {
            ReadFile();
            WriteFile();
            hands.Clear();

            Deck deck = new Deck(values);

            for (int j = 0; j < NUM_HANDS; j++)
            {
                hands.Add(new Hand());

                for (int i = 0; i < 13; i++)
                {
                    hands[j].AddCard(deck.GetTopCard());
                }

                Console.WriteLine(hands[j].DisplayHand());
                Console.WriteLine(hands[j].DisplayScoreBreakdown());

                if (j < (NUM_HANDS-1))
                {
                    Console.WriteLine("");
                }
            }

            Console.ReadLine();
        }


        private static void ReadFile()
        {
            string line;
            string[] data;

            inFile = File.OpenText(readFilePath);
            line = inFile.ReadLine();
            data = line.Split(',');

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToInt32(data[i]);
            }

            while (!inFile.EndOfStream)
            {
                line = inFile.ReadLine();

                char[] suitSplit = { 'C', 'D', 'H', 'S' };
                string[] suitRanks = line.Split(suitSplit);

                Hand hand = new Hand();

                suitRanks = suitRanks.Skip(1).ToArray();

                for (int i = 0; i < suitRanks.Length; i++)
                {
                    string passRanks = suitRanks[i];

                    for (int j = 0; j < passRanks.Length; j++)
                    {
                        Card newCard = new Card(passRanks[j].ToString(), suitSplit[i].ToString(), values);
                        hand.AddCard(newCard);
                    }
                }

                hands.Add(hand);
            }

            inFile.Close();
        }


        private static void WriteFile()
        {
            outFile = File.CreateText(writeFilePath);

            for (int j = 0; j < hands.Count; j++)
            {
                outFile.WriteLine(hands[j].DisplayHand());
                outFile.WriteLine(hands[j].DisplayScoreBreakdown());

                if (j < (hands.Count - 1))
                {
                    outFile.WriteLine("");
                }
            }

            outFile.Close();
        }
    }
}
