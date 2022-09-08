using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    [Serializable]
    public enum PacketType
    {
        Draw,
        PlayerInGame
    }

    [Serializable]
    public class Packet
    {
        public PacketType p;
    }

    [Serializable]
    public class Chat : Packet
    {
        public string Text;
    }

    [Serializable]
    public class Deck : Packet
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
                    Cards.Add(new Card(i, x));
                }
            }

            shuffle();
        }

        public Card DrawCard()
        {
            return Cards[DrawCount++];
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
    }

    [Serializable]
    public class Table : Packet
    {
        public List<Player> Players = new List<Player>();
        public List<Player> ActivePlayers = new List<Player>();

        Deck theDeck = new Deck();
        public void AddAPlayer(string Username)
        {
            Player NewPlayer = new Player();
            NewPlayer.username = Username;

            Players.Add(NewPlayer);
            ActivePlayers.Add(NewPlayer);
        }

        public void GivetoPlayer(string PlayerName)
        {
            foreach (Player PlayerVal in ActivePlayers)
            {
                if(PlayerVal.username == PlayerName)
                {
                    PlayerVal.Hand.Add(theDeck.DrawCard());
                    PlayerVal.HandIterator++;
                    break;
                }
            }
        }

        
    }

    [Serializable]

    public class JoinTable: Packet
    {
        public int TableNumber;
    }

    [Serializable]

    public class SetUsername : Packet
    {
        public string Username;
    }

    [Serializable]

    public class TableStatus : Packet
    {
        public Table[] Tables = new Table[3];

        public TableStatus()
        {
            for (int i = 0; i < 3; i++)
            {
                Tables[i] = new Table();
            }
        }
        
    }

    [Serializable]
    public class Player : Packet
    {
        public string username;
        public List<Card> Hand = new List<Card>();
        public int HandIterator = 0;

        public void ClearHand()
        {
            Hand.Clear();
        }
    }

    [Serializable]
    public class Card: Packet
    {
        public int value;
        public Suit CardSuit;

        public Card(Suit SuitVal, int Val)
        {
            value = Val;
            CardSuit = SuitVal;
        }
    }

    [Serializable]
    public class DrawCardRequest : Packet
    {
        public int TableNum;
    }

    public class BetPacket : Packet
    {
        public int MinBet;
        public int TableNum;

        public int PlayerBet;
        public Player SendingPlayer;
    }
}
