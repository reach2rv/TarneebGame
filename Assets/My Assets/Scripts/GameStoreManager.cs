using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using System;
using UnityEngine.EventSystems;
public class GameStoreManager : MonoBehaviour
{
    public Text playerName, currency1, coinsTxt;
    public Sprite[] Goodies;
    public Sprite[] MT;
    public Sprite[] MB;
    public Sprite[] MS;
    public Sprite[] MH;
    public Sprite[] FT;
    public Sprite[] FB;
    public Sprite[] FS;
    public Sprite[] FH;
    public GSEnumerable<ListVirtualGoodsResponse._VirtualGood> VGoods;

    private string[] goods;

    

    void Start()
    {
        list_Goods();
        // shopRef.SetActive(false);
    }

    private void UpdatePlayerDetails()
    {
        Debug.Log("Fetching Account Details...");
        new GameSparks.Api.Requests.AccountDetailsRequest()
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Account Details Found...");
                    playerName.text = "Player: " + response.DisplayName; // we can get the display name	
                    currency1.text = "Cash: " + (int)response.Currency1;
                    if (response.VirtualGoods != null)
                    {
                        coinsTxt.text = "x" + (int)response.VirtualGoods.GetNumber("GOLD_COIN");
                    }
                    else
                    {
                        coinsTxt.text = "x0";
                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Account Details...");
                }
            });
    }

    public void OpenShopBttn()
    {
        UpdatePlayerDetails();
    }

    public void ExitShopBttn()
    {

    }

    public void GivePlayerMoreCashBttn()
    {
        Debug.Log("Adding More Cash...");
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("GRANT_CURRENCY")
            .SetEventAttribute("CASH", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Cash Added Successfully...");
                    UpdatePlayerDetails();
                }
                else
                {
                    Debug.Log("Error adding cash...");
                }
            });
    }

    public void BuyCoinsBttn()
    {
        Debug.Log("Buying Virtual Goods...");
        new GameSparks.Api.Requests.BuyVirtualGoodsRequest()
            .SetCurrencyType(1)
            .SetQuantity(1)
            .SetShortCode("GOLD_COIN")
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Virtual Goods Bought Successfully...");
                    UpdatePlayerDetails();
                }
                else
                {
                    Debug.Log("Error Buying Virtual Goods...");
                }
            });
    }

    public void ConsumeCoinsBttn()
    {

        Debug.Log("Consuming Virtual Goods...");
        new GameSparks.Api.Requests.ConsumeVirtualGoodRequest()
                .SetQuantity(1)
                .SetShortCode("GOLD_COIN")
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Virtual Goods Consumed Successfully...");
                        UpdatePlayerDetails();
                    }
                    else
                    {
                        Debug.Log("Error Consuming Virtual Goods...");
                    }
                });
    }

    void select_goods()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        var value = go.transform.Find("").gameObject;
        if (go != null)
        {
            new LogChallengeEventRequest_takeTurn()
             .SetChallengeInstanceId("")
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

    }

    void list_Goods()
    {
        new ListVirtualGoodsRequest()
            .Send((response) =>
            {

                VGoods = response.VirtualGoods;


            });
    }

    void Male_Heads()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode +"btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "MH1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH17":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH18":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH19":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH20":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH21":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH22":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH23":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH24":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Male_Top()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "MT1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString(); ;
                    break;
                case "MT6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT17":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT18":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT19":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT20":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT21":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT22":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT23":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT24":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Male_Shoes()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "MS1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MS16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Male_Bottoms()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "MB1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB17":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB18":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB19":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB20":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB21":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB22":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB23":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB24":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Male_Goodies()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "MG1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MG12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Female_Heads()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "FH1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString(); ;
                    break;
                case "FH3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MH17":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH18":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH19":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH20":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH21":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH22":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH23":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FH24":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Female_Top()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "FT1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MT17":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT18":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT19":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT20":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT21":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT22":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT23":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FT24":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Female_Shoes()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "FS1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FS16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Female_Bottoms()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "FB1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB13":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB14":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB15":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB16":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "MB17":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB18":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB19":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB20":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB21":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB22":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString(); ;
                    break;
                case "FB23":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FB24":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }

    void Female_Goodies()
    {
        foreach (var goods in VGoods)
        {
            GameObject button = GameObject.Find(goods.ShortCode + "btn");
            Image theImage = GameObject.Find(goods.ShortCode).GetComponent<Image>();
            int index = Array.FindIndex(Goodies, s => s.name == goods.ShortCode);

            switch (goods.ShortCode)
            {
                case "FBG1":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString(); ;
                    break;
                case "FG2":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG3":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG4":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG5":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG6":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG7":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG8":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG9":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG10":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG11":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
                case "FG12":
                    theImage.sprite = Goodies[index];
                    button.name = goods.Currency1Cost.ToString();
                    break;
            }
        }
    }
}
