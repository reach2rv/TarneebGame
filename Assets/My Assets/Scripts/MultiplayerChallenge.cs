﻿using UnityEngine;
using System.Collections;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using System;

namespace cardgame
{

    public class MultiplayerChallenge : MonoBehaviour
    {

        private string challengeId = "";
        private string oponentID = "";
        private bool isHost = false;


        public readonly string SHORTCODE = "basicMatch";

        void OnEnable()
        {
            //StartCoroutine(GetCards());
        }

        public void Button_click()
        {
            JoinOrCreateChallenge();
        }

        public IEnumerator GetCards()
        {
            Debug.Log("Fetching Cards Data...");
            bool gotcards = false;
            new GetChallengeRequest()
                .SetChallengeInstanceId(PlayerPrefs.GetString("chalid"))
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Found Cards...");
                        GSData cards = response.Challenge.ScriptData.GetGSData(PlayerPrefs.GetString("userId"));
                        gotcards = true;

                    }
                    else
                    {
                        Debug.Log("Error Retrieving Leader board Data...");
                    }

                });
            yield return new WaitUntil(() => gotcards == true);
        }
        //attempts to join or create a new game
        // throw exception or error callback ?
        public void JoinOrCreateChallenge(Action<GSTypedResponse> success = null, Action<GSTypedResponse> error = null)
        {
            TryJoinChallenge(null, (r) =>
            { //success

            },
            (e) =>
            { // error 
              // create the challenge if no one else has created a challenge
                new GameSparks.Api.Requests.CreateChallengeRequest()
                    .SetChallengeShortCode(SHORTCODE)
                        .SetEndTime(System.DateTime.Now.AddMinutes(100))
                        .SetAccessType("PUBLIC")
                        .SetMaxPlayers(2)
                        .Send((createdChallenge) =>
                        {
                            if (createdChallenge.HasErrors)
                            {
                                Debug.LogError("error creating challenge:" + createdChallenge.Errors.JSON);
                                //TODO handle error
                                return;
                            }
                            isHost = true;
                            //TryJoinChallenge(createdChallenge.RequestId);
                        });
            });


        }

        public void TryJoinChallenge(string requestId = null, Action<GSTypedResponse> success = null, Action<GSTypedResponse> error = null)
        {
            new GameSparks.Api.Requests.ListChallengeRequest()
                .SetShortCode(SHORTCODE)
                .SetState("ISSUED")
                .Send((availableChallenges) =>
                {
                    if (availableChallenges.HasErrors)
                    {
                        Debug.LogError("error getting challenge list :" + availableChallenges.Errors.JSON);
                        if (error != null) error(availableChallenges);
                        return;
                    }
                    bool challengeJoined = false;
                    // join the first open challenge
                    foreach (ListChallengeResponse._Challenge challenge in availableChallenges.ChallengeInstances)
                    {
                        if (challengeJoined) break; // stop iterating and trying to join
                        new GameSparks.Api.Requests.JoinChallengeRequest()
                            .SetChallengeInstanceId(challenge.ChallengeId)
                            .Send((joinedChallenge) =>
                            {
                                if (joinedChallenge.HasErrors)
                                {
                                    Debug.LogError("error joining challenge:" + joinedChallenge.Errors.JSON);
                                    if (error != null) error(joinedChallenge);
                                    return;
                                }
                                // a specific challenge was requested skip others
                                if (requestId != null && challenge.RequestId != requestId) return;
                                challengeId = challenge.ChallengeId;
                                challengeJoined = true;
                                return;
                            });
                    }
                    if (!challengeJoined && error != null) error(null);
                });


        }
    }
}