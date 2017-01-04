using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace thecardsgame
{

    public class Bots : MonoBehaviour
    {
        public PlayerPosition CurrentTurn { get; }
        private GameSession gameSession { get; set; }
        private GamePlay gamePlay;
        public Dictionary<PlayerPosition, Cards> CurrentTrick { get; private set; }
        public Dictionary<PlayerPosition, List<Cards>> PlayerCards { get; private set; }

        public Bots()
        {

        }

        public Cards placehigher_card()
        {
            Cards maxCard = EvaluateCurrentTrick();
            PlayerPosition position = CurrentTurn;
            Suit tempsuit = maxCard.Suit;
            Cards playcard = null;
            Player currentplayer = gameSession.GetPlayer(CurrentTurn);
            foreach (Cards card in PlayerCards[position])
            {
                if (card.Suit == tempsuit)
                {
                    if (!string.IsNullOrEmpty(card.ToString()))
                    {
                        if (card.Rank > maxCard.Rank)
                        {
                            playcard = card;
                        }
                        else if (card.Rank <= maxCard.Rank)
                        {
                            playcard = card;
                        }

                    }
                    else if (card.Suit == trumpSuit)
                    {
                        if (!string.IsNullOrEmpty(card.ToString()))
                        {
                            if (card.Rank <= maxCard.Rank)
                            {
                                playcard = card;
                            }
                            else if (card.Rank >= maxCard.Rank)
                            {
                                //gameSession.PlaceCard(currentplayer, card);
                                //gamePlay.PlaceCard(currentplayer, card);
                                playcard = card;
                            }
                        }

                    }
                    else
                    {
                        if (card.Rank <= maxCard.Rank)
                        {
                            playcard = card;
                        }
                    }
                    
                }

            }
            return playcard;
        }


        private Cards EvaluateCurrentTrick()
        {
            Cards maxCard = CurrentTrick[CurrentTurn];
            PlayerPosition trickWinner = CurrentTurn;

            foreach (PlayerPosition tempPosition in CurrentTrick.Keys)
            {
                if (tempPosition != CurrentTurn)
                {
                    Cards tempCard = CurrentTrick[tempPosition];
                    if (CompareCards(tempCard, maxCard) > 0)
                    {
                        maxCard = tempCard;
                    }
                }
            }
            return maxCard;
        }

        private Suit trumpSuit { get; }
        private int CompareCards(Cards card1, Cards card2)
        {
            Suit tempTrump = trumpSuit;
            if (card2.Suit != tempTrump && card1.Suit != tempTrump)
            {
                return 0;
            }
            else if (card2.Suit != tempTrump && card1.Suit == tempTrump)
            {
                return 1;
            }
            else if (card1.Suit != tempTrump && card2.Suit != tempTrump)
            {
                return -1;
            }
            else
            {
                return card1.CompareTo(card2);
            }
        }

        //bidding section
        //
        public string Countcards()
        {
            PlayerPosition position = CurrentTurn;
            Suit tempsuit;

            Player currentplayer = gameSession.GetPlayer(CurrentTurn);
            foreach (Cards card in PlayerCards[position])
            {

            }

            return null;
        }


        public enum bots
        {
            smart = 1,
            dumb,
            regular
        }
    }
}