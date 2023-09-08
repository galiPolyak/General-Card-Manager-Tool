using System;

namespace GPolyakMP1
{
    public class Card
    {
        private int value;
        private string rank;
        private string suit;


        public Card(string rank, string suit, int [] values)
        {
            this.rank = rank;
            this.suit = suit;
            value = SetValue(values);
        }


        private int SetValue(int[] values)
        {
            switch (rank)
            {
                case "A":
                    value = values[0]; 
                    break;
                case "K":
                    value = values[12];
                    break;
                case "Q":
                    value = values[11];
                    break;
                case "J":
                    value = values[10];
                    break;
                case "T":
                    value = values[9];
                    break;
                default:
                    value = values[Convert.ToInt32(rank) - 1];
                    break;
            }

            return value;

        }


        public int GetValue()
        {
            return value;
        }


        public string GetSuit()
        {
            return suit;
        }


        public string GetRank()
        {
            return rank;
        }


        public string CardDisplay()
        {
            string rankSuit = rank + suit;
            return rankSuit;
        }
    }
}
