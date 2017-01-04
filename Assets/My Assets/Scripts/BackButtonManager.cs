using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace cardgame
{
    public class BackButtonManager : MonoBehaviour
    {
        
        void Awake()
        {
            
        }

        /// <summary>
        /// Back Button event Manager
        /// get the previous Scene from Player Preferences which we set while loading new Scene
        /// Check for Active Scene and Process Accordingly
        /// </summary>
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                string previousLevel = PlayerPrefs.GetString("previousLevel");
                string activelevel = SceneManager.GetActiveScene().name;
                
                switch (activelevel)
                {
                    case "01_1_Main":
                        //TODO Add Confirmation Popup
                        GameObject Quitcofirm = GameObject.Find("Canvas_Main");
                        Quitcofirm.GetComponent<QuitConfirmUI>().DoQuit();
                        break;
                    case "06_3_CreateTable":
                        //TODO Add Confirmation Popup
                        SceneManager.LoadScene("01_1_Main");
                        break;
                    case "06_4_GameTable":
                        //TODO Add Confirmation Popup
                        SceneManager.LoadScene("01_1_Main");
                        break;
                    default:
                        GameObject GSceneManager = GameObject.Find("GSceneManager");
                        GSceneManager.GetComponent<GameSceneManager>().LoadPreviousScene();
                        //SceneManager.LoadScene(previousLevel);
                        break;
                }

            }
        }

    }
}
