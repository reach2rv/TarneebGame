using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace cardgame
{
    public class GameUIButtonManager : MonoBehaviour
    {
        /// <summary>
        /// Button Manager Class loaded on main non destroyable Game object
        /// functions for all UI buttons 
        /// </summary>
        GameObject GSceneManager;
        void Awake()
        {
            GSceneManager = GameObject.Find("GSceneManager");
        }
        

        #region Bottom Panel Buttons
        public void btnShop()
        {          
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("03_1_Shop");
        }

        public void btnCustomize()
        {
            //PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("04_1_Customize");
        }

        public void btnQplay()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("05_1_QuickPlay");
        }

        public void btnCtable()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("06_1_CreateTable");
        }

        public void btnFrndsPannel()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_1_Friends");
        }
        #endregion

        #region Common UI Buttons

        

        public void btnClose()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            GSceneManager.GetComponent<GameSceneManager>().LoadPreviousScene();
        }

        public void btnBuyXP()
        {

        }

        public void btnBuyGold()
        {

        }

        public void btnBuySwag()
        {

        }

        public void btnLoss_ctnue()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("06_5_GameStatistics");
        }

        public void btnStat_ctnue()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("01_1_Main");
        }

        #endregion

        #region Main Scene

        #region Top Buttons
        public void btnProfile()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("02_1_Profile");
        }

        public void btnMsg()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("08_1_Messages");
        }

        #endregion

        #region Right Buttons
        public void btnQuest()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("10_1_Quests");
        }

        public void btnReward()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("11_1_DailyRewards");
        }

        public void btnChallenage()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("12_1_DailyChallenge");
        }

        public void btnAchivements()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("13_1_Achievement");
        }
        #endregion

        #region Left Buttons
        public void btnPrize()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Profile");
        }

        public void btnOffer()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("09_1_Offers");
        }

        public void btnFBconnect()
        {
            GameObject go = GameObject.Find("Canvas_Main");
            StartCoroutine(go.GetComponent<GameMainScene>().FBLogin());
        }

        public void btnPlayfrnd()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_3_InviteFriend");
        }

        public void btnBonus()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Profile");
        }

        #endregion

        #endregion

        #region Profile Scene



        #endregion

        #region Friends Scene

        public void btnMyFrnds()
        {
            //PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_1_Friends");
        }

        public void btnFrndRequest()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
           // PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_2_FriendRequest");
        }

        public void btnFrndInvite()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
           // PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_3_InviteFriend");
        }

        public void btnRecentFrnd()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            //PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_4_RecentlyPlayed");
        }

        public void btnFrnds()
        {
            
        }

        public void btnFrndGift()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("06_3_CreateTable");
        }

        public void btnFrndOl()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("06_3_CreateTable");
        }

        #endregion

        #region Shop Scene


        #endregion

        #region Customize Scene


        #endregion

        #region Quick Play Scene

        public void btnUnloackLevel()
        {

        }

        public void btnPlayLevel()
        {
            GSceneManager.GetComponent<GameSceneManager>().AddToLoadedScenes(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("06_3_CreateTable");
        }
        #endregion

        #region Create Table Scene

        public void btnPlayer1Add()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_1_Friends");
        }

        public void btnPlayer2Add()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_1_Friends");
        }

        public void btnPlayer3Add()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("07_1_Friends");
        }

        public void btnTplay()
        {
            PlayerPrefs.SetString("previousLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("06_3_CreateTable");
        }

        public void btnTrophy()
        {

        }

        public void btnCoins()
        {

        }
        #endregion

        #region Game Table Scene


        #endregion

        #region Friend Profile Scene


        #endregion

        #region Message Scene


        #endregion

        #region Offers Scene


        #endregion

        #region Quest Scene


        #endregion

        #region Daily Rewards Scene


        #endregion

        #region Daily Challenge Scene


        #endregion

        #region Achievement Scene


        #endregion

    }
}