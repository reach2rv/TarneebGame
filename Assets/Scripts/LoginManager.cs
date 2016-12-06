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

namespace cardgame
{
    public class LoginManager : MonoBehaviour
    {
        //These are the account details we want to pull in
        //public string userName;
        //public string userId;
        //private string facebookId;

        public Text UserName;
        public Text city;
        public Image profilePic;

        //singleton for the gamesparks manager so it can be called from anywhere
        private static LoginManager instance = null;
        //getter property for private backing field instance
        public static LoginManager Instance() { return instance; }

        // Use this for initialization
        void Awake()
        {
            //this will create a singleton for our gamesparks manager object
            if (instance = null)
            {
                instance = this;
                //UserName = GameObject.Find("UserName").GetComponent<Text>();
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
            GS.GameSparksAvailable += GSAvailable;
            GameSparks.Api.Messages.AchievementEarnedMessage.Listener += AchievementEarnedListener;
        }

        void GSAvailable(bool _isAvalable)
        {
            //this method will be called only when the GS service is available or unavailable
            if (_isAvalable)
            {
                // Application.LoadLevel(1);
                Debug.Log(">>>>>>>>>GS Conected<<<<<<<<");
            }
            else
            {
                Debug.Log(">>>>>>>>>GS Disconnected<<<<<<<<");
            }
        }

        //Achievement message  listener
        private void AchievementEarnedListener(GameSparks.Api.Messages.AchievementEarnedMessage _message)
        {
            Debug.LogWarning("Message Recieved" + _message.AchievementName);

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


        /// <summary>
        /// When Facebook is ready , this will connect the pleyer to Facebook
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
                Debug.Log("Something wrong  with FB");
            }

            
        }

        //this is the callback that happens when gamesparks has been connected with FB
        private void AfterFBLogin(GameSparks.Api.Responses.AuthenticationResponse _resp)
        {
            Debug.Log(_resp.DisplayName);
            UpdateInformation();
            //SceneManager.UnloadScene("main");
            SceneManager.LoadScene("UserDeck", LoadSceneMode.Single);

        }

        //delegate for asynchronous callbacks
        public delegate void FacebookLoginCallback(AuthenticationResponse _resp);


        //This method will connect GS with FB
        public void GSFacebookLogin(FacebookLoginCallback _fbLoginCallback)
        {
            Debug.Log("");

            new GameSparks.Api.Requests.FacebookConnectRequest()
                .SetAccessToken(AccessToken.CurrentAccessToken.TokenString)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Logged into gamesparks with facebook");
                        _fbLoginCallback(response);
                    }
                    else
                    {
                        Debug.Log("Error Logging into facebook");
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
                        Debug.Log("Error Authenticating Player\n" + response.Errors.JSON.ToString());
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
                
                UserName.text = response.DisplayName;
                StartCoroutine(getFBPicture(response.ExternalIds.GetString("FB").ToString()));
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
            //To get our facebook picture we use this address which we pass our facebookId into
           // var www = new WWW("http://graph.facebook.com/" + facebookId + "/picture?width=210&height=210");

            var www = new WWW("http://graph.facebook.com/" + facebookId + "/picture?width=64&height=64");

            yield return www;

            Image userAvatar = profilePic.GetComponent<Image>();

            //  www.texture.LoadImage()
            Rect rect = new Rect(0, 0, 64, 64);
            userAvatar.sprite = Sprite.Create(www.texture, rect, new Vector2(0, 0), 125);


           // userAvatar.sprite = Sprite.Create(www.texture, new Rect(0, 0, 100, 100), new Vector2(0, 0));
            //userAvatar.sprite = Sprite.Create(www.texture, new Rect(0, 0, 100, 100), new Vector2(0, 0));

            

            //Texture2D tempPic = new Texture2D(25, 25);

            //www.LoadImageIntoTexture(tempPic);
            //profilePicture.mainTexture = tempPic;
        }

    }


}