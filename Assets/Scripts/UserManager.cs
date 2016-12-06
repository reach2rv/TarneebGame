using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using UnityEngine.UI;

namespace cardgame
{
    public class UserManager : MonoBehaviour
    {

       public static UserManager instance;

        //These are the account details we want to pull in
        public string userName;
        public string userId;
        private string facebookId;

        public Text UserName;
        public Image profilepic;

        // Use this for initialization
       
        public void UpdateInformation()
        {
            //We send an AccountDetailsRequest
            new AccountDetailsRequest().Send((response) =>
            {
            //We pass the details we want from our response to the function which will update our information
            UpdateGUI(response.DisplayName, response.UserId, response.ExternalIds.GetString("FB").ToString());
            });
        }

        public void UpdateGUI(string name, string uid, string fbId)
        {
            userName = name;
            UserName.text = userName;
            userId = uid;
            facebookId = fbId;
            StartCoroutine(getFBPicture());
        }

        public IEnumerator getFBPicture()
        {
            //To get our facebook picture we use this address which we pass our facebookId into
            var www = new WWW("http://graph.facebook.com/" + facebookId + "/picture?width=210&height=210");

            yield return www;

            Texture2D tempPic = new Texture2D(25, 25);

            www.LoadImageIntoTexture(tempPic);
            //profilePicture.mainTexture = tempPic;
        }
    }
}