using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;

public class FBFriendManager : MonoBehaviour 
{

	public GameObject friendEntryPrefab;

	public List<GameObject> friends = new List<GameObject>();

	public void GetFriends()
	{
		//Every time we call get friends we'll refresh the list
		for (int i = 0; i < friends.Count; i++)
		{
			//Destroy all friend gameObjects currently in the scene
			Destroy(friends[i]);
		}
		//Clear the list of friends so we don't have null reference errors
		friends.Clear();
		
		//Send a ListGameFriendsRequest, which will get all facebook friends who have played the game
		new ListGameFriendsRequest().Send((response) =>
		{
			//For ever friend stored in our collection of friends
			foreach (var friend in response.Friends)
			{
				//Add the gameObject to the list of friends
			}
		});
	}
}