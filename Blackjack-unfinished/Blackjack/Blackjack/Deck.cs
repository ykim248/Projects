using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        public static Random Rand = new Random();

        public List<Card> Cards = new List<Card>();
        public int DrawCount = 0;

        public Deck()
        {
            for (Suit i = Suit.Clubs; i <= Suit.Spades; i++)
            {
                for (int x = 1; x <= 13; x++)
                {
                    //TheDeck.Clear();
                    Cards.Add(new Card(i, x));
                    //TheDeck = TheDeck.OrderBy(j => rand.Next()).ToList();

                }
            }

            shuffle();
        }

        public void shuffle()
        {
            for (int i = 1; i <= 5200; i++)
            {
                int Loc1 = Rand.Next(0, 52);
                int Loc2 = Rand.Next(0, 52);

                Card Card1 = Cards[Loc1];
                Card Card2 = Cards[Loc2];

                Cards[Loc1] = Card2;
                Cards[Loc2] = Card1;
            }
        }

        public Card DrawCard()
        {

            return Cards[DrawCount++];
        }
    }
}
