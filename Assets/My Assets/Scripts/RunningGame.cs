using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


namespace cardgame
{
    public class RunningGame : MonoBehaviour
    {

        //We store the tableId, next player's userId and the userId who initiated the game.
        public string tableId, turnStatus, challengerId;

        //We create a list for playerNames and Ids
        public List<string> playerNames = new List<string>();
        public List<string> playerIds = new List<string>();

        //This is the array of strings we pass our Cloud Code gameBoard to
        public string[] gameBoard;

        //We use canDestroy to let the Tween Alpha know it's safe to remove the gameObject OnFinish animating
        public bool canDestroy = false;

        public Text challengeLabel, statusLabel;

        // Use this for initialization
        void Start()
        {
            //We set the challenge label with the names of both players
            challengeLabel.text = playerNames[0] + " VS " + playerNames[1];

            //We then check if the userId of the next player is equal to ours
            //if (turnStatus == UserManager.instance._userid)
            //{
            //    //If it is, then we say it's your turn
            //    statusLabel.text = "Your Turn!";
            //}
            //else
            //{
            //    for (int i = 0; i < playerIds.Count; i++)
            //    {
            //        //else find the player whose Id does match and return their name
            //        if (playerIds[i] == turnStatus)
            //        {
            //            statusLabel.text = playerNames[i] + "'s Turn!";
            //        }
            //    }
            //}
        }

        //Start game gets called OnClick of the play button
        public void StartGame()
        {

        }

    }
}