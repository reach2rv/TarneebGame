using GameSparks.Api.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace cardgame
{
    public class GameProfileManager : MonoBehaviour
    {

        public Text CSilver, CGold, CSwag, Rank, Win;
        int rank;     
        public InputField UserName;
        public List<string> PlayerLeaderBoard = new List<string>();
        // Use this for initialization


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnEnable()
        {
            updateinfo();
        }

        public void updateinfo()
        {
            CGold.text = PlayerPrefs.GetFloat("cGold").ToString();
            CSilver.text = PlayerPrefs.GetFloat("cSilver").ToString();
            CSwag.text = PlayerPrefs.GetFloat("cSwag").ToString();
            UserName.text = PlayerPrefs.GetString("displayName");
            Rank.text = rank.ToString();
            Win.text = "";
        }

        public IEnumerator btnDisplayName()
        {
            GameObject GSMain = GameObject.Find("Main_API");
            GSMain.GetComponent<GameSparksManager>().updateplayedetails(UserName.text);
            yield return new WaitForSeconds(2);
            updateinfo();
        }

        public void get_rank()
        {
            PlayerLeaderBoard.Add("High_Score_Leaderboard");
            new GetLeaderboardEntriesRequest()
                .SetPlayer(PlayerPrefs.GetString("userId"))
                .SetLeaderboards(PlayerLeaderBoard)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("results" + response.Results);
                        rank = (int)response.BaseData.GetGSData("High_Score_Leaderboard").GetNumber("rank");
                    }
                    else
                    {
                        Debug.Log("Error Authenticating Player...");
                    }
                });
        }

    }
}