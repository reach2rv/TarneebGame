using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class VirtualGoodList : MonoBehaviour {

    public Text outputData1, outputData2, outputData3, entryCount;
    public Sprite sprite1, sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GetLeaderboard()
    {
        Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.ListVirtualGoodsRequest()
            .Send((response) => {

                if (!response.HasErrors)
                {
                    Debug.Log("Found Leader board Data...");
                    outputData1.text = System.String.Empty; // first clear all the data from the output
                    foreach (GameSparks.Api.Responses.ListVirtualGoodsResponse._VirtualGood entry in response.VirtualGoods) // iterate through the leader board data
                    {
                        int quantity = (int)entry.MaxQuantity; // we can get the rank directly
                        string itemsName = entry.Name;
                        long value = (long)entry.Currency1Cost; // we need to get the key, in order to get the score
                        outputData1.text += quantity;
                        outputData2.text += quantity;
                        outputData3.text += quantity;

                        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
                        {
                            spriteRenderer.sprite = sprite2;
                        }
                        else
                        {
                            spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
                        }

                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Leader board Data...");
                }

            });
    }

}
