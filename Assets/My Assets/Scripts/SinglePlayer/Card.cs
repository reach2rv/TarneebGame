using UnityEngine;
using System.Collections;
using System;

namespace thecardsgame
{
    public class Cards : MonoBehaviour, IComparable<Cards>
    {

        /// <summary>
        /// The card rank
        /// </summary>
        public int Rank { get; private set; }
        /// <summary>
        /// The card suit (S,H,D,C)
        /// </summary>
        public Suit Suit { get; private set; }

        /// <summary>
        /// Constructor that creates the object from the rank and suit
        /// </summary>
        public Cards(int card, Suit suit)
        {
            this.Rank = card;
            this.Suit = suit;
        }

        /// <summary>
        /// Constructor that creates the object from string representation
        /// in the format of [Rank][Suit] for example AS => Ace of Spades, 10C => 10 of Clubs
        /// </summary>
        /// <param name="card"></param>
        public Cards(string card)
        {
            string tempCard, tempSuit;
            tempCard = card.Substring(0, card.Length - 1);
            tempSuit = card.Substring(card.Length - 1, 1);

            this.Rank = int.Parse(tempCard);
            this.Suit = SuitFromString(tempSuit);
        }

        /// <summary>
        /// Compares two card objects according to the suit and rank
        /// </summary>
        public int CompareTo(Cards other)
        {
            if (this.Suit != other.Suit)
            {
                return ((int)this.Suit).CompareTo((int)other.Suit) * -1;
            }
            else
            {
                if (this.Rank != 1 && other.Rank != 1)
                {
                    return this.Rank.CompareTo(other.Rank);
                }
                else
                {
                    if (this.Rank == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        /// <summary>
        /// Returns string representation of the card in the format of
        /// [Rank] [Suit] for example A Spades and 10 Diamonds
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string cardString;
            switch (Rank)
            {
                case 1:
                    cardString = "A";
                    break;
                case 11:
                    cardString = "J";
                    break;
                case 12:
                    cardString = "Q";
                    break;
                case 13:
                    cardString = "K";
                    break;
                default:
                    cardString = Rank.ToString();
                    break;
            }

            return string.Format("{0} {1}", cardString, Suit.ToString());
        }

        public static Suit SuitFromString(string suitString)
        {
            switch (suitString.ToUpper())
            {
                case "S":
                    return Suit.Spades;
                case "H":
                    return Suit.Hearts;
                case "D":
                    return Suit.Diamonds;
                case "C":
                    return Suit.Clubs;
                default:
                    throw new ArgumentException(string.Format("Suit {0} is not a valid suit.", suitString));
            }
        }
    }

    /// <summary>
    /// Enumeration of the possible suits
    /// Note: the None element is added to allow for usage in the bidding as no-trump
    /// </summary>
    public enum Suit
    {
        None = 0,
        Clubs= 1,
        Diamonds,        
        Hearts,
        Spades


    }
}
