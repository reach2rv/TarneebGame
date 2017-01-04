using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using UnityEngine.UI;

public class GameFriendManager : MonoBehaviour 
{
    public Text FBName, DName, id;

    public Sprite sprite1, sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer;
    bool isOnline = false;

    public void GetFriends()
	{
	
		//Send a ListGameFriendsRequest, which will get all facebook friends who have played the game
		new ListGameFriendsRequest().Send((response) =>
		{
			//For ever friend stored in our collection of friends
			foreach (var friend in response.Friends)
			{
                ////Update all the gameObject's variables
                DName.text = friend.DisplayName;
                id.text = friend.Id;
                isOnline = friend.Online.Value;
                FBName.text = friend.ExternalIds.GetString("FB");
                if (isOnline == true) // if the spriteRenderer sprite = sprite1 then change to sprite2
                {
                    spriteRenderer.sprite = sprite2;
                }
                else
                {
                    spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
                }
            }
		});
	}
}