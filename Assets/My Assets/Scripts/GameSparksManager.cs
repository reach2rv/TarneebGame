using UnityEngine;
using System.Collections;
using GameSparks.Core;
using System.Collections.Generic;
using System;
using GameSparks.Api.Responses;
using Facebook.Unity;
using cardgame;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Api.Messages;

namespace cardgame
{
    public class GameSparksManager : MonoBehaviour
    {
        public string displayName, UserId, players, _player1, _player2, _player3, _player4, _nxtplayer;
        public long cSilver, cGold, cSwag;
        public int loginDays;
        public List<string> _achievementsList;
        public List<GSData> Cards;
        public GSEnumerable<string> _players;


        //singleton for the gamesparks manager so it can be called from anywhere
        private static GameSparksManager instance = null;
        //getter property for private backing field instance
        // public GameSparksManager Instance() { return instance; }

        // Use this for initialization
        void Awake()
        {
            //this will create a singleton for our gamesparks manager object
            if (instance = null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }

            //PlayerPrefs.SetString("FBLogin", "");

            FB.Init();
            GS.GameSparksAvailable += GSAvailable;
            //playerconnectedtoGS();
            AchievementEarnedMessage.Listener += AchievementEarnedListener;
            ChallengeStartedMessage.Listener += ChallengeListener;
            //MatchUpdatedMessage.Listener += MatchUpdatedMessageListner;
        }

        void GSAvailable(bool _isAvalable)
        {
            if (_isAvalable)
            {
                Debug.Log("GS Connected");
                playerconnectedtoGS();
            }
            else
            {
                Debug.Log("GS Disconnected");
            }
        }

        //Achievement message  listener
        private void AchievementEarnedListener(GameSparks.Api.Messages.AchievementEarnedMessage _message)
        {
            Debug.LogWarning("Message Received" + _message.AchievementName);
        }

        //Achievement message  listener
        int cplay = 0;
        private void ChallengeListener(ChallengeStartedMessage _message)
        {
            string playerid = PlayerPrefs.GetString("userId");
            Debug.Log("Fetching Cards from Server");
            Cards = _message.Challenge.ScriptData.GetGSDataList(playerid);
            if (Cards == null)
            {
                Cards = _message.Challenge.ScriptData.GetGSDataList(playerid);
            }
            var chalid = _message.Challenge.ChallengeId;
            PlayerPrefs.SetString("chalid", chalid);
            _nxtplayer = _message.Challenge.NextPlayer;
            StartCoroutine(LoadNewScene());
        }

        //private void MatchUpdatedMessageListner(GameSparks.Api.Messages.MatchUpdatedMessage _message)
        //{
        //    var addedplayers = _message.AddedPlayers;
        //    GameObject go = GameObject.Find("Canvas_Main/wait_match/Box");
        //    if (go != null)
        //    {
        //        var player1 = go.transform.Find("Player_1").gameObject;
        //        var player2 = go.transform.Find("Player_2").gameObject;
        //        var player3 = go.transform.Find("Player_3").gameObject;
        //        var player4 = go.transform.Find("Player_4").gameObject;

        //        switch (addedplayers.Count)
        //        {
        //            case 1:
        //                player1.SetActive(true);
        //                break;
        //            case 2:
        //                player1.SetActive(true);
        //                player2.SetActive(true);
        //                break;
        //            case 3:
        //                player1.SetActive(true);
        //                player2.SetActive(true);
        //                player3.SetActive(true);
        //                break;
        //            case 4:
        //                player1.SetActive(true);
        //                player2.SetActive(true);
        //                player3.SetActive(true);
        //                player4.SetActive(true);
        //                break;
        //        }

        //    }

        // }

        IEnumerator LoadNewScene()
        {
            yield return new WaitForSeconds(5);
            AsyncOperation async = SceneManager.LoadSceneAsync("06_4_GameTableSinglePlayer");
            while (!async.isDone)
            {
                yield return null;
            }
        }

        void playerconnectedtoGS()
        {
            string fblogin = PlayerPrefs.GetString("FBLogin");
            if (!string.IsNullOrEmpty(fblogin))
            {
                StartCoroutine(AutoLoginFacebook());
                PlayerPrefs.SetString("NewPlayer", "");
            }

            else if (GS.Authenticated)
            {
                if (userid() == false)
                {
                    StartCoroutine(PlayerDetails());
                    PlayerPrefs.SetString("NewPlayer", "");
                }                
            }
            else
            {
                StartCoroutine(DeviceConnect());
                StartCoroutine(SetPlayerDetails("Guest" + UserId));
                PlayerPrefs.SetString("NewPlayer", "True");
            }
        }

        IEnumerator DeviceConnect()
        {
            GamesparksDeviceConnect();
            yield return new WaitUntil(() => GS.Authenticated == true);
        }

        IEnumerator PlayerDetails()
        {
            getaccountdetails();
            yield return new WaitUntil(() => userid() == true);
            setaccontdetails();

        }
        void GamesparksDeviceConnect()
        {
            new GameSparks.Api.Requests.DeviceAuthenticationRequest()
                    .SetDurable(true)
                    .SetDisplayName("user")
                        .Send((response) =>
                        {
                            if (!response.HasErrors)
                            {
                                Debug.Log("Device Authenticated with ID => " + response.UserId);
                            }
                        });
        }

        public void getaccountdetails()
        {
            Debug.Log("Fetching Account Details");
            if (GS.Available)
                new AccountDetailsRequest()
                    .Send((response) =>
                    {
                        if (response.HasErrors)
                        {
                            Debug.Log(response.Errors);

                        }
                        else
                        {
                            _achievementsList = response.Achievements;
                            GSData virtualGoods = response.VirtualGoods;
                            displayName = response.DisplayName;
                            //PlayerPrefs.SetString("location", response.Location.ToString());
                            UserId = response.UserId;
                            cSilver = (long)response.Currency1;
                            cGold = (long)response.Currency2;
                            cSwag = (long)response.Currency3;
                            //loginDays = (int)response.BaseData.GetInt("daysInrow");
                            Debug.Log("Received Account Details");
                        }
                    });
        }
        int achvmnts = 0;
        public void setaccontdetails()
        {
            PlayerPrefs.SetString("displayName", displayName);
            //PlayerPrefs.SetString("location", response.Location.ToString());
            PlayerPrefs.SetString("userId", UserId);
            PlayerPrefs.SetFloat("cSilver", cSilver);
            PlayerPrefs.SetFloat("cGold", cGold);
            PlayerPrefs.SetFloat("cSwag", cSwag);
            PlayerPrefs.SetInt("loginDays", loginDays);
            if (_achievementsList != null)
            {
                foreach (string s in _achievementsList)
                {
                    achvmnts++;
                }
            }
            PlayerPrefs.SetInt("achvmnts", achvmnts);
            Debug.Log("Player Preferences set" + UserId + cSilver + cGold);
        }

        public void updateplayedetails(string disname)
        {
            new ChangeUserDetailsRequest()
            .SetDisplayName(disname)
            .Send((response) =>
            {
                GSData scriptData = response.ScriptData;
            });

            StartCoroutine(PlayerDetails());
            setaccontdetails();
        }

        bool userid()
        {
            if (string.IsNullOrEmpty(UserId))
                return false;
            else
                return true;
        }

        IEnumerator SetPlayerDetails(string disname)
        {
            updateplayedetails(disname);
            yield return null;
        }

        #region FaceBook Authentication
        /// <summary>
        /// Below we will login with facebook.
        /// When FB is ready we will call the method that allows GS to connect to GameSparks
        /// </summary>
        public void ConnectWithFacebook()
        {
            if (!FB.IsInitialized)
            {
                Debug.Log("Initializing Facebook");
                FB.Init(FacebookLogin);
            }
            else
            {
                FacebookLogin();
            }
        }


        IEnumerator AutoLoginFacebook()
        {
            if (!FB.IsInitialized)
            {
                Debug.Log("Initializing Facebook");
                FB.Init(FacebookLogin);
            }
            else
            {
                FacebookLogin();
            }
            yield return new WaitUntil(() => FB.IsLoggedIn == true);
        }


        /// <summary>
        /// When Facebook is ready , this will connect the player to Facebook
        /// After the Player is authenticated it will  call the GS connect
        /// </summary>
        void FacebookLogin()
        {
            if (!FB.IsLoggedIn)
            {
                Debug.Log("Logging into Facebook");
                FB.LogInWithReadPermissions(
                    new List<string>() { "public_profile", "email", "user_friends" },
                    GameSparksFBConnect
                    );
            }

            if (FB.IsLoggedIn)
            {
                GSFacebookLogin(AfterFBLogin);
            }

        }

        void GameSparksFBConnect(ILoginResult result)
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("Logging into gamesparks with facebook details");
                GSFacebookLogin(AfterFBLogin);
            }
            else
            {
                Debug.LogError("Something wrong  with FB");

            }
        }

        //this is the callback that happens when gamesparks has been connected with FB
        private void AfterFBLogin(GameSparks.Api.Responses.AuthenticationResponse _resp)
        {
            StartCoroutine(SetPlayerDetails(_resp.DisplayName));
        }

        //delegate for asynchronous callbacks
        public delegate void FbLoginCallback(AuthenticationResponse _resp);


        //This method will connect GS with FB
        public void GSFacebookLogin(FbLoginCallback _fbLoginCallback)
        {
            Debug.Log("");

            new GameSparks.Api.Requests.FacebookConnectRequest()
                .SetAccessToken(AccessToken.CurrentAccessToken.TokenString)
                .SetDoNotLinkToCurrentPlayer(false)
                .SetSwitchIfPossible(true)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Logged into gamesparks with facebook");

                        PlayerPrefs.SetString("FBLogin", "True");
                        _fbLoginCallback(response);
                    }
                    else
                    {
                        Debug.LogError("Error Logging into facebook");
                        PlayerPrefs.SetString("FBLogin", "False");
                    }
                });
        }
        #endregion


        /// <summary>
        /// If a player is registered this will log them in with GameSparks.
        /// </summary>
        public void LoginPlayer(string _userNameInput, string _passwordInput)
        {
            new GameSparks.Api.Requests.AuthenticationRequest()
                .SetUserName(_userNameInput)
                .SetPassword(_passwordInput)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Authenticated...");
                    }
                    else
                    {
                        Debug.LogError("Error Authenticating Player\n" + response.Errors.JSON.ToString());
                    }
                });
        }

        /// <summary>
        /// this will register a new player and assign their email to their account.
        /// </summary>
        public void RegisterNewPlayer(string _userNameInput, string _emailInput, string _passwordInput)
        {
            new GameSparks.Api.Requests.RegistrationRequest()
                .SetDisplayName(_userNameInput)
                .SetUserName(_userNameInput)
                .SetPassword(_passwordInput)
                .SetScriptData(new GSRequestData().AddString("email", _emailInput))
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Player registered");
                    }
                    else
                    {
                        Debug.LogWarning("Failed to register player...\n" + response.Errors.JSON.ToString());
                    }
                });
        }


        public void UpdateInformation()
        {
            //We send an AccountDetailsRequest
            new GameSparks.Api.Requests.AccountDetailsRequest().Send((response) =>
            {
                //We pass the details we want from our response to the function which will update our information

                // UserName.text = response.DisplayName;
                //StartCoroutine(getFBPicture(response.ExternalIds.GetString("FB").ToString()));
                //city.text = response.ExternalIds.GetString("Location").ToString();
                //UpdateGUI(response.DisplayName, response.UserId, response.ExternalIds.GetString("FB").ToString());

            });
        }

        public void UpdateGUI(string name, string uid, string fbId)
        {
            //UserName.text = name;
            // UserName.text = userName;
            //userId = uid;
            //facebookId = fbId;
            // StartCoroutine(getFBPicture());
        }

        public IEnumerator getFBPicture(string facebookId)
        {
            var www = new WWW("http://graph.facebook.com/" + facebookId + "/picture?width=64&height=64");
            yield return www;
            //Image userAvatar = profilePic.GetComponent<Image>();
            //  www.texture.LoadImage()
            Rect rect = new Rect(0, 0, 64, 64);
            //userAvatar.sprite = Sprite.Create(www.texture, rect, new Vector2(0, 0), 125);
        }

        void AddGold(int currencyRef, long amount)
        {
            Debug.Log("Calling AddCurrency ... ");
            new GameSparks.Api.Requests.LogEventRequest_addcurrency1()
                .Set_currencyRef(currencyRef)
                .Set_amount(amount)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Gold Added");
                    }
                    else
                    {
                        Debug.LogWarning("Failed to add Gold...\n" + response.Errors.JSON.ToString());
                    }
                });
        }

        void AddSilver(int currencyRef, long amount)
        {
            Debug.Log("Calling AddCurrency ... ");
            new GameSparks.Api.Requests.LogEventRequest_addcurrency1()
                .Set_currencyRef(currencyRef)
                .Set_amount(amount)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Silver Added");
                    }
                    else
                    {
                        Debug.LogWarning("Failed to add Silver...\n" + response.Errors.JSON.ToString());
                    }
                });

        }

        static void AddSwag(int currencyRef, long amount)
        {
            Debug.Log("Calling AddCurrency ... ");
            new GameSparks.Api.Requests.LogEventRequest_addcurrency1()
                .Set_currencyRef(currencyRef)
                .Set_amount(amount)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Swag Added");
                    }
                    else
                    {
                        Debug.LogWarning("Failed to add Swag...\n" + response.Errors.JSON.ToString());
                    }
                });
        }
    }
}