using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameSceneManager : MonoBehaviour
{
    //A list to keep track of all the scenes you've loaded so far
    private List<string> previousScenes = new List<string>();
    private static GameSceneManager Instance;

    void Awake()
    {

        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        previousScenes.Add(SceneManager.GetActiveScene().name); //Add your first scene  
    }

    //Always call this right before you load a new scene from another script (another button for example)
    public void AddToLoadedScenes(string scene)
    {
        // gameObject.SetActive(true);
        previousScenes.Add(scene);
        int test = previousScenes.Count;
    }

    //Call this method from your button OnClick() event system in the inspector
    public void LoadPreviousScene()
    {
        string previousScene = string.Empty;

        //Check whether you're not back at your original scene (index 0)
        if (previousScenes.Count > 1)
        {
            //Get the last previously loaded scene name from the list
            previousScene = previousScenes[previousScenes.Count - 1];
            //Remove the last previously loaded scene name from the list
            previousScenes.RemoveAt(previousScenes.Count - 1);
            SceneManager.LoadScene(previousScene); //Load the previous scene
        }
        else
        {
            previousScene = previousScenes[0]; //0 will always be your first scene
            SceneManager.LoadScene(previousScene); //Load the previous scene
        }
    }
}
