using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace cardgame {

    public class GameLoadingScene : MonoBehaviour {
        [SerializeField]
        private Text loadingText;

        private void Start () {
            StartCoroutine (LoadNewScene ());
        } 

        // Updates once per frame
        void Update () {
            //change the instruction text to read "Loading..."
            loadingText.text = "Loading...";
            //pulse the transparency of the loading text to let the player know that the game is still Loading.
            loadingText.color = new Color (loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong (Time.time, 1));
        }

        // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
        IEnumerator LoadNewScene () {
            // This line waits so can load data from Gamesparks Servers
            yield return new WaitForSeconds (7);

            // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
            AsyncOperation async = SceneManager.LoadSceneAsync (1);

            // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
            while (!async.isDone) {
                yield return null;
            }
        }
    }
}