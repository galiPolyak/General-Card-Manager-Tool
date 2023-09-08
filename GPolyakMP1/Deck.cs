using System;
using System.Collections.Generic;

namespace GPolyakMP1
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        static Random rng = new Random();
        const int SHUFFLE_NUM = 1000;


        public Deck(int [] values)
        {
            ResetDeck(values);
        }


        public void ResetDeck(int [] values)
        {
            cards.Clear();

            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };
            string[] suits = { "C", "D", "H", "S" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    Card tmpCard = new Card(ranks[j], suits[i], values);
                    cards.Add(tmpCard);
                }
            }

            ShuffleDeck();

        }


        public Card GetTopCard()
        {
            Card tmp = cards[0];
            cards.Remove(cards[0]);

            return tmp;
        }


        private void ShuffleDeck()
        {
            for (int i = 0; i < SHUFFLE_NUM; i++)
            {
                int index1 = rng.Next(0, cards.Count);
                int index2 = rng.Next(0, cards.Count);

                Card tmp = cards[index1];
                cards[index1] = cards[index2];
                cards[index2] = tmp;
            }

        }
    }
}
