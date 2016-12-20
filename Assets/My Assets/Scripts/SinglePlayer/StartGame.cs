using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using thecardsgame;
using System.Linq;
using System;

public class StartGame : MonoBehaviour
{


    public void TestBasicGame()
    {
        GameSession gameSession = PrepareGameSession();

        Player north = gameSession.GetPlayer(PlayerPosition.North);
        Player south = gameSession.GetPlayer(PlayerPosition.South);
        Player east = gameSession.GetPlayer(PlayerPosition.East);
        Player west = gameSession.GetPlayer(PlayerPosition.West);

        //---
        while (gameSession.Status == GameSessionStatus.GamePlay)
        {
            PlayerPosition currentTurn = gameSession.CurrentTurn.Value;
            Player player = gameSession.GetPlayer(currentTurn);

            GamePlayState tempState;
            tempState = gameSession.GetGamePlayState(gameSession.GetPlayer(currentTurn));
            List<Cards> cards = tempState.CurrentCards;
            if (player.Name=="")
            {
                if (tempState.CurrentCards.Count == 0)
                {
                    Cards card = PlayRandomCard(cards, tempState.CurrentTrickBaseSuit);
                    gameSession.PlaceCard(gameSession.GetPlayer(currentTurn), card);
                }
                else
                { 
                    Cards card = gameSession.RoboCard();
                    gameSession.PlaceCard(gameSession.GetPlayer(currentTurn), card);
                }
            }
            //Console.WriteLine("{0}-{1}", currentTurn.ToString(), card.ToString());
        }
        //Console.WriteLine("NS:{0} - EW:{1}",
        //gameSession.MatchScore.Scores[TeamPosition.OneThree],
        //gameSession.MatchScore.Scores[TeamPosition.TwoFour]);
    }

    private Cards PlayRandomCard(List<Cards> cards, Suit baseSuit)
    {
        IEnumerable<Cards> validCards = null;
        int numberOfValidCards = cards.Where(c => c.Suit == baseSuit).Count();
        if (numberOfValidCards > 0)
        {
            validCards = cards.Where(c => c.Suit == baseSuit).Select(c => c);
        }
        else
        {
            validCards = new List<Cards>(cards);
        }

        System.Random random = new System.Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        int randomCardIndex = random.Next(0, validCards.Count() - 1);
        return new List<Cards>(validCards)[randomCardIndex];
    }

    private GameSession PrepareGameSession()
    {
        GameSession gameSession = new GameSession();
        Player north = new Player(Guid.NewGuid(), Bots.bots.regular.ToString());
        Player south = new Player(Guid.NewGuid(), Bots.bots.smart.ToString());
        Player east = new Player(Guid.NewGuid(), Bots.bots.dumb.ToString());
        Player west = new Player(Guid.NewGuid(), "Add player");
        gameSession.Join(north, PlayerPosition.North);
        gameSession.Join(south, PlayerPosition.South);
        gameSession.Join(east, PlayerPosition.East);
        gameSession.Join(west, PlayerPosition.West);


        while (gameSession.Status == GameSessionStatus.Bidding)
        {
            PlayerPosition currentTurn = gameSession.CurrentTurn.Value;
            Player player = gameSession.GetPlayer(currentTurn);
            if (player.Name == "smart")
            {
                int bid = Convert.ToInt32(gameSession.countcard());
                if (bid == 0)
                    gameSession.PlaceBid(Bid.CreatePassBid(player));
                else
                    gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));

            }
            else if (player.Name == "regular")
            {
                int bid = Convert.ToInt32(gameSession.countcard());
                if (bid == 0)
                    gameSession.PlaceBid(Bid.CreatePassBid(player));
                else
                    gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));
            }
            else if (player.Name == "dumb")
            {
                int bid = Convert.ToInt32(gameSession.countcard());
                if (bid == 0)
                    gameSession.PlaceBid(Bid.CreatePassBid(player));
                else
                    gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));
            }
            else
                //TODO: Popup to player to enter bid
                return null;

        }
        return gameSession;
    }
}
