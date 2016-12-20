using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using UnityEngine.UI;
using GameSparks.Api.Responses;
using System.Collections.Generic;

namespace cardgame
{
    public class UserManager : MonoBehaviour
    {

      // public static UserManager instance;

        //These are the account details we want to pull in
        public string _displayname, _cGold, _cSilver, _cSwag, _userid;
        public IList<string> achievements;

        // Use this for initialization

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            //PlayerStatistics();
        }
        // Use this for initialization
        void Start()
        {

        }

        public void PlayerStatistics()
        {
            _cGold = PlayerPrefs.GetFloat("cGold").ToString();
            _cSilver = PlayerPrefs.GetFloat("cSilver").ToString();
            _cSwag = PlayerPrefs.GetFloat("cSwag").ToString();
            _displayname = PlayerPrefs.GetString("displayName");
            _userid = PlayerPrefs.GetString("userId");


        }

    }
}