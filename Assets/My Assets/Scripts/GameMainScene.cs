using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameSparks.Api.Responses;
using GameSparks.Api.Requests;
using GameSparks.Core;
using Facebook.Unity;

namespace cardgame
{
    public class MainScene : MonoBehaviour
    {
        public GameObject levelmanager, player1, player2, player3, player4;
        public Text CSilver, CGold, CSwag, UserName, Players;
        public Image fb;
        int players;

        void update()
        {
            updatestatistics();
            GameSparks.Api.Messages.MatchFoundMessage.Listener += MatchFoundMessageListener;
        }

        //Achievement message  listener
        private void MatchFoundMessageListener(GameSparks.Api.Messages.MatchFoundMessage _message)
        {
            this.Players.text = _message.Participants.ToString();
            players = int.Parse(_message.Participants.ToString());
            Debug.LogWarning("Message Received" + _message.Participants);
        }

        /// <summary>
        /// User Login using FB
        /// </summary>
        /// <returns></returns>
        public IEnumerator FBLogin()
        {
            GameObject go = GameObject.Find("Main_API");
            go.GetComponent<GameSparksManager>().ConnectWithFacebook();
            yield return new WaitUntil(() => FBConnected() == true);
            yield return new WaitForSeconds(5);
            updatestatistics();
        }
        /// <summary>
        /// Check whether Player is Logged in using FB
        /// </summary>
        /// <returns></returns>
        bool FBConnected()
        {
            if (PlayerPrefs.GetString("FBLogin") == "True")
                return true;
            else if (PlayerPrefs.GetString("FBLogin") == "False")
                return true;
            else
                return false;
        }

        void OnEnable()
        {
            updatestatistics();
        }

        /// <summary>
        /// Get Player statistics from Player preferences and set on text objects
        /// </summary>
        public void updatestatistics()
        {
            if (FB.IsLoggedIn)
                fb.enabled = false;
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("userId")))
            {
                CGold.text = PlayerPrefs.GetFloat("cGold").ToString();
                CSilver.text = PlayerPrefs.GetFloat("cSilver").ToString();
                CSwag.text = PlayerPrefs.GetFloat("cSwag").ToString();
                if (!string.IsNullOrEmpty(PlayerPrefs.GetString("NewPlayer")))
                    UserName.text = "Welcome " + PlayerPrefs.GetString("displayName") + " !!";
                else
                    UserName.text = "Welcome back " + PlayerPrefs.GetString("displayName") + " !!";
            }
        }

        public void Create_Table_Click()
        {
            StartCoroutine(Create_Table());
        }

        IEnumerator Create_Table()
        {
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            bool Match_created = false;
            this.gameObject.GetComponent<QuitConfirmUI>().match_waiting();
            Debug.Log("Calling create Match ... ");
            new GameSparks.Api.Requests.LogEventRequest_Match_Event()
                .Set_match_code("basic")
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("request basic Match");
                        Match_created = true;
                    }
                    else
                    {
                        Debug.LogWarning("Failed to add basic match...\n" + response.Errors.JSON.ToString());
                    }
                });
            yield return new WaitWhile(() => Match_created == true);
            //while(players < 4)
            //{
            //    if(players == 1)
            //    {
            //        player1.SetActive(true);
            //    }
            //    else if (players == 1)
            //    {
            //        player1.SetActive(true);
            //        player2.SetActive(true);
            //    }
            //    else if (players == 1)
            //    {
            //        player1.SetActive(true);
            //        player2.SetActive(true);
            //        player3.SetActive(true);
            //    }
            //}

        }

    }
}