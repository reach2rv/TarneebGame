using System;
using System.Collections.Generic;
using System.Linq;

namespace thecardsgame
{
    /// <summary>
    /// Encapsulates the shuffling algorithm
    /// </summary>
    public class CardsShuffler
    {
        private const int numberOfPlayers = 4;

        /// <summary>
        /// Shuffles the cards and returns list of lists that represent
        /// the hand of each player.
        /// Note: the hand is sorted from lowest card to the highest card and 
        /// suits are separated
        /// </summary>
        public List<List<Cards>> Shuffle()
        {
            List<List<Cards>> shuffledCards = new List<List<Cards>>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                shuffledCards.Add(new List<Cards>());
            }

            List<Cards> allCards = AllCards;
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            for (int i = allCards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(0, i);
                Cards tempCard = allCards[j];
                allCards[j] = allCards[i];
                allCards[i] = tempCard;
            }


            int tempCount = 1;
            int tempPlayer = 1;
            int cardsPerPlayer = (int)((float)allCards.Count / (float)numberOfPlayers);
            foreach (Cards card in allCards)
            {
                if (tempCount > cardsPerPlayer)
                {
                    tempCount = 1;
                    tempPlayer++;
                }

                shuffledCards[tempPlayer - 1].Add(card);

                tempCount++;
            }

            shuffledCards.ForEach(playerCards => playerCards.Sort());

            return shuffledCards;
        }

        /// <summary>
        /// Generates the un-shuffled cards
        /// </summary>
        private List<Cards> AllCards
        {
            get
            {
                List<Cards> allCards = new List<Cards>();
                for (int i = (int)Suit.Clubs; i <= (int)Suit.Spades; i++)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        Cards card = new Cards(j, (Suit)i);
                        allCards.Add(card);
                    }
                }

                return allCards;
            }
        }
    }
}