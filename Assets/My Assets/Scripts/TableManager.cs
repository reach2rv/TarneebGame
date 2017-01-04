using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using System.Collections.Generic;
using System;

namespace cardgame
{
    public class TableManager : MonoBehaviour
    {

        public static TableManager instance;

        //Our runningGame Prefab
        public GameObject runningPrefab;

        //Our list of runningGames
        public List<GameObject> runningGames = new List<GameObject>();


        //public UIGrid inviteGrid;
        public GameObject invitePrefab;
        public List<GameObject> gameInvites = new List<GameObject>();

        // Use this for initialization
        void Start()
        {
            instance = this;
        }

        //This function accepts a string of UserIds and invites them to a new challenge
        public void ChallengeUser(List<string> userIds)
        {
            //we use CreateChallengeRequest with the shortcode of our challenge, we set this in our GameSparks Portal
            new CreateChallengeRequest().SetChallengeShortCode("basic")
                .SetUsersToChallenge(userIds) //We supply the userIds of who we wish to challenge
                .SetEndTime(System.DateTime.Today.AddMinutes(10)) //We set a date and time the challenge will end on
                .SetChallengeMessage("I've challenged you to Tarneeb!") // We can send a message along with the invite
                .Send((response) =>
                {
                    if (response.HasErrors)
                    {
                        Debug.Log(response.Errors);
                    }
                    else
                    {
                    //Show message saying sent!;
                }
                });
        }

        public void GetChallengeInvites()
        {
            //Every time we call GetChallengeInvites we'll refresh the list
            for (int i = 0; i < gameInvites.Count; i++)
            {
                //Destroy all gameInvite gameObjects currently in the scene
                Destroy(gameInvites[i]);
            }
            //Clear the list of gameInvites so we don't have null reference errors
            gameInvites.Clear();

            //We send a ListChallenge Request with the shortcode of our challenge, we set this in our GameSparks Portal
            new ListChallengeRequest().SetShortCode("basic")
                .SetState("RECEIVED") //We only want to get games that we've received
                .SetEntryCount(50) //We want to pull in the first 50 we find
                .Send((response) =>
                {
                //For every challenge we get
                foreach (var challenge in response.ChallengeInstances)
                    {
                    //Add the gameObject to the list of friends
                    }
                });
        }

        public void GetRunningChallenges()
        {
            //Every time we call GetChallengeInvites we'll refresh the list
            for (int i = 0; i < runningGames.Count; i++)
            {
                //Destroy all runningGame gameObjects currently in the scene
                Destroy(runningGames[i]);
            }
            //Clear the list of friends so we don't have null reference errors
            runningGames.Clear();

            //We send a ListChallenge Request with the shortcode of our challenge, we set this in our GameSparks Portal
            new ListChallengeRequest().SetShortCode("basic")
                .SetState("RUNNING") //We want to get all games that are running
                .SetEntryCount(50) //We want to pull in the first 50
                .Send((response) =>
                {
                //For every challenge we receive
                foreach (var challenge in response.ChallengeInstances)
                    {
                     //For every player in the collection of players who have accepted the challenge
                    foreach (var player in challenge.Accepted)
                        {
                            //Add their names and their Ids to the list i each respective Running Game Entry

                        }

                    //Add the gameObject to the list of friends
                   
                    }
                });
        }
    }
}