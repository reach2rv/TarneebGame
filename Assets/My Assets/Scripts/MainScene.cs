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

        public GameObject levelmanager;
        public Text CSilver, CGold, CSwag, UserName;
        public Image fb;

        void Start()
        {

        }

        void update()
        {
            updatestatitics();
        }

        public void btnprofile_click()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Profile");
        }

        public void btnfbconnect()
        {
            StartCoroutine(FBLogin());
        }

        IEnumerator FBLogin()
        {
            //PlayerPrefs.DeleteKey("userId");
            GameObject go = GameObject.Find("Main_API");
            go.GetComponent<GameSparksManager>().ConnectWithFacebook();
            yield return new WaitUntil(() => FBConnected() == true);
        }

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
            updatestatitics();
        }

        public void updatestatitics()
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

        public void btncustomize_click()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("LoginLanding");
        }
    }
}