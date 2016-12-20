using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSparks.Core;
using System.Collections.Generic;
using System;
using GameSparks.Api.Responses;
using Facebook.Unity;
using cardgame;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
namespace cardgame
{
    public class Landing : MonoBehaviour
    {

        public Text CSilver;
        public Text CGold;
        public Text CSwag;
        long? silver;
        long? gold;
        long? swag;
        // Use this for initialization

        //LoginManager LM;

        void Start()
        {

           GS.GameSparksAvailable += GSAvailable;
            playerconnected();
            //LM = new LoginManager();


            

            // GS.GameSparksAvailable += GSAvailable;
            //GS.Reconnect();
        }

        void GSAvailable(bool _isAvalable)
        {
            //this method will be called only when the GS service is available or unavailable
            if (_isAvalable)
            {
                // Application.LoadLevel(1);
                Debug.Log(">>>>>>>>>GS Connected<<<<<<<<");
            }
            else
            {
                Debug.Log(">>>>>>>>>GS Disconnected<<<<<<<<");
            }
        }

        void playerconnected()
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("New User Loading Tutorial");
                //SceneManager.LoadScene("");

            }
            else if (GS.Authenticated)
            {
                updatestatitics();
            }
            else
            {
                GamesparksDeviceConnect();
                // CGold.text = "1000";
                updatestatitics();

            }

        }

        void GamesparksDeviceConnect()
        {
            new GameSparks.Api.Requests.DeviceAuthenticationRequest()
                    .SetDurable(true)
                        .Send((response) =>
                        {

                            if (!response.HasErrors)
                            {
                                Debug.Log("Device Authenticated with ID => " + response.UserId);
                            }
                        });
        }

        void updatestatitics()
        {
            new AccountDetailsRequest()
                .Send((response) =>
                {
                    IList<string> achievements = response.Achievements;
                    silver = response.Currency1;
                    gold = response.Currency2;
                    swag = response.Currency3;
                    string displayName = response.DisplayName;
                    GSData externalIds = response.ExternalIds;
                    var location = response.Location;
                    string userId = response.UserId;
                    GSData virtualGoods = response.VirtualGoods;
                });
            CGold.text = gold.ToString();
            CSilver.text = silver.ToString();
            CSwag.text = CSwag.ToString();
        }

        void updateplayedetails()
        {
            new ChangeUserDetailsRequest()
            .SetDisplayName("")
            .SetLanguage("")
            .Send((response) =>
            {
                GSData scriptData = response.ScriptData;
            });
        }

        void connectFB()
        {
            //LM.ConnectWithFacebook();
            updatestatitics();
        }

    }
}