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
    public GameObject PCard_1, PCard_2, PCard_3, PCard_4;
    public Sprite[] lastbidobject;
    public Sprite[] Cards_Club;
    public Sprite[] Cards_Diamond;
    public Sprite[] Cards_Heart;
    public Sprite[] Cards_Spades;
    public Text Bid, Player2, Player3, Player4, MyPlayer, bidwinner, myturn;
    private string ChallengeId, status, lastcard, _nxtplayer, _currentPlayer, _player1, _player2, _player3, _player4, bwinner;
    private bool isbidding, IsBidding;
    private int bidcount, lastbid;

    void Awake()
    {
        PCard_1.SetActive(false);
        PCard_2.SetActive(false);
        PCard_3.SetActive(false);
        PCard_4.SetActive(false);
        buttonpannel.interactable = false;
        Get_Cards();
        Debug.Log("Player Cards hidden");
        ChallengeId = PlayerPrefs.GetString("chalid");

        GameObject go = GameObject.Find("Main_API");
        var nxtplayer = go.GetComponent<GameSparksManager>()._nxtplayer;
        Debug.Log("Got Last Player");
        if (nxtplayer == PlayerPrefs.GetString("userId"))
        {
            ShowBidUI();
        }
        else
        {
            HideBidUI();
        }
        Debug.Log("Started Setting Cards");
        

        //StartCoroutine(Get_MyTurn());
        ChallengeTurnTakenMessage.Listener += ChallengeTurnTakenMessageListner;
        Debug.Log("Done with Cards");
    }

    void Start()
    {
        //GameSparks.Api.Messages.ScriptMessage.Listener += GetMessages;
    }

    void Update()
    {
        if (IsBidding == true)
        {
            //StartCoroutine(Get_MyTurn());
        }
    }

    void ChallengeTurnTakenMessageListner(ChallengeTurnTakenMessage _message)
    {
        Debug.Log("TurnTaken");
        _nxtplayer = _message.Challenge.NextPlayer;
        Debug.Log(_nxtplayer);
        _currentPlayer = _message.Challenge.ScriptData.GetString("currentPlayer");
        Debug.Log(_currentPlayer);
        IsBidding = (bool)_message.Challenge.ScriptData.GetBoolean("Isbidding");
        status = _message.Challenge.ScriptData.GetString("status");
        Debug.Log(status);
        if(status == "GamePlay")
        {
            lastcard = _message.Challenge.ScriptData.GetString("lastcard");
            Bid.text = _message.Challenge.ScriptData.GetString("highestbid");
        }
        lastbid = (int)_message.Challenge.ScriptData.GetInt("bids");
        Debug.Log(lastbid.ToString());
        if(_message.Challenge.ScriptData.GetString("bidwinner") != "")
        {
            bidwinner.text = _message.Challenge.ScriptData.GetString("bidwinner");
            bwinner = _message.Challenge.ScriptData.GetString("bidwinner");
            if (bidwinner.text == PlayerPrefs.GetString("userId"))
            {
                myturn.text = "Play Card";
            }
        }
        Debug.Log("All ok from Challenge");
        switch (status)
        {
            case "bidding":
                Status_bidding();
                break;
            case "Tarneeb":
                Staus_Tarneeb();
                break;
            case "GamePlay":
                buttonpannel.interactable = true;
                Status_GamePlay();
                break;
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
        if (_nxtplayer == PlayerPrefs.GetString("userId"))
        {
            ShowBidUI();
        }

        switch (lastbid)
        {
            case 7:
                Button UserBtnBid_1 = GameObject.Find("UserBid_1").GetComponent<Button>();
                UserBtnBid_1.interactable = false;
                Image btnbid = GameObject.Find("BtnBid_1").GetComponent<Image>();
                btnbid.sprite = lastbidobject[0];
                break;
            case 8:
                Button BtnBid_2 = GameObject.Find("UserBid_2").GetComponent<Button>();
                BtnBid_2.interactable = false;
                Image btnbid2 = GameObject.Find("BtnBid_2").GetComponent<Image>();
                btnbid2.sprite = lastbidobject[1];
                break;
            case 9:
                Button BtnBid_3 = GameObject.Find("UserBid_3").GetComponent<Button>();
                BtnBid_3.interactable = false;
                Image btnbid3 = GameObject.Find("BtnBid_3").GetComponent<Image>();
                btnbid3.sprite = lastbidobject[2];
                break;
            case 10:
                Button BtnBid_4 = GameObject.Find("UserBid_4").GetComponent<Button>();
                BtnBid_4.interactable = false;
                Image btnbid4 = GameObject.Find("BtnBid_4").GetComponent<Image>();
                btnbid4.sprite = lastbidobject[3];
                break;
            case 11:
                Button BtnBid_5 = GameObject.Find("UserBid_5").GetComponent<Button>();
                BtnBid_5.interactable = false;
                Image btnbid5 = GameObject.Find("BtnBid_5").GetComponent<Image>();
                btnbid5.sprite = lastbidobject[4];
                break;
            case 12:
                Button BtnBid_6 = GameObject.Find("UserBid_6").GetComponent<Button>();
                BtnBid_6.interactable = false;
                Image btnbid6 = GameObject.Find("BtnBid_6").GetComponent<Image>();
                btnbid6.sprite = lastbidobject[5];
                break;
            case 13:
                Button BtnBid_7 = GameObject.Find("UserBid_7").GetComponent<Button>();
                BtnBid_7.interactable = false;
                Image btnbid7 = GameObject.Find("BtnBid_7").GetComponent<Image>();
                btnbid7.sprite = lastbidobject[6];
                break;
        }

    }

    void Staus_Tarneeb()
    {
        if(bwinner != PlayerPrefs.GetString("userId") && _nxtplayer == PlayerPrefs.GetString("userId"))
        {
            new LogChallengeEventRequest_pass()
               .SetChallengeInstanceId(ChallengeId)
               .Send((response) =>
               {
                   if(!response.HasErrors)
                   {

                   }
                   else
                   {
                       Debug.Log("");
                   }
               });
        }
    }

    void Status_GamePlay()
    {
        Image PCard1 = GameObject.Find("Player1_Card").GetComponent<Image>();
        Image PCard2 = GameObject.Find("Player1_Card").GetComponent<Image>();
        Image PCard3 = GameObject.Find("Player1_Card").GetComponent<Image>();
        Image PCard4 = GameObject.Find("Player1_Card").GetComponent<Image>();
        Debug.Log("got Player card images");
        switch (lastcard)
        {
            case "C2":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[0];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[0];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[0];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[0];
                    PCard_4.SetActive(true);
                }
                break;
            case "C3":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[1];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[1];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[1];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[1];
                    PCard_4.SetActive(true);
                }
                break;
            case "C4":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[2];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[2];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[2];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[2];
                    PCard_4.SetActive(true);
                }
                break;
            case "C5":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[3];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[3];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[3];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[3];
                    PCard_4.SetActive(true);
                }
                break;
            case "C6":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[4];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[4];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[4];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[4];
                    PCard_4.SetActive(true);
                }
                break;
            case "C7":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[5];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[5];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[5];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[5];
                    PCard_4.SetActive(true);
                }
                break;
            case "C8":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[6];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[6];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[6];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[6];
                    PCard_4.SetActive(true);
                }
                break;
            case "C9":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[7];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[7];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[7];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[7];
                    PCard_4.SetActive(true);
                }
                break;
            case "C10":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[8];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[8];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[8];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[8];
                    PCard_4.SetActive(true);
                }
                break;
            case "C11":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[9];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[9];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[9];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[9];
                    PCard_4.SetActive(true);
                }
                break;
            case "C12":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[10];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[10];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[10];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[10];
                    PCard_4.SetActive(true);
                }
                break;
            case "C13":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[11];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[11];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[11];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[11];
                    PCard_4.SetActive(true);
                }
                break;
            case "C14":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Club[12];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Club[12];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Club[12];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Club[12];
                    PCard_4.SetActive(true);
                }
                break;
            case "D2":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[0];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[0];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[0];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[0];
                    PCard_4.SetActive(true);
                }
                break;
            case "D3":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[1];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[1];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[1];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[1];
                    PCard_4.SetActive(true);
                }
                break;
            case "D4":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[2];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[2];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[2];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[2];
                    PCard_4.SetActive(true);
                }
                break;
            case "D5":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[3];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[3];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[3];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[3];
                    PCard_4.SetActive(true);
                }
                break;
            case "D6":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[4];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[4];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[4];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[4];
                    PCard_4.SetActive(true);
                }
                break;
            case "D7":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[5];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[5];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[5];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[5];
                    PCard_4.SetActive(true);
                }
                break;
            case "D8":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[6];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[6];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[6];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[6];
                    PCard_4.SetActive(true);
                }
                break;
            case "D9":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[7];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[7];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[7];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[7];
                    PCard_4.SetActive(true);
                }
                break;
            case "D10":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[8];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[8];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[8];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[8];
                    PCard_4.SetActive(true);
                }
                break;
            case "D11":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[9];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[9];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[9];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[9];
                    PCard_4.SetActive(true);
                }
                break;
            case "D12":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[10];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[10];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[10];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[10];
                    PCard_4.SetActive(true);
                }
                break;
            case "D13":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[11];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[11];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[11];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[11];
                    PCard_4.SetActive(true);
                }
                break;
            case "D14":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Diamond[12];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Diamond[12];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Diamond[12];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Diamond[12];
                    PCard_4.SetActive(true);
                }
                break;
            case "H2":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[0];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[0];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[0];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[0];
                    PCard_4.SetActive(true);
                }
                break;
            case "H3":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[1];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[1];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[1];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[1];
                    PCard_4.SetActive(true);
                }
                break;
            case "H4":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[2];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[2];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[2];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[2];
                    PCard_4.SetActive(true);
                }
                break;
            case "H5":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[3];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[3];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[3];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[3];
                    PCard_4.SetActive(true);
                }
                break;
            case "H6":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[4];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[4];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[4];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[4];
                    PCard_4.SetActive(true);
                }
                break;
            case "H7":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[5];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[5];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[5];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[5];
                    PCard_4.SetActive(true);
                }
                break;
            case "H8":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[6];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[6];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[6];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[6];
                    PCard_4.SetActive(true);
                }
                break;
            case "H9":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[7];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[7];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[7];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[7];
                    PCard_4.SetActive(true);
                }
                break;
            case "H10":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[8];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[8];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[8];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[8];
                    PCard_4.SetActive(true);
                }
                break;
            case "H11":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[9];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[9];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[9];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[9];
                    PCard_4.SetActive(true);
                }
                break;
            case "H12":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[10];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[10];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[10];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[10];
                    PCard_4.SetActive(true);
                }
                break;
            case "H13":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[11];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[11];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[11];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[11];
                    PCard_4.SetActive(true);
                }
                break;
            case "H14":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Heart[12];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Heart[12];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Heart[12];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Heart[12];
                    PCard_4.SetActive(true);
                }
                break;
            case "S2":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[0];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[0];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[0];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[0];
                    PCard_4.SetActive(true);
                }
                break;
            case "S3":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[1];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[1];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[1];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[1];
                    PCard_4.SetActive(true);
                }
                break;
            case "S4":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[2];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[2];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[2];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[2];
                    PCard_4.SetActive(true);
                }
                break;
            case "S5":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[3];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[3];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[3];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[3];
                    PCard_4.SetActive(true);
                }
                break;
            case "S6":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[4];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[4];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[4];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[4];
                    PCard_4.SetActive(true);
                }
                break;
            case "S7":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[5];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[5];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[5];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[5];
                    PCard_4.SetActive(true);
                }
                break;
            case "S8":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[6];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[6];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[6];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[6];
                    PCard_4.SetActive(true);
                }
                break;
            case "S9":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[7];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[7];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[7];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[7];
                    PCard_4.SetActive(true);
                }
                break;
            case "S10":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[8];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[8];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[8];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[8];
                    PCard_4.SetActive(true);
                }
                break;
            case "S11":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[9];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[9];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[9];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[9];
                    PCard_4.SetActive(true);
                }
                break;
            case "S12":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[10];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[10];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[10];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[10];
                    PCard_4.SetActive(true);
                }
                break;
            case "S13":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[11];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[11];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[11];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[11];
                    PCard_4.SetActive(true);
                }
                break;
            case "S14":
                if (_currentPlayer == _player1)
                {
                    PCard1.sprite = Cards_Spades[12];
                    PCard_1.SetActive(true);
                }
                else if (_currentPlayer == _player2)
                {
                    PCard2.sprite = Cards_Spades[12];
                    PCard_2.SetActive(true);
                }
                else if (_currentPlayer == _player3)
                {
                    PCard3.sprite = Cards_Spades[12];
                    PCard_3.SetActive(true);
                }
                else
                {
                    PCard4.sprite = Cards_Spades[12];
                    PCard_4.SetActive(true);
                }
                break;

        }

    }

    void Get_Cards()
    {
        GameObject go = GameObject.Find("Main_API");
        List<GSData> cards = go.GetComponent<GameSparksManager>().Cards;
        Debug.Log("Found Cards");
        string[] playercards = new string[13];
        var j = 0;
        for (var i = 0; i < playercards.Length; i++)
        {
            Debug.Log(i.ToString());
            string rank = cards[j].GetString("rank");
            Debug.Log(rank);
            string suit = cards[j].GetString("suit");
            Debug.Log(suit);
            playercards[i] = suit + rank;
            Debug.Log(playercards[i].ToString());
            j++;
        }
        Debug.Log("Added to array");
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
        // _player1 = go.GetComponent<GameSparksManager>()._player1;
        // _player2 = go.GetComponent<GameSparksManager>()._player1;
        //  _player3 = go.GetComponent<GameSparksManager>()._player1;
        //  _player4 = go.GetComponent<GameSparksManager>()._player1;

        new GetTeamRequest()
            .SetTeamId("")
            .Send((response) =>
            {
                GSEnumerable<GetTeamResponse._Player> members = response.Members;
                if (response.Owner.Id == PlayerPrefs.GetString("userId"))
                {
                    foreach (GetTeamResponse._Player players in members)
                    {
                        if (players.Id == PlayerPrefs.GetString("userId"))
                        {
                            MyPlayer.text = players.DisplayName;
                            _player1 = players.Id;
                        }
                        else
                        {
                            Player3.text = players.DisplayName;
                            _player3 = players.Id;
                        }
                    }
                }
                else
                {
                    foreach (GetTeamResponse._Player players in members)
                    {
                        if (string.IsNullOrEmpty(Player2.text))
                        {
                            Player2.text = players.DisplayName;
                            _player2 = players.Id;
                        }
                        else
                        {
                            Player4.text = players.DisplayName;
                            _player4 = players.Id;
                        }
                    }

                }
            });

        new GetTeamRequest()
            .SetTeamId("")
            .Send((response) =>
            {
                GSEnumerable<GetTeamResponse._Player> members = response.Members;
                if (response.Owner.Id == PlayerPrefs.GetString("userId"))
                {
                    foreach (GetTeamResponse._Player players in members)
                    {
                        if (players.Id == PlayerPrefs.GetString("userId"))
                        {
                            MyPlayer.text = players.DisplayName;
                            _player1 = players.Id;
                        }
                        else
                        {
                            Player3.text = players.DisplayName;
                            _player3 = players.Id;
                        }
                    }
                }
                else
                {
                    foreach (GetTeamResponse._Player players in members)
                    {
                        if (string.IsNullOrEmpty(Player2.text))
                        {
                            Player2.text = players.DisplayName;
                            _player2 = players.Id;
                        }
                        else
                        {
                            Player4.text = players.DisplayName;
                            _player4 = players.Id;
                        }
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