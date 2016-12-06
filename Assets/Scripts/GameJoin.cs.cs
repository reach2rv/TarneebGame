using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using UnityEngine.UI;

namespace cardgame
{
    public class GameJoin : MonoBehaviour
    {
        //TableID is the important variable here, we use to reference the specific Table we are playing
        public string inviteName, inviteExpiry, TableId, facebookId;


        //We use canDestroy to let the Tween Alpha know it's safe to remove the gameObject OnFinish animating
        public bool canDestroy = false;

        public Text inviteNameLabel, inviteExpiryLabel;
        public Text profilePicture;

        // Use this for initialization
        void Start()
        {
            inviteNameLabel.text = inviteName + "has invited you to play";
            inviteExpiryLabel.text = "Expires on " + inviteExpiry;
        }

        //This in the function we call OnClick
        public void JoinTable()
        {
            //We set the Table Instance Id and Message of Tablejoinrequest (AcceptChallengeRequest)
            new AcceptChallengeRequest().SetChallengeInstanceId(TableId)
                .SetMessage("You're goin down!")
                .Send((response) =>
                {
                    if (response.HasErrors)
                    {
                        Debug.Log(response.Errors);
                    }
                    else
                    {
                    //Since this challenge is no longer an invite, we need to update our running games
                    TableManager.instance.GetRunningChallenges();

                    //Once we accept the challenge we can go ahead and remove the gameObject from the scene
                    canDestroy = true;
                    }
                });
        }
    }
}