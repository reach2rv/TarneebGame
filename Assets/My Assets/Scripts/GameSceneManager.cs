using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

    //Add this script to your button and call the public methods from the OnClick() event in the inspector
    public class GameSceneManager : MonoBehaviour
    {

        //A list to keep track of all the scenes you've loaded so far
        private List<string> previousScenes = new List<string>();

        void Awake()
        {
            previousScenes.Add(SceneManager.GetActiveScene().name); //Add your first scene
            //gameObject.SetActive(false);
            DontDestroyOnLoad(this.gameObject);
            //OPTIONAL: deactivate the button in your first scene, logically because there are no previous scenes  
        }

        //Always call this right before you load a new scene from another script (another button for example)
        //Note: Don't forget to activate the button gameobject if you've deactivated it in your first scene,
        //      otherwise you won't be able to call this method if you're using methods like FindObjectOfType<PreviousSceneLoader>()
        //      or GameObject.Find("the button gameobject name").GetComponent<PreviousSceneLoader>()
        public void AddCurrentSceneToLoadedScenes()
        {
           // gameObject.SetActive(true);
            previousScenes.Add(SceneManager.GetActiveScene().name);
            int test = previousScenes.Count;
        }

        //Call this method from your button OnClick() event system in the inspector
        public void LoadPreviousScene()
        {
            string previousScene = string.Empty;

            //Check whether you're not back at your original scene (index 0)
            if (previousScenes.Count > 1)
            {
                previousScene = previousScenes[previousScenes.Count - 1]; //Get the last previously loaded scene name from the list
                previousScenes.RemoveAt(previousScenes.Count - 1); //Remove the last previously loaded scene name from the list
                SceneManager.LoadScene(previousScene); //Load the previous scene
            }
            else
            {
                previousScene = previousScenes[0]; //0 will always be your first scene
                SceneManager.LoadScene(previousScene); //Load the previous scene
               // gameObject.SetActive(false); //The else is optional if you want the button to be deactivated when returning to the first scene
            }
        }
    }
