using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using thecardsgame;
using System.Linq;
using System;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Dictionary<PlayerPosition, List<Cards>> PlayerCards;
    public GameObject[] cards;
    public Image[] card_face;
    private Sprite cardface;
    public int numcards = 13;
    public CanvasGroup deckCanvasGroup;
    public CanvasGroup bidCanvasGroup;
    public GameSession gameSession;
    public Text BidValue;
    bool isbid = false;
    private bool _keyPressed = false;

    public void TestBasicGame()
    {
        this.gameSession = PrepareGameSession();

        Player north = gameSession.GetPlayer(PlayerPosition.North);
        Player south = gameSession.GetPlayer(PlayerPosition.South);
        Player east = gameSession.GetPlayer(PlayerPosition.East);
        Player west = gameSession.GetPlayer(PlayerPosition.West);

        StartCoroutine(bidding());
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
        Player west = new Player(Guid.NewGuid(), "Guest");

        PlayerCards = new Dictionary<PlayerPosition, List<Cards>>(4);

        gameSession.Join(north, PlayerPosition.North);
        gameSession.Join(south, PlayerPosition.South);
        gameSession.Join(east, PlayerPosition.East);
        gameSession.Join(west, PlayerPosition.West);

        CardsShuffler shuffler = new CardsShuffler();
        var shuffledCards = shuffler.Shuffle();


        PlayerCards[PlayerPosition.South] = shuffledCards[0];
        PlayerCards[PlayerPosition.East] = shuffledCards[1];
        PlayerCards[PlayerPosition.North] = shuffledCards[2];
        PlayerCards[PlayerPosition.West] = shuffledCards[3];

        var randomNumber = UnityEngine.Random.Range(0, 12);
        var j = 0;
        for (var i = 0; i < cards.Length; i++)
        {
            //j++;
            if (i == 13) j++;
            cards[i].name = shuffledCards[3][j].ToString();
            j++;          
        }



        // while (gameSession.Status == GameSessionStatus.Bidding)
        //{
        //PlayerPosition currentTurn = gameSession.CurrentTurn.Value;
        //Player player = gameSession.GetPlayer(currentTurn);
        //if (player.Name == "smart")
        //{
        //    int bid = Convert.ToInt32(gameSession.countcard());
        //    if (bid == 0)
        //        gameSession.PlaceBid(Bid.CreatePassBid(player));
        //    else
        //        gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));

        //}
        //else if (player.Name == "regular")
        //{
        //    int bid = Convert.ToInt32(gameSession.countcard());
        //    if (bid == 0)
        //        gameSession.PlaceBid(Bid.CreatePassBid(player));
        //    else
        //        gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));
        //}
        //else if (player.Name == "dumb")
        //{
        //    int bid = Convert.ToInt32(gameSession.countcard());
        //    if (bid == 0)
        //        gameSession.PlaceBid(Bid.CreatePassBid(player));
        //    else
        //        gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));
        //}
        //else if (player.Name == "Guest")
        //{
        //   // DoShowBidUI();
        //    StartCoroutine(WaitFunction());
        //}

        //}
        
       return gameSession;
    }

    IEnumerator bidding()
    {
        //player
        bid();
        yield return new WaitUntil(() => isButtonClicked == true);
        //robo1
        isButtonClicked = false;
        bid();
        yield return new WaitUntil(() => isButtonClicked == true);
        //robo2
        isButtonClicked = false;
        bid();
        yield return new WaitUntil(() => isButtonClicked == true);
        //robo3
        isButtonClicked = false;
        bid();
        yield return new WaitUntil(() => gameSession.Status == GameSessionStatus.GamePlay);
    }


    void bid()
    {
        if (gameSession.Status == GameSessionStatus.Bidding)
        {
            PlayerPosition currentTurn = gameSession.CurrentTurn.Value;
            Player player = gameSession.GetPlayer(currentTurn);
            if (player.Name == "smart")
            {
                int bid = Convert.ToInt32(gameSession.countcard());
                if (bid == 0)
                {
                    gameSession.PlaceBid(Bid.CreatePassBid(player));
                    isButtonClicked = true;
                }
                else
                {
                    gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));
                    isButtonClicked = true;
                }

            }
            else if (player.Name == "regular")
            {
                int bid = Convert.ToInt32(gameSession.countcard());
                if (bid == 0)
                {
                    gameSession.PlaceBid(Bid.CreatePassBid(player));
                    isButtonClicked = true;
                }
                else
                {
                    gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));
                    isButtonClicked = true;
                }
            }
            else if (player.Name == "dumb")
            {
                int bid = Convert.ToInt32(gameSession.countcard());
                if (bid == 0)
                {
                    gameSession.PlaceBid(Bid.CreatePassBid(player));
                    isButtonClicked = true;
                }
                else
                {
                    gameSession.PlaceBid(Bid.CreateBid(player, bid, Suit.Diamonds));
                    isButtonClicked = true;
                }
            }
            else if (player.Name == "Guest")
            {
                // DoShowBidUI();
                StartCoroutine(WaitFunction());
            }
        }
    }

    bool isButtonClicked;
    IEnumerator WaitFunction()
    {
        // Do stuff
        DoShowBidUI();
        while (!isButtonClicked) yield return null;
        DSshowbidUINo();
    }


    private void Awake()
    {

        DSshowbidUINo();
    }

    public void DSshowbidUINo()
    {
        deckCanvasGroup.alpha = 1;
        deckCanvasGroup.interactable = true;
        deckCanvasGroup.blocksRaycasts = true;

        bidCanvasGroup.alpha = 0;
        bidCanvasGroup.interactable = false;
        bidCanvasGroup.blocksRaycasts = false;
    }



    void FirstFunction()
    {
        //by default in our settings this is the space bar, so we will use this just to make it simple.
        StartCoroutine(WaitForKeyPress(KeyCode.Return));
        //to demonstrate that coroutines can work in parallel, we will make it do something right after the coroutine is told to begin.
        print("Coroutine did begin.");
    }


    public IEnumerator WaitForKeyPress(KeyCode keycode)
    {
        while (!_keyPressed)
        {
            if (Input.GetKeyDown(keycode))
            {
                DoShowBidUI();
                break;
            }
            print("Awaiting key input.");
            yield return 0;
        }
    }

    

    public void Bidentered()
    {
        Player west = gameSession.GetPlayer(PlayerPosition.West);
        int mybid = Convert.ToInt32(BidValue.text);

        gameSession.PlaceBid(Bid.CreateBid(west, mybid, Suit.Diamonds));
        isbid = true;
        isButtonClicked = true;
        _keyPressed = true;
    }

    public void DoShowBidUI()
    {
        deckCanvasGroup.alpha = 0.5f;
        deckCanvasGroup.interactable = false;
        deckCanvasGroup.blocksRaycasts = false;

        bidCanvasGroup.alpha = 1;
        bidCanvasGroup.interactable = true;
        bidCanvasGroup.blocksRaycasts = true;
    }
}
