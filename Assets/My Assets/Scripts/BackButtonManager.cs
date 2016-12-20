using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace cardgame
{
    public class BackButtonManager : MonoBehaviour
    {

        float _doubleTapTimeD;
        bool quitBool;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // _scenemanager = new GameSceneManager();
           // bool doubleTapD = false;

            quitBool = false;

            if (Input.touchCount > 1) quitBool = false;
            if (Input.GetKey(KeyCode.Escape) && quitBool == true)
            {
                Application.Quit();
            }
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    quitBool = false;
                    string previousLevel = PlayerPrefs.GetString("previousLevel");
                    SceneManager.LoadScene(previousLevel);
                    if (previousLevel == "Main")
                        quitBool = true;
                }
                else
                {
                    quitBool = true;
                }

            }




            //#region doubleTapD
            //if (Input.GetKeyDown(KeyCode.Escape))
            //    {
            //        if (Time.time < 2.0f)
            //        {
            //            Application.Quit();

            //        }
            //        else if (Input.GetKey(KeyCode.Escape))
            //        {
            //            // Insert Code Here (I.E. Load Scene, Etc)
            //            // OR Application.Quit();
            //           string previousLevel = PlayerPrefs.GetString("previousLevel");
            //           SceneManager.LoadScene(previousLevel);
            //           // _scenemanager.LoadPreviousScene();
            //            //return;
            //        }
            //       // _doubleTapTimeD = Time.time;
            //    }

            //#endregion
        }
    }


        //    float touchDuration;
        //    Touch touch;
        //    void Update()
        //    {
        //        if (Input.touchCount > 0)
        //        { //if there is any touch
        //            touchDuration += Time.deltaTime;
        //            touch = Input.GetTouch(0);

        //            if (touch.phase == TouchPhase.Ended && touchDuration < 0.2f) //making sure it only check the touch once && it was a short touch/tap and not a dragging.
        //                StartCoroutine("singleOrDouble");
        //        }
        //        else
        //            touchDuration = 0.0f;
        //    }

        //    IEnumerator singleOrDouble()
        //    {
        //        yield return new WaitForSeconds(0.3f);
        //        if (touch.tapCount == 1)
        //        {
        //            Debug.Log("Single");
        //            Application.Quit();
        //        }

        //        else if (touch.tapCount == 2)
        //        {
        //            //this coroutine has been called twice. We should stop the next one here otherwise we get two double tap
        //            StopCoroutine("singleOrDouble");
        //            Debug.Log("Double");
        //            _scenemanager.LoadPreviousScene();
        //        }
        //    }
        //}
    }