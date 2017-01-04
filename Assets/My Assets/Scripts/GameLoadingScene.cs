using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using Facebook.Unity;

namespace cardgame
{

    public class Loading : MonoBehaviour
    {
        private bool loadScene = false;

        [SerializeField]
        private int scene;
        [SerializeField]
        private Text loadingText;


        // Updates once per frame
        void Update()
        {
            //set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            //change the instruction text to read "Loading..."
            loadingText.text = "Loading...";

            //and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene());

            // If the new scene has started loading...
            if (loadScene == true)
            {
                //pulse the transparency of the loading text to let the player know that the game is still Loading.
                loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
            }
        }


        // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
        IEnumerator LoadNewScene()
        {
            // This line waits so can load data from Gamesparks Servers
            yield return new WaitForSeconds(7);

            // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
            AsyncOperation async = SceneManager.LoadSceneAsync(scene);

            // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
            while (!async.isDone)
            {
                yield return null;
            }
        }

    }

}