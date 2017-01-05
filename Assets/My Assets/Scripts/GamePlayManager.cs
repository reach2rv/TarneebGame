using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Responses;
using cardgame;
using UnityEngine.UI;
using GameSparks.Api.Requests;
using GameSparks.Core;
using System;
using System.Timers;
using UnityEngine.EventSystems;
using GameSparks.Api.Messages;

[Serializable]
public class GamePlayManager : MonoBehaviour
{
    public CanvasGroup deckCanvasGroup, bidCanvasGroup, buttonpannel;
    public GameObject[] pcards;
    public Sprite[] lastbidobject;
    public Sprite[] Cards_Club;
    public Sprite[] Cards_Diamond;
    public Sprite[] Cards_Heart;
    public Sprite[] Cards_Spades;
    public Text Bid, Player1, Player2, Player3, MyPlayer;
    private string ChallengeId, playerid, status, lastcard, _nxtplayer, _currentPlayer, _player1, _player2, _player3, _player4;
    private bool isbidding, IsBidding, gotcards;
    private int bidcount, lastbid;

    void Awake()
    {
        buttonpannel.interactable = false;
        ChallengeId = PlayerPrefs.GetString("chalid");
        HideBidUI();
        Get_Cards();
        StartCoroutine(Get_MyTurn());
        ChallengeTurnTakenMessage.Listener += ChallengeTurnTakenMessageListner;
    }

    void Start()
    {
        GameSparks.Api.Messages.ScriptMessage.Listener += GetMessages;
    }

    void Update()
    {
        if (IsBidding == true)
        {
            StartCoroutine(Get_MyTurn());
        }
    }

    void ChallengeTurnTakenMessageListner(ChallengeTurnTakenMessage _message)
    {
        _nxtplayer = _message.Challenge.NextPlayer;
        _currentPlayer = _message.Challenge.ScriptData.GetString("currentPlayer");
        IsBidding = (bool)_message.Challenge.ScriptData.GetBoolean("Isbidding");
        status = _message.Challenge.ScriptData.GetString("status");
        lastbid = (int)_message.Challenge.ScriptData.GetInt("bids");
        lastcard = _message.Challenge.ScriptData.GetString("lastcard");
        switch (status)
        {
            case "bidding":
                Status_bidding();
                break;
            case "GamePlay":
                Status_GamePlay();
                break;
        }
    }

    void GetMessages(ScriptMessage message)
    {
        if (message.ExtCode == "bid")
        {
            //Do some stuff
        }

        if (message.ExtCode == "bidcomplete")
        {
            //Do some other stuff
        }
        if (message.ExtCode == "cardplayed")
        {
            //Do some other stuff
        }
    }  
    
    void OnEnable()
    {

    }
    
    public void HideBidUI()
    {
        deckCanvasGroup.alpha = 1;
        deckCanvasGroup.interactable = true;
        deckCanvasGroup.blocksRaycasts = true;

        bidCanvasGroup.alpha = 0;
        bidCanvasGroup.interactable = false;
        bidCanvasGroup.blocksRaycasts = false;

    }

    public void ShowBidUI()
    {
        deckCanvasGroup.alpha = 0.5f;
        deckCanvasGroup.interactable = false;
        deckCanvasGroup.blocksRaycasts = false;

        bidCanvasGroup.alpha = 1;
        bidCanvasGroup.interactable = true;
        bidCanvasGroup.blocksRaycasts = true;
    }

    void Status_bidding()
    {
        //Image theImage = GameObject.Find(pcards[i].name).GetComponent<Image>();

        switch (lastbid)
        {
            case 7:
                Button UserBtnBid_1 = GameObject.Find("BtnBid_1").GetComponent<Button>();
                UserBtnBid_1.interactable = false;
                Image btnbid = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid.sprite = lastbidobject[0];
                break;
            case 8:
                Button BtnBid_2 = GameObject.Find("BtnBid_1").GetComponent<Button>();
                BtnBid_2.interactable = false;
                Image btnbid2 = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid2.sprite = lastbidobject[1];
                break;
            case 9:
                Button BtnBid_3 = GameObject.Find("BtnBid_1").GetComponent<Button>();
                BtnBid_3.interactable = false;
                Image btnbid3 = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid3.sprite = lastbidobject[2];
                break;
            case 10:
                Button BtnBid_4 = GameObject.Find("BtnBid_1").GetComponent<Button>();
                BtnBid_4.interactable = false;
                Image btnbid4 = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid4.sprite = lastbidobject[3];
                break;
            case 11:
                Button BtnBid_5 = GameObject.Find("BtnBid_1").GetComponent<Button>();
                BtnBid_5.interactable = false;
                Image btnbid5 = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid5.sprite = lastbidobject[4];
                break;
            case 12:
                Button BtnBid_6 = GameObject.Find("BtnBid_1").GetComponent<Button>();
                BtnBid_6.interactable = false;
                Image btnbid6 = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid6.sprite = lastbidobject[5];
                break;
            case 13:
                Button BtnBid_7 = GameObject.Find("BtnBid_1").GetComponent<Button>();
                BtnBid_7.interactable = false;
                Image btnbid7 = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid7.sprite = lastbidobject[6];
                break;
        }
        if (_nxtplayer == PlayerPrefs.GetString("userId"))
        {
            ShowBidUI();
        }
    }

    void Status_GamePlay()
    {
        string myplayer = PlayerPrefs.GetString("UserId");
        if (myplayer == _currentPlayer)
        {
            
        }
        if (myplayer == _currentPlayer)
        {

        }
        if (myplayer == _currentPlayer)
        {

        }
        if (myplayer == _currentPlayer)
        {

        }
    }

    void Get_Cards()
    {
        GameObject go = GameObject.Find("Main_API");
        var cards = go.GetComponent<GameSparksManager>().Cards;

        string[] playercards = new string[13];
        var j = 0;
        for (var i = 0; i < playercards.Length; i++)
        {
            string rank = cards[j].GetString("rank");
            string suit = cards[j].GetString("suit");
            playercards[i] = suit + rank;
            j++;
        }
        for (var i = 0; i < pcards.Length; i++)
        {
            pcards[i].name = playercards[i].ToString();
            Image theImage = GameObject.Find(pcards[i].name).GetComponent<Image>();

            switch (pcards[i].name)
            {
                case "C2":
                    theImage.sprite = Cards_Club[0];
                    break;
                case "C3":
                    theImage.sprite = Cards_Club[1];
                    break;
                case "C4":
                    theImage.sprite = Cards_Club[2];
                    break;
                case "C5":
                    theImage.sprite = Cards_Club[3];
                    break;
                case "C6":
                    theImage.sprite = Cards_Club[4];
                    break;
                case "C7":
                    theImage.sprite = Cards_Club[5];
                    break;
                case "C8":
                    theImage.sprite = Cards_Club[6];
                    break;
                case "C9":
                    theImage.sprite = Cards_Club[7];
                    break;
                case "C10":
                    theImage.sprite = Cards_Club[8];
                    break;
                case "C11":
                    theImage.sprite = Cards_Club[9];
                    break;
                case "C12":
                    theImage.sprite = Cards_Club[10];
                    break;
                case "C13":
                    theImage.sprite = Cards_Club[11];
                    break;
                case "C14":
                    theImage.sprite = Cards_Club[12];
                    break;
                case "D2":
                    theImage.sprite = Cards_Diamond[0];
                    break;
                case "D3":
                    theImage.sprite = Cards_Diamond[1];
                    break;
                case "D4":
                    theImage.sprite = Cards_Diamond[2];
                    break;
                case "D5":
                    theImage.sprite = Cards_Diamond[3];
                    break;
                case "D6":
                    theImage.sprite = Cards_Diamond[4];
                    break;
                case "D7":
                    theImage.sprite = Cards_Diamond[5];
                    break;
                case "D8":
                    theImage.sprite = Cards_Diamond[6];
                    break;
                case "D9":
                    theImage.sprite = Cards_Diamond[7];
                    break;
                case "D10":
                    theImage.sprite = Cards_Diamond[8];
                    break;
                case "D11":
                    theImage.sprite = Cards_Diamond[9];
                    break;
                case "D12":
                    theImage.sprite = Cards_Diamond[10];
                    break;
                case "D13":
                    theImage.sprite = Cards_Diamond[11];
                    break;
                case "D14":
                    theImage.sprite = Cards_Diamond[12];
                    break;
                case "H2":
                    theImage.sprite = Cards_Heart[0];
                    break;
                case "H3":
                    theImage.sprite = Cards_Heart[1];
                    break;
                case "H4":
                    theImage.sprite = Cards_Heart[2];
                    break;
                case "H5":
                    theImage.sprite = Cards_Heart[3];
                    break;
                case "H6":
                    theImage.sprite = Cards_Heart[4];
                    break;
                case "H7":
                    theImage.sprite = Cards_Heart[5];
                    break;
                case "H8":
                    theImage.sprite = Cards_Heart[6];
                    break;
                case "H9":
                    theImage.sprite = Cards_Heart[7];
                    break;
                case "H10":
                    theImage.sprite = Cards_Heart[8];
                    break;
                case "H11":
                    theImage.sprite = Cards_Heart[9];
                    break;
                case "H12":
                    theImage.sprite = Cards_Heart[10];
                    break;
                case "H13":
                    theImage.sprite = Cards_Heart[11];
                    break;
                case "H14":
                    theImage.sprite = Cards_Heart[12];
                    break;
                case "S2":
                    theImage.sprite = Cards_Spades[0];
                    break;
                case "S3":
                    theImage.sprite = Cards_Spades[1];
                    break;
                case "S4":
                    theImage.sprite = Cards_Spades[2];
                    break;
                case "S5":
                    theImage.sprite = Cards_Spades[3];
                    break;
                case "S6":
                    theImage.sprite = Cards_Spades[4];
                    break;
                case "S7":
                    theImage.sprite = Cards_Spades[5];
                    break;
                case "S8":
                    theImage.sprite = Cards_Spades[6];
                    break;
                case "S9":
                    theImage.sprite = Cards_Spades[7];
                    break;
                case "S10":
                    theImage.sprite = Cards_Spades[8];
                    break;
                case "S11":
                    theImage.sprite = Cards_Spades[9];
                    break;
                case "S12":
                    theImage.sprite = Cards_Spades[10];
                    break;
                case "S13":
                    theImage.sprite = Cards_Spades[11];
                    break;
                case "S14":
                    theImage.sprite = Cards_Spades[12];
                    break;
            }

        }
    }

    void Get_Player_Position()
    {
        GameObject go = GameObject.Find("Main_API");
        _player1 = go.GetComponent<GameSparksManager>()._player1;
        _player2 = go.GetComponent<GameSparksManager>()._player1;
        _player3 = go.GetComponent<GameSparksManager>()._player1;
        _player4 = go.GetComponent<GameSparksManager>()._player1;

        new GetTeamRequest()
            .SetTeamId("")
            .Send((response) =>
            {
                GSEnumerable<GetTeamResponse._Player> members = response.Members;
                foreach (GetTeamResponse._Player user in members)
                {
                    if (user.Id == PlayerPrefs.GetString("UserId"))
                        {
                            Player1.text = user.DisplayName;
                    }
                }



            });

    }

    IEnumerator Get_MyTurn()
    {
        string Challengeid = PlayerPrefs.GetString("chalid");
        bool myturn = false;
        new GetChallengeRequest()
            .SetChallengeInstanceId(Challengeid)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    IsBidding = (bool)response.Challenge.ScriptData.GetBoolean("Isbidding");
                    if (PlayerPrefs.GetString("userId") == response.Challenge.NextPlayer)
                    {
                        myturn = true;

                        //IsBidding = (bool)response.Challenge.ScriptData.GetBoolean("Isbidding");
                        bidcount = (int)response.Challenge.ScriptData.GetInt("bidcount");
                        if (bidcount == 5)
                        {
                            buttonpannel.interactable = true;
                            int highbid = (int)response.Challenge.ScriptData.GetInt("highestbid");
                            string bidWinner = response.Challenge.ScriptData.GetString("bidwinner");
                        }
                    }
                }
                else
                    Debug.Log("Error Retrieving Leader board Data...");
            });
        yield return new WaitUntil(() => myturn == true);
        isbidding = true;
        ShowBidUI();
    }

    public void bid(int bid)
    {
        StartCoroutine(bidding(bid));
    }

    public IEnumerator bidding(int bid)
    {
        new LogChallengeEventRequest_bid()
            .SetChallengeInstanceId(ChallengeId)
            .Set_tricks(bid)
            .Send((_message) =>
            {
                if (!_message.HasErrors)
                {
                    isbidding = false;
                }
                else
                    Debug.Log("Error Retrieving Leader board Data...");
            });
        yield return new WaitUntil(() => isbidding == false);
        HideBidUI();
    }

    public void play_card()
    {
        if (bidcount == 5)
        {
            var go = EventSystem.current.currentSelectedGameObject;
            if (go != null)
            {
                new LogChallengeEventRequest_takeTurn()
                 .SetChallengeInstanceId(ChallengeId)
                 .Set_card(go.name)
                 .Send((_message) =>
                 {
                     if (!_message.HasErrors)
                     {
                         Debug.Log("Card Played");
                     }
                     else
                         Debug.Log("Error while Playing Card");
                 });
            }
            go.SetActive(false);
        }
    }
}