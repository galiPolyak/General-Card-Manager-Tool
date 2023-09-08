using System;
using System.Collections.Generic;

namespace GPolyakMP1
{
    public class Hand
    {
        private List <Card> clubs = new List<Card>();
        private List <Card> diamonds = new List<Card>();
        private List <Card> hearts = new List<Card>();
        private List <Card> spades = new List<Card>();


        public Hand()
        {

        }


        public void AddCard(Card card)
        {
            switch (card.GetSuit())
            {
                case "C":
                    clubs.Add(card);
                    break;
                case "D":
                    diamonds.Add(card);
                    break;
                case "H":
                    hearts.Add(card);
                    break;
                case "S":
                    spades.Add(card);
                    break;
            }
        }


        public string DisplayHand()
        {
            string handDisplay = "";

            List<Card> result = new List<Card>();

            result.AddRange(clubs);
            result.AddRange(diamonds);
            result.AddRange(hearts);
            result.AddRange(spades);

            for (int i = 0; i < result.Count; i ++)
            {
                handDisplay = handDisplay + result[i].CardDisplay() + ", ";
            }

            handDisplay = handDisplay.Remove(handDisplay.Length - 2);
            return handDisplay;

        }


        public string DisplayScoreBreakdown()
        {
            string cardOutput = "Cards Dealt:".PadRight(35, ' ') + "Points\n" +

                                DisplaySuitScore(clubs, "Clubs") + GetSuitScore(clubs).ToString().PadLeft(2, ' ') + "\n" +

                                DisplaySuitScore(diamonds, "Diamonds") + GetSuitScore(diamonds).ToString().PadLeft(2, ' ') + "\n" +

                                DisplaySuitScore(hearts, "Hearts") + GetSuitScore(hearts).ToString().PadLeft(2, ' ') + "\n" +

                                DisplaySuitScore(spades, "Spades") + GetSuitScore(spades).ToString().PadLeft(2, ' ') + "\n" +

                                "Total".PadLeft(36, ' ') + GetTotalScore().ToString().PadLeft(3, ' ');
            return cardOutput;
        }


        private string DisplaySuitScore(List <Card> cards, string suit)
        {
            string suitScore;
            string cardRanks = "";

            for (int i = 0; i < cards.Count; i++)
            {
                cardRanks += " " + cards[i].GetRank();
            }

            suitScore = suit.PadRight(8, ' ') + cardRanks.PadRight(29, ' ');
            return suitScore;

        }


        private int GetSuitScore(List<Card> cards)
        {
            int suitScore = 0;

            for (int i = 0; i < cards.Count; i++)
            {
                suitScore += cards[i].GetValue();
            }

            if (cards.Count == 0)
            {
                suitScore += 3;
            }
            else if (cards.Count == 1)
            {
                suitScore += 2;
            }
            else if (cards.Count == 2)
            {
                suitScore += 1;
            }

            return suitScore;
        }


        private int GetTotalScore()
        {
            int totalScore = GetSuitScore(clubs) + GetSuitScore(diamonds) + GetSuitScore(hearts) + GetSuitScore(spades);
            return totalScore;
        }
    }
}
