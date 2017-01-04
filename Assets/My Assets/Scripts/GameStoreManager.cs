using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStoreManager : MonoBehaviour {

    public GameObject shopRef, showShopBttn;
    public Text playerName, currency1, coinsTxt;



    void Start()
    {
        shopRef.SetActive(false);
    }


    private void UpdatePlayerDetails()
    {
        Debug.Log("Fetching Account Details...");
        new GameSparks.Api.Requests.AccountDetailsRequest()
            .Send((response) => {

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
        showShopBttn.SetActive(false);
        shopRef.SetActive(true);
        UpdatePlayerDetails();
    }


    public void ExitShopBttn()
    {
        showShopBttn.SetActive(true);
        shopRef.SetActive(false);
    }

    public void GivePlayerMoreCashBttn()
    {
        Debug.Log("Adding More Cash...");
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("GRANT_CURRENCY")
            .SetEventAttribute("CASH", 1)
            .Send((response) => {

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
            .Send((response) => {

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
                .Send((response) => {

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





}
